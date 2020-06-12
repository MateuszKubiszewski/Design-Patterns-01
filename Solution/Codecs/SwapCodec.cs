using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Codecs
{
    class SwapCodec : Codec
    {
        public SwapCodec(int parameter) : base(parameter) { }

        public override string Decrypt(string todo)
        {
            string ret = "";
            for (int i = 1; i < todo.Count(); i += 2)
            {
                ret += todo[i];
                ret += todo[i - 1];            
            }
            if (todo.Length % 2 == 1)
                ret += todo[todo.Length - 1];
            return ret;
        }

        public override string Encrypt(string todo)
        {
            string ret = "";
            for (int i = 1; i < todo.Count(); i += 2)
            {
                ret += todo[i];
                ret += todo[i - 1];              
            }
            if (todo.Length % 2 == 1)
                ret += todo[todo.Length - 1];
            return ret;
        }
    }
}
