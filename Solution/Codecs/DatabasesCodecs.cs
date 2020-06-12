using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Codecs
{
    interface DatabaseCodec
    {
        string Encrypt(string tocode);
        string Decrypt(string todecode);
        //Check method will throw exception if the decrypted string will be unequal to encrypted one after encryption. It's only to indicate that
        //there is a mistake somewhere in the implementation of one of the Codec classes [if they are implemented correctly, Check will always return true].
        void Check(string decrypted, string encrypted);
    }
    //BookingDatabase: FrameCodec (n = 2) -> ReverseCodec -> CezarCodec (n = -1) -> SwapCodec
    public class BookingCodec : DatabaseCodec
    {
        FrameCodec FrameCodec;
        ReverseCodec ReverseCodec;
        CesarCodec CesarCodec;
        SwapCodec SwapCodec;

        public BookingCodec()
        {
            FrameCodec = new FrameCodec(2);
            ReverseCodec = new ReverseCodec(0);
            CesarCodec = new CesarCodec(-1);
            SwapCodec = new SwapCodec(0);
        }

        public string Decrypt(string todecode)
        {
            string ret;
            ret = FrameCodec.Decrypt(ReverseCodec.Decrypt(CesarCodec.Decrypt(SwapCodec.Decrypt(todecode))));
            Check(ret, todecode);
            return ret;
        }

        public string Encrypt(string tocode)
        {
            string ret;
            ret = SwapCodec.Encrypt(CesarCodec.Encrypt(ReverseCodec.Encrypt(FrameCodec.Encrypt(tocode))));
            return ret;
        }

        public void Check(string decrypted, string encrypted)
        {
            string check = Encrypt(decrypted);
            if (check != encrypted)
                throw new NotImplementedException();
        }
    }
    //ShutterStockDatabase: CezarCodec(n = 4) -> FrameCodec(n = 1) -> PushCodec(n = -3) -> ReverseCodec
    public class ShutterStockCodec : DatabaseCodec
    {
        FrameCodec FrameCodec;
        ReverseCodec ReverseCodec;
        CesarCodec CesarCodec;
        PushCodec PushCodec;

        public ShutterStockCodec()
        {
            FrameCodec = new FrameCodec(1);
            ReverseCodec = new ReverseCodec(0);
            CesarCodec = new CesarCodec(4);
            PushCodec = new PushCodec(-3);
        }

        public string Decrypt(string todecode)
        {
            string ret;
            ret = CesarCodec.Decrypt(FrameCodec.Decrypt(PushCodec.Decrypt(ReverseCodec.Decrypt(todecode))));
            Check(ret, todecode);
            return ret;
        }

        public string Encrypt(string tocode)
        {
            string ret;
            ret = ReverseCodec.Encrypt(PushCodec.Encrypt(FrameCodec.Encrypt(CesarCodec.Encrypt(tocode))));
            return ret;
        }

        public void Check(string decrypted, string encrypted)
        {
            string check = Encrypt(decrypted);
            if (check != encrypted)
                throw new NotImplementedException();
        }
    }
    //TripAdvisorDatabase: PushCodec (n = 3) -> FrameCodec (n = 2) -> SwapCodec -> PushCodec (n = 3)
    public class TripAdvisorCodec : DatabaseCodec
    {
        FrameCodec FrameCodec;
        SwapCodec SwapCodec;
        PushCodec PushCodec;

        public TripAdvisorCodec()
        {
            FrameCodec = new FrameCodec(2);
            SwapCodec = new SwapCodec(0);
            PushCodec = new PushCodec(3);
        }

        public string Decrypt(string todecode)
        {
            string ret;
            ret = PushCodec.Decrypt(FrameCodec.Decrypt(SwapCodec.Decrypt(PushCodec.Decrypt(todecode))));
            Check(ret, todecode);
            return ret;
        }

        public string Encrypt(string tocode)
        {
            string ret;
            ret = PushCodec.Encrypt(SwapCodec.Encrypt(FrameCodec.Encrypt(PushCodec.Encrypt(tocode))));
            return ret;
        }

        public void Check(string decrypted, string encrypted)
        {
            string check = Encrypt(decrypted);
            if (check != encrypted)
                throw new NotImplementedException();
        }
    }
}
