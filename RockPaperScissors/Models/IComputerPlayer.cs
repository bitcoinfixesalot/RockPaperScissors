using RockPaperScissors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public interface IComputerPlayer
    {
        Moves MakeaMove();
    }
}
