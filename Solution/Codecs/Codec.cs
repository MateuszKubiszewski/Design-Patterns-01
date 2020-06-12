using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Codecs
{
    abstract class Codec
    {
        protected int n;

        public Codec(int parameter)
        {
            n = parameter;
        }

        public abstract string Encrypt(string todo);

        public abstract string Decrypt(string todo);
    }
}
