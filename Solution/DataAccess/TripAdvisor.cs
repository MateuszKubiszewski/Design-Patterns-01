using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.DataAccess
{
	class TripAdvisorDatabase : Database<TripAdvisorData>
	{
		public Guid[] Ids;
		public Dictionary<Guid, string>[] Names { get; set; }
		public Dictionary<Guid, string> Prices { get; set; }//Encrypted
		public Dictionary<Guid, string> Ratings { get; set; }//Encrypted
		public Dictionary<Guid, string> Countries { get; set; }
		public override Iterator<TripAdvisorData> CreateIterator()
		{
			return new TripAdvisorIterator(this);
		}
	}
	class TripAdvisorData
	{
		public Guid ID;
		public List<string> Names;
		public string Price;
		public string Rating;
		public string Country;
		public TripAdvisorData(Guid id, List<string> names, string price, string rating, string country)
		{
			ID = id;
			Names = names;
			Price = price;
			Rating = rating;
			Country = country;
		}
	}
	class TripAdvisorIterator : Iterator<TripAdvisorData>
	{
		TripAdvisorDatabase Database;
		int Current;

		public TripAdvisorIterator(TripAdvisorDatabase database)
		{
			Database = database;
			Current = -1;
		}

		public override TripAdvisorData Next()
		{
			Current++;
			if (Current == Database.Ids.Length)
			{
				Current = 0;
			}
			Guid guid = Database.Ids[Current];
			List<string> names = new List<string>();
			while (!Database.Prices.ContainsKey(guid) || !Database.Ratings.ContainsKey(guid) || !Database.Countries.ContainsKey(guid) || names.Count != 3)
			{
				Current++;			
				if (Current == Database.Ids.Length)
				{
					Current = 0;
				}
				guid = Database.Ids[Current];
				for (int i = 0; i < Database.Names.Length; i++)
				{
					if (Database.Names[i] != null)
					{
						if (Database.Names[i].ContainsKey(guid))
						{
							if (Database.Names[i][guid] != null)
							{
								if (!names.Contains(Database.Names[i][guid]))
									names.Add(Database.Names[i][guid]);
							}				
						}
					}
					if (names.Count == 3)
						break;
				}
			}
			string price = Database.Prices[guid];
			string rating = Database.Ratings[guid];
			string country = Database.Countries[guid];
			return new TripAdvisorData(guid, names, price, rating, country);
		}
	}
}
