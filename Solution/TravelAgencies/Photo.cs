using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Agencies
{
    public interface IPhoto
    {
        string GetDescription();
    }

    public class Photo : IPhoto
    {
        string Name;
        string Height;
        string Width;
        public Photo(string name = "", string height = "", string width = "")
        {
            Name = name;
            Height = height;
            Width = width;
        }
        public string GetDescription()
        {
            return Name + " (" + Width + 'x' + Height + ')';
        }
    }

    public abstract class PhotoDecorator : IPhoto
    {
        protected IPhoto Photo;
        public void SetComponent(IPhoto photo)
        {
            Photo = photo;
        }
        public virtual string GetDescription()
        {
            return Photo.GetDescription();
        }
    }

    public class PolishPhoto : PhotoDecorator
    {
        public override string GetDescription()
        {
            string ret = base.GetDescription();
            string toRet = "";
            foreach (var letter in ret)
            {
                if (letter == 's')
                    toRet += 'ś';
                else if (letter == 'c')
                    toRet += 'ć';
                else
                    toRet += letter;
            }
            return toRet;
        }
    }

    public class ItalianPhoto : PhotoDecorator
    {
        public override string GetDescription()
        {
            string ret = base.GetDescription();
            string toRet = ret.Insert(0, "Dello_");
            return toRet;
        }
    }
}
