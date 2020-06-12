using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Codecs
{
    class PushCodec : Codec
    {
        public PushCodec(int parameter) : base(parameter) { }

        public override string Decrypt(string todo)
        {
            string ret = "";
            int sum = todo.Count();
            int change;
            if (n < 0)
                change = Math.Abs(sum - Math.Abs(n));
            else
                change = n;
            int index;
            for (int i = 0; i < sum; i++)
            {
                index = i + change;
                while (index >= sum)
                    index -= sum;
                ret += todo[index];
            }
            return ret;
        }

        public override string Encrypt(string todo)
        {
            string ret = "";
            int sum = todo.Count();
            int change;
            if (n < 0)
                change = Math.Abs(n);
            else
                change = Math.Abs(sum - n);
            int index;
            for (int i = 0; i < sum; i++)
            {
                index = i + change;
                while (index >= sum)
                    index -= sum;
                ret += todo[index];
            }
            return ret;
        }
    }
}
