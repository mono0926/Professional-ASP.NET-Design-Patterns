using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage;

namespace ASPPatterns.Chap7.Library.Repository.EF
{
    public class DataContextFactory
    {      
        public static LibraryDataContext GetDataContext()
        {
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer(); 

            LibraryDataContext libraryDataContext = _dataContextStorageContainer.GetDataContext();
            if (libraryDataContext == null)
            {
                libraryDataContext = new LibraryDataContext();
                _dataContextStorageContainer.Store(libraryDataContext);
            }

            return libraryDataContext;            
        }       
    }
}
