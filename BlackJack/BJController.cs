using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace BlackJack
{

    class BJController
    {
        public delegate void UseIdDelegate(int id);//Делегат для событий, использующих ID

        public event UseIdDelegate NextTurnEvent; //Событие, в которое передается ID следующего игрока (берется текущий ID, и прибавляется 1
        public event UseIdDelegate PlayerTakeCardEvent;
        Form1 MainForm;
        BJPlayer _mainPlayer, Player2, Player3, Player4;
        List<BJCard> _currentDeck;
        int _playersNumber, gameCounter;
        List<BJPlayer> _playersMassiv;

        public List<BJCard> CurrentDeck
        {
            get
            {
                return _currentDeck;
            }

            set
            {
                _currentDeck = value;
            }
        } //Массив колоды

        public int PlayersNumber
        {
            get
            {
                return _playersNumber;
            }

            set
            {
                _playersNumber = value;
            }
        } //Количество игроков

        public List<BJPlayer> PlayersMassiv
        {
            get
            {
                return _playersMassiv;
            }

            set
            {
                _playersMassiv = value;
            }
        } //Массив игроков

        public BJPlayer MainPlayer
        {
            get
            {
                return _mainPlayer;
            }

            set
            {
                _mainPlayer = value;
            }
        } //Главный игрок - человек

        public int GameCounter
        {
            get
            {
                return gameCounter;
            }

            set
            {
                gameCounter = value;
            }
        }

        public BJController(Form1 mainForm)
        {
            GameCounter = 0;
            MainForm = mainForm;
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
            Player2 = new BJPlayer(2, this);

            PlayersMassiv.Add(MainPlayer);
            PlayersMassiv.Add(Player2);
            PlayersNumber = 2;
            MainPlayer.TakeTwoStartCards();
            Player2.TakeTwoStartCards();

            NextTurnEvent += Player2.TurnReaction;



        }
        public void CreateThreePlayers()
        {

            CreateTwoPlayers();
            Player3 = new BJPlayer(3, this);
            PlayersMassiv.Add(Player3);
            PlayersNumber = 3;
            Player3.TakeTwoStartCards();
            NextTurnEvent += Player3.TurnReaction;
        }
        public void CreateFourPlayers()
        {

            CreateThreePlayers();
            Player4 = new BJPlayer(4, this);
            PlayersMassiv.Add(Player4);
            Player4.TakeTwoStartCards();
            PlayersNumber = 4;
            NextTurnEvent += Player4.TurnReaction;
        }


        void TakeCardEvent(int playerId)
        {
            BJPlayer player = PlayersMassiv.Where(item => item.Id == playerId).FirstOrDefault();
            foreach (BJCard crd in player.CurrentMassiv)
            {
                if (!MainForm.Controls.Contains(crd))
                {

                    MainForm.Controls.Add(crd);

                }
            }
        }
        public void NextTurn(int id)
        {
            if (NextTurnEvent != null)
                NextTurnEvent(id);
        }


        string messageResult = "";
        public void EndGame(int id)
        {
            if (gameCounter >= 10)
            {
                string CommonResult = "";
                foreach (BJPlayer pl in PlayersMassiv)
                {
                    CommonResult += "\nИгрок " + pl.Id + " одержал " + pl.Winnings + " побед.";
                }
                MainForm.ResetAll(CommonResult);
            }

            if (id > PlayersNumber)
            {
                GameCounter++;
                
                
                    MainForm.UpdateGamesCount(Convert.ToString(gameCounter));
                    //Конец игры, подсчет очков


                    foreach (BJPlayer pl in PlayersMassiv)
                    {
                        pl.ShowAllCards();

                    }
                    DefineResult(ref messageResult);

                    //Уточнить, нет ли одинаковых очков

                    MainForm.ShowMessage(messageResult);
                    messageResult = "";
                    NextTurn(1);

                    ToNextRound();
                

            }

        }
        void DefineResult(ref string ResultMessage)
        {

            var winners = PlayersMassiv.Where(item => item.PlayerCounter == 21).ToList();
            if (winners.Count > 1)
            {
                ResultMessage += "Ничья!" + " \nРезультаты: ";
                foreach (BJPlayer pl in PlayersMassiv)
                {

                    ResultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                }
            }
            else
            if (winners.Count == 1)
            {
                ResultMessage += "Игрок " + winners.First().Id + " победил, набрав 21 очко! \nОбщие результаты: ";
                foreach (BJPlayer pl in PlayersMassiv)
                {

                    ResultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                }
                winners.First().Winnings++;
            }
            else
            {
                var RemPlayers = PlayersMassiv.Where(item => item.PlayerCounter < 21).ToList();
                if (RemPlayers.Count == 0)
                {
                    ResultMessage += "У всех игроков перебор! \nОбщие результаты: ";
                    foreach (BJPlayer pl in PlayersMassiv)
                    {

                        ResultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                    }

                }
                var orderMassiv = PlayersMassiv.Where(item => item.PlayerCounter < 21).ToList();
                orderMassiv = orderMassiv.OrderBy(item => item.PlayerCounter).ToList();
                var Winner1 = orderMassiv.Last();
                var checkingMassiv = orderMassiv.Where(item => item.PlayerCounter == Winner1.PlayerCounter).ToList();
                if (checkingMassiv.Count > 1)
                {
                    ResultMessage += "Ничья!" + " \nРезультаты: ";
                    foreach (BJPlayer pl in PlayersMassiv)
                    {

                        ResultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                    }
                }
                else if (checkingMassiv.Count == 1)
                {
                    ResultMessage += "Победил игрок " + Winner1.Id + ". \nРезультаты: ";
                    foreach (BJPlayer pl in PlayersMassiv)
                    {

                        ResultMessage += "\nID=" + pl.Id + ",очки=" + pl.PlayerCounter + ";  ";
                    }
                    Winner1.Winnings++;
                }
            }

            /*void Counting(ref string ResultMessage)
    {
    var overflow = PlayersMassiv.Where(item => item.PlayerCounter > 21).ToList();
    var winners = PlayersMassiv.Where(item => item.PlayerCounter == 21).ToList();
    var deciders = PlayersMassiv.Where(item => item.PlayerCounter < 21).ToList();
    foreach (BJPlayer playnum in overflow)
    {
    ResultMessage += "\nID=" + playnum.Id + ",очки=" + playnum.PlayerCounter + "; ";
    playnum.Winnings--;
    }
    foreach (BJPlayer playnum in winners)
    {
    ResultMessage += "\nID=" + playnum.Id + ",очки=" + playnum.PlayerCounter + "; ";
    playnum.Winnings++;
    }
    foreach (BJPlayer playnum in deciders)
    {
    ResultMessage += "\nID=" + playnum.Id + ",очки=" + playnum.PlayerCounter + "; ";
    if (winners.Count() == 0)
    {
    var WinnerBeast = deciders.Last();
    WinnerBeast.Winnings++;
    ResultMessage += "Победил игрок " + WinnerBeast.Id + ". \nРезультаты: ";
    }
    }
    }*/
            
            
                
        }

        public void CountAllScores()
        {
            MainPlayer.CountScores();
            Player2.CountScores();

            if (Player3 != null)
            Player3.CountScores();

            if (Player4!=null)
            Player4.CountScores();
            

        }
        public void ToNextRound()
        {
            CurrentDeck = BJMassiv.GetUsualCards();
          
            foreach (BJPlayer player in PlayersMassiv)
            {
                player.PlayerCounter = 0;
                
                foreach (BJCard crd in player.CurrentMassiv)
                {
                    if (MainForm.Controls.Contains(crd))
                        MainForm.Controls.Remove(crd);
                }
                player.CurrentMassiv = new List<BJCard>();
                player.TakeTwoStartCards();
            }

        }
        
    }
}
