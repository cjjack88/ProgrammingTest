using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern_Singleton
{
    public class Singleton
    {
        // .NET guarantees thread safety for static initialization
        private static Singleton instance = null;
        private string Name { get; set; }
        private string IP { get; set; }

        private Singleton()
        {
            Name = "Server1";
            IP = "192.168.1.23";
        }

        // Lock synchronization object
        private static object syncLock = new object();

        public static Singleton Instance
        {
            get
            {
                // Support multithreaded applications through
                // 'Double checked locking' pattern which (once
                // the instance exists) avoids locking each
                // time the method is invoked
                lock (syncLock)
                {
                    if (Singleton.instance == null)
                        Singleton.instance = new Singleton();

                    return Singleton.instance;
                }
            }
        }

        public string Show()
        {
            return string.Format("Server Information is : Name={0} & IP={1}", IP, Name);
        }
    }
}
