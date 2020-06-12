using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.AdvertisingAgencies;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.OfferWebsites
{
    class OfferWebsite
    {
        List<IAdvertisingAgency> Agencies;
        Random RR;
        int TemporaryOffersCount;
        int PermanentOffersCount;
        List<IOffer> Offers;
        public OfferWebsite(List<IAdvertisingAgency> agencies, int tempcount, int permcount)
        {
            Agencies = agencies;
            TemporaryOffersCount = tempcount;
            PermanentOffersCount = permcount;
            RR = new Random();
        }
        public void PrepareOffers()
        {
            Offers = new List<IOffer>();
            for (int i = 0; i < PermanentOffersCount; i++)
            {
                int pickandchoose = RR.Next(0, Agencies.Count);
                Offers.Add(Agencies[pickandchoose].CreatePermanentOffer());
            }
            for (int i = 0; i < TemporaryOffersCount; i++)
            {
                int pickandchoose = RR.Next(0, Agencies.Count);
                Offers.Add(Agencies[pickandchoose].CreateTemporaryOffer());
            }
        }
        public void Present()
        {
            foreach (var offer in Offers)
            {
                offer.Display();
            }
        }
    }
}
