using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Codecs
{
    //increase digits by n mod10 (the digit must remain a digit), where n is arbitrary.
    class CesarCodec : Codec
    {
        int change;

        public CesarCodec(int parameter) : base(parameter)
        {
            change = parameter % 10;
        }

        public override string Decrypt(string todo)
        {
            string toReturn = "";
            foreach (var digit in todo)
            {
                int val = (int)Char.GetNumericValue(digit);
                val -= change;
                if (val >= 10)
                    val -= 10;
                if (val < 0)
                    val += 10;
                toReturn += val.ToString();
            }
            return toReturn;
        }

        public override string Encrypt(string todo)
        {
            string toReturn = "";
            foreach(var digit in todo)
            {
                int val = (int)Char.GetNumericValue(digit);
                val += change;
                if (val >= 10)
                    val -= 10;
                if (val < 0)
                    val += 10;
                toReturn += val.ToString();
            }
            return toReturn;
        }
    }
}
