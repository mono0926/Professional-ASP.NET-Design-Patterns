using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer 
    {    
        private static readonly Hashtable _libraryDataContexts = new Hashtable();

        public LibraryDataContext GetDataContext()
        {
            LibraryDataContext libraryDataContext = null;

            if (_libraryDataContexts.Contains(GetThreadName()))
                libraryDataContext = (LibraryDataContext)_libraryDataContexts[GetThreadName()];           

            return libraryDataContext;
        }

        public void Store(LibraryDataContext libraryDataContext)
        {
            if (_libraryDataContexts.Contains(GetThreadName()))
                _libraryDataContexts[GetThreadName()] = libraryDataContext;
            else
                _libraryDataContexts.Add(GetThreadName(), libraryDataContext);           
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }     
    }
}
