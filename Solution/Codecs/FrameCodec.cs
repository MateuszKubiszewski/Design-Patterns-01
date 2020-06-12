using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Codecs
{
    class FrameCodec : Codec
    {
        string left;
        string right;

        public FrameCodec(int parameter) : base(parameter)
        {
            left = "";
            for (int i = 1; i <= parameter; i++)
            {
                left += i.ToString();
            }
            right = "";
            for (int i = left.Length - 1; i > -1; i--)
            {
                right += left[i];
            }
        }

        public override string Decrypt(string todo)
        {
            string ret;
            ret = todo.Substring(n);
            ret = ret.Remove(ret.Count() - n);
            return ret;
        }

        public override string Encrypt(string todo)
        {
            string ret = todo;
            ret = ret.Insert(0, left);
            ret += right;
            return ret;
        }
    }
}
