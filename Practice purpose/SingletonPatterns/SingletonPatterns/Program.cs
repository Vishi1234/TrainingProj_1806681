using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatterns
{
    public sealed class SingleTonCache : IMyCache
    {
     
        private ConcurrentDictionary<object, object> cd = new ConcurrentDictionary<object, object>();

        private static readonly SingleTonCache singleobj = new SingleTonCache();

        private SingleTonCache()
        {
            Console.WriteLine("SingleTon Instance Created");
        }

      
        public static SingleTonCache GetInstance()
        {
            return singleobj;
        }

        public bool Add(object key, object value)
        {
            return cd.TryAdd(key, value);
        }


        public bool AddOrUpdate(object key, object value)
        {
            if (cd.ContainsKey(key))
            {
                cd.TryUpdate(key, "Sree", "Sowmya");
            }
            return cd.TryAdd(key, value);
        }

        public object Get(object key)
        {
            if (cd.ContainsKey(key))
            {
                return cd[key];
            }
            return null;
        }

        public bool Remove(object key)
        {
            return cd.TryRemove(key, out object removedval);
        }

        //one instance method
        public void Clear()
        {
            cd.Clear();
        }

        public ConcurrentDictionary<object, object> GetAll()
        {
            return cd;
        }


    }
}