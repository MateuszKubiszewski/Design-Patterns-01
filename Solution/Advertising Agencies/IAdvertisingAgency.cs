using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.AdvertisingAgencies
{
    interface IAdvertisingAgency
    {
        IOffer CreatePermanentOffer();
        IOffer CreateTemporaryOffer();
    }
}
