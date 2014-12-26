using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap7.Library.Repository.EF;
using ASPPatterns.Chap7.Library.Services.Messages;
using ASPPatterns.Chap7.Library.Services.Views;
using ASPPatterns.Chap7.Library.Services;

using ASPPatterns.Chap7.Library.Model;

namespace ASPPatterns.Chap7.Library.UI.Web
{
    public partial class MemberDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string memberId = Request.QueryString["Id"];
                string copyToReturnId = "";
                string copyToLoanId=  "";
                
                if (Request.QueryString.AllKeys.FirstOrDefault(s => s == "CopyIdToReturn") != null)
                    copyToReturnId = Request.QueryString["CopyIdToReturn"];

                if (Request.QueryString.AllKeys.FirstOrDefault(s => s == "CopyToLoanId") != null)
                    copyToLoanId = Request.QueryString["CopyToLoanId"];

                if (copyToLoanId != "")
                    LoanBook(new Guid(copyToLoanId));

                if (copyToReturnId != "")
                    ReturnBook(new Guid(copyToReturnId));
                
                DisplayMember(new Guid(memberId));
                DisplayBooks();
            }
        }

        private void LoanBook(Guid copyId)
        {
            LibraryService service = ServiceFactory.CreateLibraryService();
            LoanBookRequest request = new LoanBookRequest();
            LoanBookResponse response;
            request.CopyId = copyId.ToString() ;
            request.MemberId = Request.QueryString["Id"];

            response = service.LoanBook(request);            
        }

        private void ReturnBook(Guid copyId)
        {
            LibraryService service = ServiceFactory.CreateLibraryService();
            ReturnBookRequest request = new ReturnBookRequest();

            request.CopyId = copyId.ToString();

            service.ReturnBook(request);
        }

        private void DisplayMember(Guid Id)
        {
            LibraryService service = ServiceFactory.CreateLibraryService();
            FindMemberRequest request = new FindMemberRequest { MemberId = Id.ToString() };
            FindMembersResponse response = service.FindMembers(request);

            if (response.Success)
            {
                litName.Text = response.MembersFound.First().FullName;
                rptLoans.DataSource = response.MembersFound.First().Loans.OrderBy(l => l.LoanDate);  
                rptLoans.DataBind();
            }                                 
        }


        private void DisplayBooks()
        {
            LibraryService service = ServiceFactory.CreateLibraryService();
            FindBooksRequest request = new FindBooksRequest();
            request.All = true;
            FindBooksResponse response = service.FindBooks(request);

            this.rptBooks.DataSource = response.Books;
            rptBooks.DataBind(); 
 
        }
        
        public string DisplayLoanStatus(LoanView loan)
        {
            if (loan.StillOutOnLoan)
                return String.Format(@"due back on {0} <a href=""Memberdetail.aspx?CopyIdToReturn={1}&Id={2}"">return?</a>",loan.DateForReturn, loan.CopyId, loan.MemberId);
            else
                return "returned on " + loan.ReturnDate; 

        }

        public string LoanStatus(BookView book)
        {
            if (!String.IsNullOrEmpty(book.OnLoanTo))
                return "On loan to " + book.OnLoanTo;
            else
                return String.Format(@"<a href=""MemberDetail.aspx?Id={0}&CopyToLoanId={1}"">Loan?</a>", Request.QueryString["Id"], book.Id);
        }
    }
}