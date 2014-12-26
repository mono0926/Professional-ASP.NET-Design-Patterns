using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap4.TransactionScript.BLL;

namespace ASPPatterns.Chap4.TransactionScript.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                DisplayAllEmployees();
            else
                lblBookingResult.Text = "";
        }

        public void DisplayAllEmployees()
        {
            ddlEmployees.Items.Clear();
            ListItem selectAnEmployee = new ListItem("Select an employee...", "0");
            selectAnEmployee.Selected = true;
            this.ddlEmployees.Items.Add(selectAnEmployee);            

            foreach (EmployeeDTO emp in EmployeeService.GetAllEmployees())
            {
                ddlEmployees.Items.Add(new ListItem(emp.Name, emp.Id.ToString()));
            }                        
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            EmployeeService.CreateEmployee(this.txtName.Text, int.Parse(this.txtEntitlement.Text));
            DisplayAllEmployees();
        }

        protected void ddlEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlEmployees.SelectedValue) != 0)
            {
                DisplayHolidayBookedFromEmployee();
            }

        }

        private void DisplayHolidayBookedFromEmployee()
        {
            rptHolidaysBooked.DataSource = HolidayService.GetBookedLeaveFor(int.Parse(ddlEmployees.SelectedValue));
            rptHolidaysBooked.DataBind();
        }

        protected void btnBookHoliday_Click(object sender, EventArgs e)
        {
            if (int.Parse(ddlEmployees.SelectedValue) != 0)
            {
                DateTime from = this.calFrom.SelectedDate;
                DateTime to = this.calTo.SelectedDate;

                Boolean bookingResult = HolidayService.BookHolidayFor(int.Parse(ddlEmployees.SelectedValue), from, to);

                if (bookingResult)
                {
                    lblBookingResult.Text = "Holiday booked for " + ddlEmployees.SelectedItem.Text + " for " + from.ToShortDateString() + " to " + to.ToShortDateString();
                    DisplayHolidayBookedFromEmployee();
                }
                else
                    lblBookingResult.Text = "Unable to book holiday for " + ddlEmployees.SelectedItem.Text + " for " + from.ToShortDateString() + " to " + to.ToShortDateString();
            }
        }

    }
}
