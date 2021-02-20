using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.Validators
{
    public interface IValidator
    {
        bool Match(string str, string conf);
        bool StartWithNumeral(string str);
        bool HasUpLowNum(string str);
        bool InRange(string str, int min, int max);

    }
}
