using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RockPaperScissors.Enums;
using RockPaperScissors.Models;
using RockPaperScissors.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RockPaperScissors.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IGameService gameService)
        {
            SelectedComputer = ComputerType.RandomComputer;
            SelectedMove = Moves.Rock;
            GameService = gameService;
            NewGame();
        }

        public IGameService GameService { get; }

        private RelayCommand _newGameCommand;

        public RelayCommand NewGameCommand
        {
            get { return _newGameCommand ?? (_newGameCommand = new RelayCommand(NewGame)); }
        }

        private RelayCommand _performMoveCommand;

        public RelayCommand PerformMoveCommand
        {
            get { return _performMoveCommand ?? (_performMoveCommand = new RelayCommand(PerformMove, CanPlay)); }
        }

        private bool CanPlay()
        {
            if (GameService.IsGameOver())
                return false;

            return true;
        }

        private void PerformMove()
        {
            var round = GameService.NextRound(SelectedMove);
            Rounds.Insert(0, round);

            if (GameService.IsGameOver())
            {
                PerformMoveCommand.RaiseCanExecuteChanged();

                PrintResult(round.Result);
            }
        }

        private void PrintResult(Result result)
        {
            switch (result)
            {
                case Result.Win:
                    ResultText = "You win";
                    break;
                case Result.Loss:
                    ResultText = "You lose";
                    break;
                case Result.Draw:
                    default:
                    ResultText = string.Empty;
                    break;
            }
        }

        private void NewGame()
        {
            Rounds.Clear();
            ResultText = string.Empty;

            //TODO: get rounds from the config
            GameService.NewGame(2, SelectedComputer);
            PerformMoveCommand.RaiseCanExecuteChanged();
        }

        private ObservableCollection<Round> _rounds;

        public ObservableCollection<Round> Rounds
        {
            get
            {
                if (_rounds == null)
                    _rounds = new ObservableCollection<Round>();

                return _rounds;
            }
            set
            {
                _rounds = value;
                RaisePropertyChanged(nameof(Rounds));
            }
        }

        private Moves _selectedMove;

        public Moves SelectedMove
        {
            get { return _selectedMove; }
            set
            {
                if (_selectedMove == value) return;
                _selectedMove = value;
                RaisePropertyChanged(nameof(SelectedMove));
            }
        }

        private ComputerType _selectedComputer;

        public ComputerType SelectedComputer
        {
            get { return _selectedComputer; }
            set
            {
                if (_selectedComputer == value) return;
                _selectedComputer = value;
                RaisePropertyChanged(nameof(SelectedComputer));
            }
        }

        private string _resultText;

        public string ResultText
        {
            get { return _resultText; }
            set
            {
                if (_resultText == value) return;
                _resultText = value;
                RaisePropertyChanged(nameof(ResultText));
            }
        }

    }
}