using System;
using System.Collections.Generic;
using System.Text;

namespace HabitsBot
{
    public static class Host<T> where T: StartupBase
    {
        public static void Run()
        {
            T startup = (T)Activator.CreateInstance(typeof(T));

            startup.RunApplication();
        }
    }
}
