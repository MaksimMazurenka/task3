using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Values
    {
        private static int size;
        private static string[] arguments;
        private static int half;
        public Values(string[] args)
        {
            size = args.Length;
            arguments = args;
            half = size / 2;
        }
        public Values()
        {
            
        }
        public int Size
        {
            get => size;
        }
        public int Half
        {
            get => half;
        }
        public string[] Arguments
        {
            get => arguments;
        }
    }
}
