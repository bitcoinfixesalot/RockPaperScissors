using GalaSoft.MvvmLight;
using RockPaperScissors.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class Round : ObservableObject
    {

        public Round(Result result, int playerScore, int computerScore, Moves playerMove, Moves computerMove)
        {
            Result = result;
            PlayerScore = playerScore;
            ComputerScore = computerScore;
            PlayerMove = playerMove;
            ComputerMove = computerMove;
        }

        private int _playerScore;

        public int PlayerScore
        {
            get { return _playerScore; }
            set
            {
                _playerScore = value;
                RaisePropertyChanged(nameof(PlayerScore));
            }
        }


        private int _computerScore;

        public int ComputerScore
        {
            get { return _computerScore; }
            set
            {
                _computerScore = value;
                RaisePropertyChanged(nameof(ComputerScore));
            }
        }

        private Moves _playerMove;

        public Moves PlayerMove
        {
            get { return _playerMove; }
            set {
                _playerMove = value;
                RaisePropertyChanged(nameof(PlayerMove));
            }
        }

        private Moves _computerMove;

        public Moves ComputerMove
        {
            get { return _computerMove; }
            set
            {
                _computerMove = value;
                RaisePropertyChanged(nameof(ComputerMove));
            }
        }

        private Result _result;

        public Result Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }



    }
}
