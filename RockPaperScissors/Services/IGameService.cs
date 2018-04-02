using RockPaperScissors.Enums;
using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Services
{
    public interface IGameService
    {
        void NewGame(int roundsToWin, ComputerType gameType);

        Round NextRound(Moves playerMove);

        bool IsGameOver();
    }
}
