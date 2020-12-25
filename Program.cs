using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBotBase
{
    class Program
    {
        public static Bot Bot { get; internal set; }
        static Task Main(string[] args)
            => (Bot = new()).Initialize();
    }
}
