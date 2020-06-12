using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Agencies
{
    public class Day
    {
        public List<string> attractions;
        public string accomodation;
    }

    public interface ITrip
    {
        void GetDataDescription();
        void GetDayDescription(int i);
        void GetTripDescription();
    }

    public class Trip : ITrip
    {
        public Day[] Days;
        double Rating;
        double Price;
        public Trip(Day[] days, double rating, double price)
        {
            Days = days;
            Rating = rating;
            Price = price;
        }
        public void GetDataDescription()
        {
            Console.WriteLine($"Rating: {Rating:0.##}");
            Console.WriteLine($"Price: {Price:0.##}");
            Console.WriteLine();
        }

        public void GetDayDescription(int i)
        {
            Console.WriteLine($"Accomodation: {Days[i - 1].accomodation}");
            Console.WriteLine("Attractions:");
            foreach (var attraction in Days[i - 1].attractions)
                Console.WriteLine($"\t{attraction}");
        }

        public void GetTripDescription()
        {
            GetDataDescription();
            for (int i = 1; i <= Days.Length; i++)
            {
                GetDayDescription(i);
            }
            Console.WriteLine();
        }
    }

    public abstract class TripDecorator : ITrip
    {
        protected Trip Trip;
        public void SetComponent(Trip trip)
        {
            Trip = trip;
        }
        public virtual void GetDataDescription()
        {
            Trip.GetDataDescription();
        }
        public virtual void GetDayDescription(int i)
        {
            Trip.GetDayDescription(i);
        }
        public virtual void GetTripDescription()
        {
            GetDataDescription();
            for (int i = 1; i <= Trip.Days.Length; i++)
            {
                GetDayDescription(i);
                Console.WriteLine();
            }
        }
    }

    public class PolishTrip : TripDecorator
    {
        public override void GetDayDescription(int i)
        {
            Console.WriteLine($"Day {i} in Poland!");
            base.GetDayDescription(i);
        }
    }

    public class ItalianTrip : TripDecorator
    {
        public override void GetDayDescription(int i)
        {
            Console.WriteLine($"Day {i} in Italy!");
            base.GetDayDescription(i);
        }
    }

    public class FrenchTrip : TripDecorator
    {
        public override void GetDayDescription(int i)
        {
            Console.WriteLine($"Day {i} in France!");
            base.GetDayDescription(i);
        }
    }
}

//Rating: 2.6875
//Price: 3887

//Day 1 in Italy!
//Accommodation: Timhotel Paris Place D’Italie
//Attractions:
//        Casco Historico
//        Custodia de Arfe
//        Monastero Di San Daniele