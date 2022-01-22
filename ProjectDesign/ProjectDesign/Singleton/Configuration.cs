using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Configuration
    {
        private static Configuration _instance = null;
        private static object _instanceLock = new object();
        public string StringProperty { get; set; }
        public int IntProperty { get; set; }

        private Configuration() // prywatne żeby nie można tego używać poza klasą
        {

        }
        public static Configuration GetInstance() // możliwe, że singleton będzie kilka razy nullem ze względu na ewentualną wielowątkowość, można użyć semaforów *flushed*
        {
            lock (_instanceLock) // fajne
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }
            }

            return _instance;
        }
    }
}
