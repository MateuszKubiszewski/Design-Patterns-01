using System;
using TravelAgencies.DataAccess;
using TravelAgencies.Codecs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Agencies
{
    class FranceTravel : ITravelAgency
    {
        Iterator<ListNode> bookingIterator;

        Iterator<BSTNode> oysterIterator;

        Iterator<PhotMetadata> shutterStockIterator;

        Iterator<TripAdvisorData> tripAdvisorIterator;

        Random random = new Random();

        public FranceTravel(BookingDatabase bookingDb, OysterDatabase oysterDb, ShutterStockDatabase shutterStockDb, TripAdvisorDatabase tripAdvisorDb)
        {
            bookingIterator = new BookingIterator(bookingDb);
            oysterIterator = new OysterIterator(oysterDb);
            shutterStockIterator = new ShutterStockIterator(shutterStockDb);
            tripAdvisorIterator = new TripAdvisorIterator(tripAdvisorDb);
        }
        //Photos are omitted if the longitude is not in the range [0, 5.4] and the latitude is in [43.6,50.0].
        public IPhoto CreatePhoto()
        {
            PhotMetadata hehe;
            hehe = shutterStockIterator.Next();
            while (hehe.Longitude < 0 || hehe.Longitude > 5.4 || hehe.Latitude < 43.6 || hehe.Latitude > 50.0)
                hehe = shutterStockIterator.Next();
            ShutterStockCodec stockCodec = new ShutterStockCodec();
            string height = stockCodec.Decrypt(hehe.HeightPx);
            string width = stockCodec.Decrypt(hehe.WidthPx);
            Photo photo = new Photo(hehe.Name, height, width);
            return photo;
        }

        public IReview CreateReview()
        {
            BSTNode hehe = oysterIterator.Next();
            Review review = new Review(hehe.UserName, hehe.Review);
            FrenchReview frreview = new FrenchReview();
            frreview.SetComponent(review);
            return frreview;
        }

        public ITrip CreateTrip()
        {
            BookingCodec bookingCodec = new BookingCodec();
            TripAdvisorCodec tripAdvisorCodec = new TripAdvisorCodec();
            int no = random.Next(1, 5);
            double rating = 0;
            double price = 0;
            Day[] days = new Day[no];
            for (int i = 0; i < no; i++)
            {
                ListNode booker = bookingIterator.Next();
                TripAdvisorData tripAdvisorData = tripAdvisorIterator.Next();
                while (tripAdvisorData.Country != "France")
                    tripAdvisorData = tripAdvisorIterator.Next();
                days[i] = new Day();
                days[i].accomodation = booker.Name;
                days[i].attractions = tripAdvisorData.Names;
                int bookrat = Int32.Parse(bookingCodec.Decrypt(booker.Rating));
                int bookprice = Int32.Parse(bookingCodec.Decrypt(booker.Price));
                int triprat = Int32.Parse(tripAdvisorCodec.Decrypt(tripAdvisorData.Rating));
                int tripprice = Int32.Parse(tripAdvisorCodec.Decrypt(tripAdvisorData.Price));
                rating = rating + bookrat + triprat;
                price = price + bookprice + tripprice;
            }
            rating /= no * 2;
            Trip trip = new Trip(days, rating, price);
            FrenchTrip frtrip = new FrenchTrip();
            frtrip.SetComponent(trip);
            return frtrip;
        }
    }
}
