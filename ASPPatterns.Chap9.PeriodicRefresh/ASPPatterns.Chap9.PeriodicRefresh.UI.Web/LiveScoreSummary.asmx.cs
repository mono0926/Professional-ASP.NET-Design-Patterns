using System.Collections.Generic;
using System.Web.Services;
using ASPPatterns.Chap9.PeriodicRefresh.Model;
using ASPPatterns.Chap9.PeriodicRefresh.Repository;

namespace ASPPatterns.Chap9.PeriodicRefresh.UI.Web
{
    /// <summary>
    /// Summary description for LiveScoreSummary1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LiveScoreSummary : System.Web.Services.WebService
    {
        private static IEventRepository _eventRepository;
        // Add  attribute to use HTTP GET  

        public static void SetUpEventData()
        {
            _eventRepository = new EventRepository();
        }

        [WebMethod]        
        public IEnumerable<Event> GetEventsThatHaveOccuredSince(int eventId)
        {
            return _eventRepository.FindAllSince(eventId);
        }        
    }
}
