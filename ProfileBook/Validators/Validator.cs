using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProfileBook.Validators
{
    public class Validator : IValidator
    {
        public bool Match(string str, string con)
        {
            return str.Equals(con);
        }

        public bool HasUpLowNum(string str)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperCase = new Regex(@"[A-Z]+");
            var hasLowerCase = new Regex(@"[a-z]+");

            return hasNumber.IsMatch(str) && hasUpperCase.IsMatch(str) && hasLowerCase.IsMatch(str);
        }

        public bool InRange(string str, int min, int max)
        {
            return str.Length >= min  && str.Length <= max;
        }

        public bool StartWithNumeral(string str)
        {
            var hasNumber = new Regex(@"^[0-9]");

            return hasNumber.IsMatch(str);
        }


    }
}
