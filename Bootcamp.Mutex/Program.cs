using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bootcamp.Mutextest
{
    class Program
    {
        static Mutex mutex = new Mutex(false, "cat");
        static void Main(string[] args)
        {
            // Check to see if there is another instance. allow 5 seconds to allow the other instance to exit.
            if (!mutex.WaitOne(TimeSpan.FromSeconds(5)))
            {
                Console.WriteLine("I'm already running.  Exiting....");
                //Console.ReadKey();
                return;
            }
            try
            {
                Console.WriteLine("MutexTest started");
                Console.ReadKey();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
