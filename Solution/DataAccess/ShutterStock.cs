using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.DataAccess
{
	class PhotMetadata
	{
		public string Name { get; set; }
		public string Camera { get; set; }
		public double[] CameraSettings { get; set; }
		public DateTime Date { get; set; }
		public string WidthPx { get; set; }//Encrypted
		public string HeightPx { get; set; }//Encrypted
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
	class ShutterStockDatabase : Database<PhotMetadata>
	{
		public PhotMetadata[][][] Photos;
		public override Iterator<PhotMetadata> CreateIterator()
		{
			return new ShutterStockIterator(this);
		}
	}
	class ShutterStockIterator : Iterator<PhotMetadata>
	{
		ShutterStockDatabase Database;
		PhotMetadata Current;
		//1st level
		int CurrentCategory;
		//2nd level
		int CurrentAlbum;
		//3rd level
		int CurrentPhoto;
		public ShutterStockIterator(ShutterStockDatabase database)
		{
			CurrentAlbum = 0;
			CurrentCategory = 0;
			CurrentPhoto = 0;
			Current = null;
			Database = database;
		}
		public override PhotMetadata Next()
		{
			for (; CurrentCategory < Database.Photos.Length; CurrentCategory++)
			{
				while (Database.Photos[CurrentCategory] == null)
				{
					CurrentCategory++;
					if (CurrentCategory == Database.Photos.Length)
						break;
				}
				if (CurrentCategory == Database.Photos.Length)
					break;
				for (; CurrentAlbum < Database.Photos[CurrentCategory].Length; CurrentAlbum++)
				{
					while (Database.Photos[CurrentCategory][CurrentAlbum] == null)
					{
						CurrentAlbum++;
						if (CurrentAlbum == Database.Photos[CurrentCategory].Length)
							break;
					}
					if (CurrentAlbum == Database.Photos[CurrentCategory].Length)
						break;
					for (; CurrentPhoto < Database.Photos[CurrentCategory][CurrentAlbum].Length; CurrentPhoto++)
					{
						Current = Database.Photos[CurrentCategory][CurrentAlbum][CurrentPhoto];
						if (Current != null)
						{
							CurrentPhoto++;
							return Current;
						}
					}
					CurrentPhoto = 0;
				}
				CurrentAlbum = 0;
			}
			CurrentPhoto = 0;
			CurrentAlbum = 0;
			CurrentCategory = 0;
			return Database.Photos[CurrentCategory][CurrentAlbum][CurrentPhoto];
		}
	}
}
