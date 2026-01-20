using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParkingApp.Businesslogic.Helpers;
using ParkingApp.Businesslogic.IRepositories;
using ParkingApp.Businesslogic.Services;
using ParkingApp.Data.IRepositories;
using ParkingApp.Data.Repository;
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.Repositories
{
    public class MplususersBusinessLogicProvider:IMplususersBusinessLogicProvider
    {
        private IMplususersDataProvider _IMplususersDataProvider;
        private readonly IValidator<MplususersDto> _validator;
        private readonly IValidator<UserLogin> _loginvalidator;
        private readonly IPasswordHasher<MplususersDto> _passwordHasher;
        private readonly JwtTokenService _jwtService;
        private readonly IConfiguration _configuration;
        public MplususersBusinessLogicProvider(IMplususersDataProvider MplususersDataProvider, IValidator<MplususersDto> validator, IPasswordHasher<MplususersDto> passwordHasher, IValidator<UserLogin> loginvalidator, JwtTokenService jwtService, IConfiguration configuration)
        {
            _IMplususersDataProvider = MplususersDataProvider;
            _validator = validator;
            _passwordHasher = passwordHasher;
            _loginvalidator = loginvalidator;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        public async Task<OperationResult<MplususersDto>> CreateUserAsync(MplususersDto mplususersDto)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(mplususersDto);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ", validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
                    return OperationResult<MplususersDto>.Fail($"Validation failed: {errors}");
                }
                #region Hash password
                mplususersDto.PasswordHash =_passwordHasher.HashPassword(mplususersDto, mplususersDto.Password);
                mplususersDto.Password = string.Empty;
                #endregion
                var isCreated = await _IMplususersDataProvider.CreateUserAsync(mplususersDto);
                if (!isCreated)
                    return OperationResult<MplususersDto>.Fail("Database operation failed: No rows affected");

                return OperationResult<MplususersDto>.Ok(mplususersDto, "User created successfully");
            }
            catch (DbUpdateException dbEx)
            {
                return OperationResult<MplususersDto>.Fail($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                return OperationResult<MplususersDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<LoginResponseDto>> UserLoginAsync(UserLogin userLogin)
        {
            try
            {
                // 1️⃣ Validate request
                var validationResult = await _loginvalidator.ValidateAsync(userLogin);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join(", ",
                        validationResult.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));

                    return OperationResult<LoginResponseDto>.Fail($"Validation failed: {errors}");
                }
                var user = await _IMplususersDataProvider.UserLoginAsync(userLogin);
                if (user == null)
                    return OperationResult<LoginResponseDto>.Fail("Invalid username or password");
                var passwordResult = _passwordHasher.VerifyHashedPassword(user,user.PasswordHash,userLogin.Password);

                if (passwordResult != PasswordVerificationResult.Success)
                    return OperationResult<LoginResponseDto>.Fail("Invalid username or password");
                var token = _jwtService.GenerateJwtToken(user);
                //var menus = await _IMplususersDataProvider.GetMenusByRoleAsync(user.Role);
                var menus = await _IMplususersDataProvider.GetMenusByRoleOrEmployeeAsync(user.Role,user.UserId);
                var response = new LoginResponseDto
                {
                    Token = token,
                    TokenType= "Bearer",
                    ExpiresAt = DateTime.UtcNow.AddMinutes(
                        Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])
                    ),
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Role = user.Role,
                    RoleName = user.RoleName,
                    ParentMenus = menus
                };

                return OperationResult<LoginResponseDto>.Ok(response, "Login successful");
            }
            catch (Exception ex)
            {
                return OperationResult<LoginResponseDto>.Fail($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<OperationResult<List<MplususersDto>>> GetUsersAsync()
        {
            var companies = await _IMplususersDataProvider.GetUsersAsync();
            return OperationResult<List<MplususersDto>>.Ok(companies, "User list fetched successfully");
        }
        public async Task<OperationResult<MplususersDto>> GetUserByIdAsync(long Id)
        {
            var user = await _IMplususersDataProvider.GetUserByIdAsync(Id);
            if (user == null)
                return OperationResult<MplususersDto>.Fail("User not found");

            return OperationResult<MplususersDto>.Ok(user, "User fetched successfully");
        }
        public async Task<OperationResult<bool>> DeleteUserAsync(long RoleId)
        {
            var deleted = await _IMplususersDataProvider.DeleteUserAsync(RoleId);
            if (!deleted)
                return OperationResult<bool>.Fail("User not found");

            return OperationResult<bool>.Ok(true, "User deleted successfully");
        }
    }
}
