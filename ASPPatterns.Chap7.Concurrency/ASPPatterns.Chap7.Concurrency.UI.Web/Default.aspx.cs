using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPPatterns.Chap7.Concurrency.Model;
using ASPPatterns.Chap7.Concurrency.Repository;

namespace ASPPatterns.Chap7.Concurrency.UI.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IPersonRepository personRepository = new PersonRepository(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\People.mdf;Integrated Security=True;User Instance=True");
            IEnumerable<Person> people = personRepository.FindAll();   

            foreach(Person person in people)
            {
                Response.Write(person.FirstName + " " + person.LastName + "<br/>");
            }
        }
    }
}
