using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autoserv
{
    public static class Utils
    {
        public static bool CheckFIO(string str)
        {
            if (str.Length > 50) return false;
            Regex r = new Regex(@"^[^0-9][^!@#$%^№&*()_]"); // Соответствует любая цифра, восклицательный знак, решётка или буква h. Если нужны только цифры, то @"\d".
            Match m = r.Match(str);
            if (m.Success) return true;
            return false;

        }

        public static bool CheckEmail(string emailaddress)
        {
            try
            {
                if (emailaddress.Length > 0)
                {
                    MailAddress m = new MailAddress(emailaddress);
                }
                else return false;

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
