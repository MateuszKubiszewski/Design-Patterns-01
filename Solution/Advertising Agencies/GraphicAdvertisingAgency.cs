using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.Agencies;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.AdvertisingAgencies
{
    class GraphicAdvertisingAgency : IAdvertisingAgency
    {
        List<ITravelAgency> TravelAgencies;
        int PhotosCount;
        int OffersLifespan;
        int Count;

        public GraphicAdvertisingAgency(List<ITravelAgency> travelagencies, int photoscount, int offerslifespan)
        {
            TravelAgencies = travelagencies;
            PhotosCount = photoscount;
            OffersLifespan = offerslifespan;
            Count = 0;
        }
        public IOffer CreatePermanentOffer()
        {
            List<IPhoto> photos = new List<IPhoto>();
            for (int i = 0; i < PhotosCount; i++)
            {
                photos.Add(TravelAgencies[Count].CreatePhoto());
            }
            ITrip trip = TravelAgencies[Count].CreateTrip();

            Count++;
            if (Count == TravelAgencies.Count)
                Count = 0;

            return new PermanentGraphicOffer(trip, photos);
        }

        public IOffer CreateTemporaryOffer()
        {
            List<IPhoto> photos = new List<IPhoto>();
            for (int i = 0; i < PhotosCount; i++)
            {
                photos.Add(TravelAgencies[Count].CreatePhoto());
            }
            ITrip trip = TravelAgencies[Count].CreateTrip();

            Count++;
            if (Count == TravelAgencies.Count)
                Count = 0;

            return new TemporaryGraphicOffer(trip, photos, OffersLifespan);
        }

    }
}
