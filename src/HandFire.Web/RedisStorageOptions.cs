using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandFire.Web
{
    public class RedisStorageOptions
    {
        public const string DefaultPrefix = "{hangfire}:";

        public RedisStorageOptions()
        { }

        public TimeSpan InvisibilityTimeout { get; set; }
        public TimeSpan FetchTimeout { get; set; }
        public string Prefix { get; set; }
        public int Db { get; set; }
        public int SucceededListSize { get; set; }
        public int DeletedListSize { get; set; }
    }
}
