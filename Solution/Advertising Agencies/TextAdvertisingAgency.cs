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
    class TextAdvertisingAgency : IAdvertisingAgency
    {
        List<ITravelAgency> TravelAgencies;
        int ReviewsCount;
        int OffersLifespan;
        int Count;

        public TextAdvertisingAgency(List<ITravelAgency> travelagencies, int reviewscount, int offerslifespan)
        {
            TravelAgencies = travelagencies;
            ReviewsCount = reviewscount;
            OffersLifespan = offerslifespan;
            Count = 0;
        }
        public IOffer CreatePermanentOffer()
        {
            List<IReview> reviews = new List<IReview>();
            for (int i = 0; i < ReviewsCount; i++)
            {
                reviews.Add(TravelAgencies[Count].CreateReview());
            }
            ITrip trip = TravelAgencies[Count].CreateTrip();

            Count++;
            if (Count == TravelAgencies.Count)
                Count = 0;

            return new PermanentTextOffer(trip, reviews);
        }

        public IOffer CreateTemporaryOffer()
        {
            List<IReview> reviews = new List<IReview>();
            for (int i = 0; i < ReviewsCount; i++)
            {
                reviews.Add(TravelAgencies[Count].CreateReview());
            }
            ITrip trip = TravelAgencies[Count].CreateTrip();

            Count++;
            if (Count == TravelAgencies.Count)
                Count = 0;

            return new TemporaryTextOffer(trip, reviews, OffersLifespan);
        }

    }
}
