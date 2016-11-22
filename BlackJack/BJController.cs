using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using ClassLibrary1;

namespace BlackJack
{

    class BjController
    {
        public delegate void UseIdDelegate(int id); //Делегат для событий, использующих ID

        public event UseIdDelegate NextTurnEvent;
            //Событие, в которое передается ID следующего игрока (берется текущий ID, и прибавляется 1

        public event UseIdDelegate PlayerTakeCardEvent;
        Form1 _mainForm;
        BJPlayer /*_mainPlayer,*/ _player2, _player3, _player4;

        public List<BJCard> CurrentDeck { get; set; }
        //Массив колоды

        private int PlayersNumber { get; set; }
        //Количество игроков

        private List<BJPlayer> PlayersMassiv { get; set; }
        //Массив игроков

        public BJPlayer MainPlayer { get; set; }
        //Главный игрок - человек

        public int GameCounter { get; set; }

        public BjController(Form1 mainForm)
        {

            GameCounter = 0;
            _mainForm = mainForm;
            CurrentDeck = BJMassiv.GetUsualCards();
            PlayersMassiv = new List<BJPlayer>();
            NextTurnEvent += EndGame;
            PlayerTakeCardEvent += TakeCardEvent;

        }

        public void CardWasTaken(int id)
        {
            if (PlayerTakeCardEvent != null)

                PlayerTakeCardEvent(id);
        }

        public void CreateTwoPlayers()
        {
            MainPlayer = new BJPlayer(1, this);
            _player2 = new BJPlayer(2, this);

            PlayersMassiv.Add(MainPlayer);
            PlayersMassiv.Add(_player2);
            PlayersNumber = 2;
            MainPlayer.TakeTwoStartCards();
            _player2.TakeTwoStartCards();

            NextTurnEvent += _player2.TurnReaction;



        }

        public void CreateThreePlayers()
        {

            CreateTwoPlayers();
            _player3 = new BJPlayer(3, this);
            PlayersMassiv.Add(_player3);
            PlayersNumber = 3;
            _player3.TakeTwoStartCards();
            NextTurnEvent += _player3.TurnReaction;
        }

        public void CreateFourPlayers()
        {

            CreateThreePlayers();
            _player4 = new BJPlayer(4, this);
            PlayersMassiv.Add(_player4);
            _player4.TakeTwoStartCards();
            PlayersNumber = 4;
            NextTurnEvent += _player4.TurnReaction;
        }


        private void TakeCardEvent(int playerId)
        {
                var player = PlayersMassiv.FirstOrDefault();
            if (player != null)
            {
                foreach (var crd in player.CurrentMassiv)
                {
                    if (!_mainForm.Controls.Contains(crd))
                    {
                        _mainForm.Controls.Add(crd);
                    }
                }
            }

        }
        public void NextTurn(int id)
        {
            if (NextTurnEvent != null)
                NextTurnEvent(id);
        }


