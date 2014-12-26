using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPPatterns.Chap2.Service; 

namespace ASPPatterns.Chap2.Tests.Mocks
{
    public class MockCacheStorage : ICacheStorage 
    {
        private int _retrievedFromCacheCount = 0;
        private Dictionary<string, object> _cacheStorage = new Dictionary<string, object>(); 

        public int RetrievedFromCacheCount()
        {
            return _retrievedFromCacheCount;
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object data)
        {
            if (_cacheStorage.ContainsKey(key))
            {
                _cacheStorage[key] = data;
            }
            else 
            {
                _cacheStorage.Add(key, data);
            }
        }

        public T Retrieve<T>(string key)
        {
            if (_cacheStorage.ContainsKey(key))
            {
                _retrievedFromCacheCount++;
                return (T)_cacheStorage[key];
            }
            else
            {
                return default(T);
            }
        }        
    }
}
