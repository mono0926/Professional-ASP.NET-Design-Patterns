using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer 
    {
        private string _dataContextKey = "DataContext";
        
        public LibraryDataContext GetDataContext()
        {
            LibraryDataContext objectContext = null;
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                objectContext = (LibraryDataContext)HttpContext.Current.Items[_dataContextKey];

            return objectContext;
        }

        public void Store(LibraryDataContext libraryDataContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                HttpContext.Current.Items[_dataContextKey] = libraryDataContext;
            else
                HttpContext.Current.Items.Add(_dataContextKey, libraryDataContext);  
        }

    }
}
