using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Agathas.Storefront.Model.Customers
{
    public class EmailValidationSpecification
    {
        private static Regex _emailregex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

        public bool IsSatisfiedBy(string email)
        {            
            return _emailregex.IsMatch(email);
        }
    }

}
