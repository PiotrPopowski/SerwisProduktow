using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerwisProduktow.Domain.Entities
{
    public class Rating
    {
        public int ID { get; protected set; }
        public int NumberOfVotes { get; protected set; }
        public int SumOfVotes { get; protected set; }
        public double AvarageOfVotes { get; protected set; }

        public void AddVote(int ocena)
        {
            SumOfVotes =SumOfVotes + ocena;
            NumberOfVotes++;
            AvarageOfVotes = (double)SumOfVotes / (double)NumberOfVotes;
        }
    }
}
