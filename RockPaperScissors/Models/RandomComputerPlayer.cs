using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;

namespace RockPaperScissors.Models
{
    public class RandomComputerPlayer : IComputerPlayer
    {
        Random _random;
        public RandomComputerPlayer()
        {
            _random = new Random();
        }

        public Moves MakeaMove()
        {
            var random = _random.Next(1, 4);

            return (Moves)random;
        }
    }
}
