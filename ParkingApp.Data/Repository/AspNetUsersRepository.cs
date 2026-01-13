
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using ParkingApp.Data.Infrastructure;
using ParkingApp.Data.Entities;

namespace ParkingApp.Data.Repository
{
	public partial class AspNetUsersRepository : BaseRepository, IAspNetUsersRepository
	{
		public AspNetUsersRepository(IConnectionFactory connectionFactory) : base(connectionFactory) { }
		
		#region Select One
		/// <summary>
		/// Get data according to the primary key value.
		/// </summary>
		/// <param name="id">string</param>
		public async Task<AspNetUsers> Get(string id)
		{
			using (var connection = connectionFactory.GetConnection)
			{
				var sql ="""
				SELECT
				"Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
				FROM "AspNetUsers"
				WHERE "Id" = @Id;
				""";
				var data = await connection.QuerySingleOrDefaultAsync<AspNetUsers>(sql, new  {id});
				connection.Close();
				return data;
			}
		}
		#endregion
		
		#region Search
		public async Task<IEnumerable<AspNetUsers>> Search()
		{
			using (var connection = connectionFactory.GetConnection)
			{
				var sql ="""
				SELECT
				"Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
				FROM "AspNetUsers";
				""";
				var data = await connection.QueryAsync<AspNetUsers>(sql);
				connection.Close();
				return data;
			}
		}
		public async Task<IEnumerable<AspNetUsers>> Search(int pageNumber , int pageSize)
		{
			using (var connection = connectionFactory.GetConnection)
			{
				var sql ="""
				SELECT
				"Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
				FROM "AspNetUsers"
				LIMIT @pageSize OFFSET (@pageNumber  - 1) * @pageSize;
				""";
				var data = await connection.QueryAsync<AspNetUsers>(sql,new { pageNumber,pageSize });
				connection.Close();
				return data;
			}
		}
		public async Task<IEnumerable<AspNetUsers>> Search(int pageNumber, int pageSize,string sortBy, string orderBy)
		{
			using (var connection = connectionFactory.GetConnection)
			{
				var sql =$"""
				SELECT
				"Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
				FROM "AspNetUsers"
				ORDER BY "{sortBy}" {orderBy}
				LIMIT @pageSize OFFSET (@pageNumber  - 1) * @pageSize;
				""";
				var data = await connection.QueryAsync<AspNetUsers>(sql,new { pageNumber, pageSize, sortBy, orderBy });
				connection.Close();
				return data;
			}
		}
		public async Task<IEnumerable<AspNetUsers>> Search(int pageNumber, int pageSize,string sortBy, string orderBy, string searchstring)
		{
			using (var connection = connectionFactory.GetConnection)
			{
				var sql =$"""
				SELECT
				"Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
				FROM "AspNetUsers"
				WHERE
				"Id" LIKE '%' || @searchstring || '%' OR
				"UserName" LIKE '%' || @searchstring || '%' OR
				"NormalizedUserName" LIKE '%' || @searchstring || '%' OR
				"Email" LIKE '%' || @searchstring || '%' OR
				"NormalizedEmail" LIKE '%' || @searchstring || '%' OR
				"PasswordHash" LIKE '%' || @searchstring || '%' OR
				"SecurityStamp" LIKE '%' || @searchstring || '%' OR
				"ConcurrencyStamp" LIKE '%' || @searchstring || '%' OR
				"PhoneNumber" LIKE '%' || @searchstring || '%'
				
				ORDER BY "{sortBy}" {orderBy}
				LIMIT @pageSize OFFSET (@pageNumber  - 1) * @pageSize;
				""";
				var data = await connection.QueryAsync<AspNetUsers>(sql,new { pageNumber, pageSize, searchstring });
				connection.Close();
				return data;
			}
		}
		#endregion
		
