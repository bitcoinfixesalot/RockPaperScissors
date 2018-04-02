using RockPaperScissors.Enums;
using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Services
{
    public static class ComputerProvider
    {
        public static IComputerPlayer GetComputer(ComputerType computerType)
        {
            switch (computerType)
            {
                case ComputerType.RandomComputer:
                default:
                    return new RandomComputerPlayer();
                case ComputerType.TacticalComputer:
                    return new TacticalComputerPlayer();
            }
        }
    }
}
