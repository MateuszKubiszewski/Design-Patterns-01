using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencies.AdvertisingAgencies;
using TravelAgencies.Agencies;
using TravelAgencies.DataAccess;
using TravelAgencies.OfferWebsites;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies
{
	class Program
	{
		static void Main(string[] args) { new Program().Run(); }

		private const int WebsitePermanentOfferCount = 2;
		private const int WebsiteTemporaryOfferCount = 3;
		private Random rd = new Random(257);

		//----------
		//YOUR CODE - additional fileds/properties/methods
		//----------

		public void Run()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			(
				BookingDatabase accomodationData,
				TripAdvisorDatabase tripsData,
				ShutterStockDatabase photosData,
				OysterDatabase reviewData
			) = Init.Init.Run();

			//----------
			//YOUR CODE - set up everything
			PolandTravel hehe = new PolandTravel(accomodationData, reviewData, photosData, tripsData);
			FranceTravel hihi = new FranceTravel(accomodationData, reviewData, photosData, tripsData);
			ItalyTravel hoho = new ItalyTravel(accomodationData, reviewData, photosData, tripsData);
			List<ITravelAgency> travelAgencies = new List<ITravelAgency>();
			travelAgencies.Add(hehe);
			travelAgencies.Add(hihi);
			travelAgencies.Add(hoho);
			GraphicAdvertisingAgency kuryszatan = new GraphicAdvertisingAgency(travelAgencies, 2, 2);
			TextAdvertisingAgency tpn25spychacz = new TextAdvertisingAgency(travelAgencies, 3, 2);
			GraphicAdvertisingAgency bialymongol = new GraphicAdvertisingAgency(travelAgencies, 6, 1);
			TextAdvertisingAgency elektrycznywegorz = new TextAdvertisingAgency(travelAgencies, 4, 1);
			List<IAdvertisingAgency> advertisingAgencies = new List<IAdvertisingAgency>();
			advertisingAgencies.Add(kuryszatan);
			advertisingAgencies.Add(tpn25spychacz);
			advertisingAgencies.Add(bialymongol);
			advertisingAgencies.Add(elektrycznywegorz);
			//----------

			while (true)
			{
				Console.Clear();

				//----------
				//YOUR CODE - run
				//----------				
				OfferWebsite offerWebsite = new OfferWebsite(advertisingAgencies, WebsiteTemporaryOfferCount, WebsitePermanentOfferCount);
				offerWebsite.PrepareOffers();

				Console.WriteLine("\n\n=======================FIRST PRESENT======================");
				offerWebsite.Present();
				Console.WriteLine("\n\n=======================SECOND PRESENT======================");
				offerWebsite.Present();
				Console.WriteLine("\n\n=======================THIRD PRESENT======================");
				offerWebsite.Present();


				if (HandleInput()) break;
			}
		}
		bool HandleInput()
		{
			var key = Console.ReadKey(true);
			return key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q;
		}
	}
}
