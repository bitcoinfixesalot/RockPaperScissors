using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public class GameService : IGameService
    {
        int _roundsToWin;
        IComputerPlayer _computerPlayer;

        int _playerScore;
        int _computerScore;

        public bool IsGameOver()
        {
            if (_playerScore >= _roundsToWin || _computerScore >= _roundsToWin)
            {
                return true;
            }
            return false;
        }

        public void NewGame(int roundsToWin, ComputerType gameType)
        {
            _playerScore = 0;
            _computerScore = 0;
            _roundsToWin = roundsToWin;
            _computerPlayer = ComputerProvider.GetComputer(gameType);
        }

        public Round NextRound(Moves playerMove)
        {
            var computerMove = _computerPlayer.MakeaMove();

            var result = RoundResult(playerMove, computerMove);

            if (result == Result.Win)
                _playerScore++;
            else if (result == Result.Loss)
                _computerScore++;

            var round = new Round(result, _playerScore, _computerScore, playerMove, computerMove);

            return round;
        }

        private Result RoundResult(Moves playerMove, Moves computerMove)
        {
            if (playerMove == computerMove)
                return Result.Draw;

            switch (playerMove)
            {
                case Moves.Rock:
                default:
                    if (computerMove == Moves.Paper)
                        return Result.Loss;

                    return Result.Win;

                case Moves.Paper:
                    if (computerMove == Moves.Scissors)
                        return Result.Loss;

                    return Result.Win;

                case Moves.Scissors:
                    if (computerMove == Moves.Rock)
                        return Result.Loss;

                    return Result.Win;
            }
        }
    }
}