		#region INSERT
		/// <summary>
		/// Insert current AspNetUsers to database.
		/// </summary>
		/// <param name=AspNetUsers Objects>AspNetUsers</param>
		public async Task<int> Insert(AspNetUsers model)
		{
			try
			{
				using (var connection = connectionFactory.GetConnection)
				{
					var sql ="""
					INSERT INTO AspNetUsers
					("UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount")
					VALUES
					(@userName,@normalizedUserName,@email,@normalizedEmail,@emailConfirmed,@passwordHash,@securityStamp,@concurrencyStamp,@phoneNumber,@phoneNumberConfirmed,@twoFactorEnabled,@lockoutEnd,@lockoutEnabled,@accessFailedCount);
					""";
					var param = new {
					userName = model.UserName,
					normalizedUserName = model.NormalizedUserName,
					email = model.Email,
					normalizedEmail = model.NormalizedEmail,
					emailConfirmed = model.EmailConfirmed,
					passwordHash = model.PasswordHash,
					securityStamp = model.SecurityStamp,
					concurrencyStamp = model.ConcurrencyStamp,
					phoneNumber = model.PhoneNumber,
					phoneNumberConfirmed = model.PhoneNumberConfirmed,
					twoFactorEnabled = model.TwoFactorEnabled,
					lockoutEnd = model.LockoutEnd,
					lockoutEnabled = model.LockoutEnabled,
					accessFailedCount = model.AccessFailedCount
					};
					var objs = await connection.ExecuteAsync(sql, param);
					connection.Close();
					return objs;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
		#endregion
		
		#region UPDATE
		/// <summary>
		/// Update current AspNetUsers to database.
		/// </summary>
		/// <param name="id">string</param>
		public async Task<int> Update(AspNetUsers model,string id)
		{
			try
			{
				using (var connection = connectionFactory.GetConnection)
				{
					var sql ="""
					UPDATE AspNetUsers
					SET "UserName" = @userName,"NormalizedUserName" = @normalizedUserName,"Email" = @email,"NormalizedEmail" = @normalizedEmail,"EmailConfirmed" = @emailConfirmed,"PasswordHash" = @passwordHash,"SecurityStamp" = @securityStamp,"ConcurrencyStamp" = @concurrencyStamp,"PhoneNumber" = @phoneNumber,"PhoneNumberConfirmed" = @phoneNumberConfirmed,"TwoFactorEnabled" = @twoFactorEnabled,"LockoutEnd" = @lockoutEnd,"LockoutEnabled" = @lockoutEnabled,"AccessFailedCount" = @accessFailedCount
					WHERE Id = @id;
					""";
					var param = new {
					userName = model.UserName,
					normalizedUserName = model.NormalizedUserName,
					email = model.Email,
					normalizedEmail = model.NormalizedEmail,
					emailConfirmed = model.EmailConfirmed,
					passwordHash = model.PasswordHash,
					securityStamp = model.SecurityStamp,
					concurrencyStamp = model.ConcurrencyStamp,
					phoneNumber = model.PhoneNumber,
					phoneNumberConfirmed = model.PhoneNumberConfirmed,
					twoFactorEnabled = model.TwoFactorEnabled,
					lockoutEnd = model.LockoutEnd,
					lockoutEnabled = model.LockoutEnabled,
					accessFailedCount = model.AccessFailedCount,
					Id = id
					};
					var objs = await connection.ExecuteAsync(sql, param);
					connection.Close();
					return objs;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
		#endregion
		
		#region DELETE
		/// <summary>
		/// Delete current AspNetUsers from database.
		/// </summary>
		/// <param name="id">string</param>
		public async Task<int> Delete(string id)
		{
			using (var connection = connectionFactory.GetConnection)
			{
				var sql ="""
				DELETE FROM AspNetUsers WHERE "Id"=@id;
				""";
				var param = new {
				Id = id
				};
				var obj = await connection.ExecuteAsync(sql, param);
				connection.Close();
				return obj;
			}
		}
		#endregion
		
		
	}
}

