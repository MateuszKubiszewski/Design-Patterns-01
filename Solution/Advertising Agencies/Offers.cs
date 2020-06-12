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
    interface IOffer
    {
        void Display();
    }
    public class PermanentTextOffer : IOffer
    {
        public ITrip Trip;
        public List<IReview> Reviews;
        public PermanentTextOffer(ITrip trip, List<IReview> reviews)
        {
            Trip = trip;
            Reviews = reviews;
        }
        public void Display()
        {
            Trip.GetTripDescription();
            foreach (var review in Reviews)
            {
                Console.WriteLine(review.GetDescription());
            }
            Console.WriteLine();
        }
    }
    public class TemporaryTextOffer : IOffer
    {
        public ITrip Trip;
        public List<IReview> Reviews;
        public int Lifespan;
        public TemporaryTextOffer(ITrip trip, List<IReview> reviews, int lifespan)
        {
            Trip = trip;
            Reviews = reviews;
            Lifespan = lifespan;
        }
        public void Display()
        {
            if (Lifespan == 0)
            {
                Console.WriteLine("This offer has expired\n");
                return;
            }
            Lifespan--;
            Trip.GetTripDescription();
            foreach (var review in Reviews)
            {
                Console.WriteLine(review.GetDescription());
            }
            Console.WriteLine();
        }
    }
    public class PermanentGraphicOffer : IOffer
    {
        public ITrip Trip;
        public List<IPhoto> Photos;
        public PermanentGraphicOffer(ITrip trip, List<IPhoto> photos)
        {
            Trip = trip;
            Photos = photos;
        }
        public void Display()
        {
            Trip.GetTripDescription();
            foreach (var photo in Photos)
            {
                Console.WriteLine(photo.GetDescription());
            }
            Console.WriteLine();
        }
    }
    public class TemporaryGraphicOffer : IOffer
    {
        public ITrip Trip;
        public List<IPhoto> Photos;
        public int Lifespan;
        public TemporaryGraphicOffer(ITrip trip, List<IPhoto> photos, int lifespan)
        {
            Trip = trip;
            Photos = photos;
            Lifespan = lifespan;
        }
        public void Display()
        {
            if (Lifespan == 0)
            {
                Console.WriteLine("This offer has expired\n");
                return;
            }
            Lifespan--;
            Trip.GetTripDescription();
            foreach (var photo in Photos)
            {
                Console.WriteLine(photo.GetDescription());
            }
            Console.WriteLine();
        }
    }
}