        string _messageResult = "";
        private void EndGame(int id)
        {
            if (GameCounter >= 10)
            {
                var commonResult = "";
                foreach (var pl in PlayersMassiv)
                {
                     commonResult += "\nИгрок " + pl.Id + " получил " + pl.Winnings + " очков.";
                }
                _mainForm.ResetAll(commonResult);
            }

            if (id > PlayersNumber)
            {
                GameCounter++;


                _mainForm.UpdateGamesCount(Convert.ToString(GameCounter));
                //Конец игры, подсчет очков


                foreach (var pl in PlayersMassiv)
                {
                    pl.ShowAllCards();

                }
                Counting(ref _messageResult);

                //Уточнить, нет ли одинаковых очков

                _mainForm.ShowMessage(_messageResult);
                _messageResult = "";
                NextTurn(1);

                ToNextRound();


            }

        }/*
        void DefineResult(ref string resultMessage)
        {

            var winners = PlayersMassiv.Where(item => item.PlayerCounter == 21).ToList();
            if (winners.Count > 1)
            {
                resultMessage += "Ничья!" + " \nРезультаты: ";
                foreach (BJPlayer pl in PlayersMassiv)
                {

                    resultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                }
            }
            else
                if (winners.Count == 1)
                {
                    resultMessage += "Игрок " + winners.First().Id + " победил, набрав 21 очко! \nОбщие результаты: ";
                    foreach (BJPlayer pl in PlayersMassiv)
                    {

                        resultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                    }
                    winners.First().Winnings++;
                }
                else
                {
                    var RemPlayers = PlayersMassiv.Where(item => item.PlayerCounter < 21).ToList();
                    if (RemPlayers.Count == 0)
                    {
                        resultMessage += "У всех игроков перебор! \nОбщие результаты: ";
                        foreach (BJPlayer pl in PlayersMassiv)
                        {

                            resultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                        }

                    }
                    var orderMassiv = PlayersMassiv.Where(item => item.PlayerCounter < 21).ToList();
                    orderMassiv = orderMassiv.OrderBy(item => item.PlayerCounter).ToList();
                    var Winner1 = orderMassiv.Last();
                    var checkingMassiv = orderMassiv.Where(item => item.PlayerCounter == Winner1.PlayerCounter).ToList();
                    if (checkingMassiv.Count > 1)
                    {
                        resultMessage += "Ничья!" + " \nРезультаты: ";
                        foreach (BJPlayer pl in PlayersMassiv)
                        {

                            resultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                        }
                    }
                    else if (checkingMassiv.Count == 1)
                    {
                        resultMessage += "Победил игрок " + Winner1.Id + ". \nРезультаты: ";
                        foreach (BJPlayer pl in PlayersMassiv)
                        {

                            resultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                        }
                        Winner1.Winnings++;
                    }
                    return;
                }*/
      private void Counting(ref string resultMessage)
        {
            var overflow = PlayersMassiv.Where(item => item.PlayerCounter > 21).ToList();
            var winners = PlayersMassiv.Where(item => item.PlayerCounter == 21).ToList();
            var deciders = PlayersMassiv.Where(item => item.PlayerCounter < 21).ToList();
             if (deciders.Count == 2)
            {
            var onedecider = deciders.First();
            var seconddecider = deciders.Last();
                if (onedecider.PlayerCounter == seconddecider.PlayerCounter)
                {
                    resultMessage += "Ничья, оба игрока набрали по " + onedecider.PlayerCounter + " очков";
                }
                else if (onedecider.PlayerCounter > seconddecider.PlayerCounter)
                {
                    resultMessage += "Победил игрок " + onedecider.Id + ", набрав " + onedecider.PlayerCounter + " очков";
                    onedecider.Winnings++;
                }
                else
                {
                    resultMessage += "Победил игрок " + seconddecider.Id + ", набрав " + seconddecider.PlayerCounter + " очков";
                    seconddecider.Winnings++;
                }
            }
            else if ((deciders.Count == 1) & (overflow.Count == 1))
            {
                var onedecider = deciders.First();
                resultMessage += "Победил игрок " + onedecider.Id + ", набрав " + onedecider.PlayerCounter + " очков";
                onedecider.Winnings++;
            }
            if (winners.Count > 1)
                {
                    resultMessage += "Оба игрока победили, набрав 21 очко";
                }
                else if (winners.Count == 1)
                {
                    var winner = winners.First();
                    resultMessage += "Победил игрок " + winner.Id + " , набрав 21 очко";
                }
            if (overflow.Count>1)
                {
                    resultMessage += "Оба игрока проиграли, совершив перебор";
                }
            foreach (var playnum in deciders)
            {
                resultMessage += "\nИгрок=" + playnum.Id + ",очки=" + playnum.PlayerCounter + "; ";
                
            }
            foreach (var playnum in winners)
            {
                resultMessage += "\nИгрок=" + playnum.Id + ",очки=" + playnum.PlayerCounter + "; ";
                playnum.Winnings++;
            }
            foreach (var playnum in overflow)
            {
                resultMessage += "\nИгрок=" + playnum.Id + ",очки=" + playnum.PlayerCounter + "; ";
                playnum.Winnings--;
            }
            return;
        }
        public void CountAllScores()
        {
            MainPlayer.CountScores();
            _player2.CountScores();

            if (_player3 != null)
                _player3.CountScores();

            if (_player4 != null)
                _player4.CountScores();


        }
        private void ToNextRound()
        {
            CurrentDeck = BJMassiv.GetUsualCards();

            foreach (var player in PlayersMassiv)
            {
                player.PlayerCounter = 0;

                foreach (var crd in player.CurrentMassiv)
                {
                    if (_mainForm.Controls.Contains(crd))
                        _mainForm.Controls.Remove(crd);
                }
                player.CurrentMassiv = new List<BJCard>();
                player.TakeTwoStartCards();
            }

        }

    }
}