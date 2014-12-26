using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap4.AnemicModel.AppService;
using ASPPatterns.Chap4.AnemicModel.AppService.Messages;

namespace ASPPatterns.Chap4.AnemicModel.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ShowAllAccounts();
        }

        private void ShowAllAccounts()
        {
            ddlBankAccounts.Items.Clear();  

            FindAllBankAccountResponse response = new ApplicationBankAccountService().GetAllBankAccounts();
            ddlBankAccounts.Items.Add(new ListItem("Select An Account", ""));

            foreach (BankAccountView accView in response.BankAccountView)
            {
                ddlBankAccounts.Items.Add(new ListItem(accView.CustomerRef, accView.AccountNo.ToString()));
            }
        }

        protected void btCreateAccount_Click(object sender, EventArgs e)
        {
            BankAccountCreateRequest createAccountRequest = new BankAccountCreateRequest();
            createAccountRequest.CustomerName = this.txtCustomerRef.Text;           
            ApplicationBankAccountService service = new ApplicationBankAccountService();

            service.CreateBankAccount(createAccountRequest);   
         
            ShowAllAccounts();
        }

        protected void ddlBankAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySelectedAccount();
        }

        private void DisplaySelectedAccount()
        {
            if (ddlBankAccounts.SelectedValue.ToString() != "")
            {
                ApplicationBankAccountService service = new ApplicationBankAccountService();
                FindBankAccountResponse response = service.GetBankAccountBy(new Guid(ddlBankAccounts.SelectedValue.ToString()));
                BankAccountView accView = response.BankAccount;

                this.lblAccountNo.Text = accView.Balance.ToString();
                this.lblBalance.Text = accView.Balance.ToString();
                this.lblCustomerRef.Text = accView.CustomerRef;

                rptTransactions.DataSource = accView.Transactions;
                rptTransactions.DataBind();

                FindAllBankAccountResponse allAccountsResponse = service.GetAllBankAccounts();

                ddlBankAccountsToTransferTo.Items.Clear();

                foreach (BankAccountView acc in allAccountsResponse.BankAccountView)
                {
                    if (acc.AccountNo.ToString() != ddlBankAccounts.SelectedValue.ToString())
                        ddlBankAccountsToTransferTo.Items.Add(new ListItem(acc.CustomerRef, acc.AccountNo.ToString()));
                }
            }
        }

        protected void btnWithdrawal_Click(object sender, EventArgs e)
        {
            ApplicationBankAccountService service = new ApplicationBankAccountService();
            WithdrawalRequest request = new WithdrawalRequest();
            Guid AccId = new Guid(ddlBankAccounts.SelectedValue.ToString());
            request.AccountId = AccId;
            request.Amount = Decimal.Parse(txtAmount.Text);

            service.Withdrawal(request);
            DisplaySelectedAccount();
        }

        protected void btnDeposit_Click(object sender, EventArgs e)
        {
            ApplicationBankAccountService service = new ApplicationBankAccountService();
            DepositRequest request = new DepositRequest(); 
            Guid AccId = new Guid(ddlBankAccounts.SelectedValue.ToString());
            request.AccountId = AccId;
            request.Amount = Decimal.Parse(txtAmount.Text);

            service.Deposit(request);
            DisplaySelectedAccount();
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            ApplicationBankAccountService service = new ApplicationBankAccountService();
            TransferRequest request = new TransferRequest();            
            request.AccountIdFrom = new Guid(ddlBankAccounts.SelectedValue.ToString());
            request.AccountIdTo = new Guid(ddlBankAccountsToTransferTo.SelectedValue.ToString());
            request.Amount = Decimal.Parse(txtAmountToTransfer.Text);

            service.Transfer(request);
            DisplaySelectedAccount();
            
        }
    }
}
