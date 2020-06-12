using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Codecs
{
    class ReverseCodec : Codec
    {
        public ReverseCodec(int parameter) : base(parameter) { }

        public override string Decrypt(string todo)
        {
            string ret = "";
            for (int i = todo.Length - 1; i > -1; i--)
            {
                ret += todo[i];
            }
            return ret;
        }

        public override string Encrypt(string todo)
        {
            string ret = "";
            for (int i = todo.Length - 1; i > -1; i--)
            {
                ret += todo[i];
            }
            return ret;
        }
    }
}
