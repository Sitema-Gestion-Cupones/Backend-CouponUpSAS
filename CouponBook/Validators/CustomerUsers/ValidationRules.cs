using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CouponBook.Services.CustomerUsers;

namespace CouponBook.Validators
{
    public class ValidationRules
    {
        public static bool BeAValidDate(DateOnly date)
        {
            var todayUtc = DateTime.UtcNow.Date;
            var todayDateOnly = new DateOnly(todayUtc.Year, todayUtc.Month, todayUtc.Day);

            return date >= new DateOnly(1900, 01, 01) && date <= todayDateOnly;
        }

        public static bool BeAtLeast18YearsOld(DateOnly date)
        {
            var todayUtc = DateTime.UtcNow.Date;
            var todayDateOnly = new DateOnly(todayUtc.Year, todayUtc.Month, todayUtc.Day);

            var age = todayDateOnly.Year - date.Year;
            if (date > todayDateOnly.AddYears(-age)) age--;

            // Validamos que la persona tenga al menos 18 años de edad
            return age > 18 || (age == 18 && (date.Month < todayDateOnly.Month || (date.Month == todayDateOnly.Month && date.Day <= todayDateOnly.Day)));
        }

        public static bool ContainUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        public static bool ContainLowerCase(string password)
        {
            return password.Any(char.IsLower);
        }

        public static bool ContainDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

        public static bool ContainSpecialCharacter(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        public static bool NoSpaces(string email)
        {
            return !email.Contains(" ");
        }

        // public static async Task<bool> BeUniqueEmail(string email, ICustomerUserService customerUserService)
        // {
        //     return !await customerUserService.EmailExistsAsync(email);
        // }
    }
}
