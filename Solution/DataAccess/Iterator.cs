using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.DataAccess
{
    abstract class Iterator<T>
    {
        public abstract T Next();
    }

    abstract class Database<T>
    {
        public abstract Iterator<T> CreateIterator();
    }
}
