using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Api
{
    public static class StringExtensions
    {
        public static string ToCleanToken(this string value)
        {
            return value.Replace("Bearer ", "");
        }
    }
}
