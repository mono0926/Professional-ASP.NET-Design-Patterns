using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPPatterns.Chap7.Library.Repository.EF.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        LibraryDataContext GetDataContext();
        void Store(LibraryDataContext libraryDataContext);
    }
}
