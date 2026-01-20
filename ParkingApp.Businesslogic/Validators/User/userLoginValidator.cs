using ParkingApp.Infrastructure.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingApp.Businesslogic.Validators.User
{
    public class userLoginValidator: BaseValidator<UserLogin>
    {
        public userLoginValidator()
        {
            NotEmptyRule(x => x.UserName, "User Name");
            MaxLengthRule(x => x.UserName, 15, "User Name");
            NotEmptyRule(x => x.Password, "Password");
        }
    }
}
