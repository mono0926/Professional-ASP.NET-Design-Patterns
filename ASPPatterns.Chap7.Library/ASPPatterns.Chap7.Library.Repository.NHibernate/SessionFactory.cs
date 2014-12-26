using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Web;
using ASPPatterns.Chap7.Library.Repository.NHibernate.SessionStorage;

namespace ASPPatterns.Chap7.Library.Repository.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _SessionFactory;        

        private static void Init()
        {
            Configuration config = new Configuration();
            config.AddAssembly("ASPPatterns.Chap7.Library.Repository.NHibernate");

            log4net.Config.XmlConfigurator.Configure();
            
            config.Configure();

            _SessionFactory = config.BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_SessionFactory == null)
                Init();

            return _SessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer _sessionStorageContainer = SessionStorageFactory.GetStorageContainer();

            ISession currentSession = _sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                _sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }
    }
}
