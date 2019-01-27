using SerwisProduktow.Domain.Exceptions;
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

        public ICollection<int?> Users {get; protected set; }

        public Rating()
        {
            Users = new HashSet<int?>();
        }

        public void AddVote(int userID, int ocena)
        {
            if (ocena > 5 || ocena < 1) throw new WojtekException(WojtekCodes.WrongRating);
            var user = Users.FirstOrDefault(u => u == userID);
            if (user != null)
                throw new WojtekException(WojtekCodes.UserVoted);
            SumOfVotes =SumOfVotes + ocena;
            NumberOfVotes++;
            AvarageOfVotes = Math.Round((double)SumOfVotes / (double)NumberOfVotes,2);
            Users.Add(userID);
        }
    }
}
