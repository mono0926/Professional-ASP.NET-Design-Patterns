using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap7.Library.Services.Views;
using ASPPatterns.Chap7.Library.Model;

namespace ASPPatterns.Chap7.Library.Services.Mappers
{
    public static class MemberExtensionMethods
    {
        public static MemberView ConvertToMemberView(this Member member)
        {
            return new MemberView
            {
                FullName = member.FirstName + ' ' + member.LastName,
                MemberId = member.Id.ToString(),
                Loans = GenerateLoanViewsFrom(member.Loans)                  
            };
        }

        private static IList<LoanView> GenerateLoanViewsFrom(IEnumerable<Loan> loans)
        {
            if (loans == null)
                return new List<LoanView>();
            else
                return loans.ConvertToLoanViews();
        }

        public static IList<MemberView> ConvertToMemberViews(this IEnumerable<Member> members)
        {
            IList<MemberView> memberViews = new List<MemberView>();
            foreach (Member member in members)
            {
                memberViews.Add(member.ConvertToMemberView());
            }

            return memberViews;
        }
    }
}
