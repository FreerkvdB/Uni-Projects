using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG281
{
    internal class InvalidOperationException : Exception
    {
        // Constructor that takes a message parameter
        public InvalidOperationException(string message) : base(message){}
      
    }
}