using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.DataAccess
{
	class ListNode
	{
		public ListNode Next { get; set; }
		public string Name { get; set; }
		public string Rating { get; set; }//Encrypted
		public string Price { get; set; }//Encrypted
	}
	class BookingDatabase : Database<ListNode>
	{
		public ListNode[] Rooms { get; set; }
		public override Iterator<ListNode> CreateIterator()
		{
			return new BookingIterator(this);
		}
	}
	class BookingIterator : Iterator<ListNode>
	{
		BookingDatabase Database;
		ListNode CurrentObject;
		int CurrentCategory;

		public BookingIterator(BookingDatabase database)
		{
			Database = database;
			CurrentObject = null;
			CurrentCategory = 0;
		}

		public override ListNode Next()
		{
			if (CurrentObject == null)
				CurrentObject = Database.Rooms[0];
			else if (CurrentObject.Next == null && Database.Rooms.Length == CurrentCategory - 1)
			{
				CurrentObject = Database.Rooms[0];
				CurrentCategory = 0;
			}				
			else if (CurrentObject.Next == null)
			{
				CurrentCategory++;
				if (CurrentCategory == Database.Rooms.Length)
				{
					CurrentCategory = 0;
				}
				CurrentObject = Database.Rooms[CurrentCategory];
			}
			else
				CurrentObject = CurrentObject.Next;
			if (CurrentObject.Name == null || CurrentObject.Price == null || CurrentObject.Rating == null)
				Next();
			return CurrentObject;
		}
	}
}
