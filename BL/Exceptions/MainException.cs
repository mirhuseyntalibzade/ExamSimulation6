using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    public class MainException : Exception
    {
        public MainException(string mes) : base(mes)
        {
            
        }
        public MainException():base("Something went wrong")
        {
            
        }
    }

}
