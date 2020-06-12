using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Kubiszewski

namespace TravelAgencies.Agencies
{
    public interface IReview
    {
        string GetUsername();
        string GetOpinion();
        string GetDescription();
    }

    public class Review : IReview
    {
        string Username;
        string Opinion;

        public Review(string username = "", string opinion = "")
        {
            Username = username;
            Opinion = opinion;
        }
        public string GetUsername()
        {
            return Username;
        }
        public string GetOpinion()
        {
            return Opinion;
        }
        public string GetDescription()
        {
            return Username + ": " + Opinion;
        }   
    }

    public abstract class ReviewDecorator : IReview
    {
        protected IReview Review;
        public void SetComponent(IReview review)
        {
            Review = review;
        }
        public string GetUsername()
        {
            return Review.GetUsername();
        }
        public string GetOpinion()
        {
             return Review.GetOpinion();
        }
        public virtual string GetDescription()
        {
            return Review.GetDescription();
        }
    }

    public class PolishReview : ReviewDecorator
    {
        public override string GetDescription()
        {
            string ret = base.GetDescription();
            string toRet = "";
            foreach (var letter in ret)
            {
                if (letter == 'e')
                    toRet += 'ę';
                else if (letter == 'a')
                    toRet += 'ą';
                else
                    toRet += letter;
            }
            return toRet;
        }
    }

    public class ItalianReview : ReviewDecorator
    {
        public override string GetDescription()
        {
            string ret = base.GetDescription();
            string toRet = ret.Insert(0, "Della_");
            return toRet;
        }
    }

    public class FrenchReview : ReviewDecorator
    {
        public override string GetDescription()
        {
            string ret = GetUsername();
            ret += ": ";
            string opinion = GetOpinion();
            string[] words = opinion.Split(' ');
            foreach (var word in words)
            {
                if (word.Count() < 4 && word != ",")
                    ret += "la ";
                else
                    ret += $"{word} ";
            }
            return ret;
        }
    }
}
