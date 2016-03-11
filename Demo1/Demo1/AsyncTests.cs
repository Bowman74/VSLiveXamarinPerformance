using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    public class AsyncTests
    {
        private static async Task DoLongRunningMethod(string prompt, int length)
        {
            await Task.Delay(new TimeSpan(0, 0, 0, length));

        }
    }
}
