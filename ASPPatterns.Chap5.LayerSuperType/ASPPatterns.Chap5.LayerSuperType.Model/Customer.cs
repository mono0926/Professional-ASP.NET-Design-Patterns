using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap5.LayerSuperType.Model
{
    public class Customer : EntityBase<long>
    {
        public Customer() { }

        public Customer(long Id)
            : base(Id)
        { }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected override void CheckForBrokenRules()
        {
            if (String.IsNullOrEmpty(FirstName))
                base.AddBrokenRule("You must supply a first name.");

            if (String.IsNullOrEmpty(LastName))
                base.AddBrokenRule("You must supply a last name.");
        }
    }
}
