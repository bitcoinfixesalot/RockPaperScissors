using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;

namespace RockPaperScissors.Models
{
    public class TacticalComputerPlayer : IComputerPlayer
    {
        Moves lastMove = Moves.Rock;
        public Moves MakeaMove()
        {
            switch (lastMove)
            {
                case Moves.Rock:
                default:
                    lastMove = Moves.Paper;
                    break;
                case Moves.Paper:
                    lastMove = Moves.Scissors;
                    break;
                case Moves.Scissors:
                    lastMove = Moves.Rock;
                    break;
            }
            return lastMove;
        }
    }
}
