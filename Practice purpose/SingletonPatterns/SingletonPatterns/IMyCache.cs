using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatterns
{
    public interface IMyCache
    {
        bool Add(object key, object value);
        bool AddOrUpdate(object key, object value);
        bool Remove(object key);
        ConcurrentDictionary<object, object> GetAll();
    }
    }