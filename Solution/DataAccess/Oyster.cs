using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

//Oyster is a website with reviews of various holiday destinations.
namespace TravelAgencies.DataAccess
{
	class BSTNode
	{
		public string Review { get; set; }
		public string UserName { get; set; }
		public BSTNode Left { get; set; }
		public BSTNode Right { get; set; }
	}
	class OysterDatabase : Database<BSTNode>
	{
		public BSTNode Reviews { get; set; }
		public override Iterator<BSTNode> CreateIterator()
		{
			return new OysterIterator(this);
		}
	}

	class OysterIterator : Iterator<BSTNode>
	{
		OysterDatabase Database;
		Stack ToCheck;
		BSTNode CurrentObject;

		public OysterIterator(OysterDatabase database)
		{
			Database = database;
			CurrentObject = null;
			ToCheck = new Stack();
		}

		public override BSTNode Next()
		{
			if (CurrentObject == null)
			{
				BSTNode temp = Database.Reviews;
				while (temp != null)
				{
					ToCheck.Push(temp);
					temp = temp.Left;
				}
				CurrentObject = (BSTNode)ToCheck.Pop();
				return CurrentObject;
			}
			if (ToCheck.Count == 0 && CurrentObject.Left != null)
			{
				BSTNode temp = CurrentObject;
				while (temp != null)
				{
					ToCheck.Push(temp);
					temp = temp.Left;
				}
			}
			if (CurrentObject.Right != null)
				ToCheck.Push(CurrentObject.Right);
			if (ToCheck.Count > 0)
				CurrentObject = (BSTNode)ToCheck.Pop();
			else
			{
				BSTNode temp = Database.Reviews;
				while (temp != null)
				{
					ToCheck.Push(temp);
					temp = temp.Left;
				}
				CurrentObject = (BSTNode)ToCheck.Pop();
			}
			return CurrentObject;			
		}
	}
}
