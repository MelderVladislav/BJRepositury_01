using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using ClassLibrary1;

namespace BlackJack
{
    
    class BJPlayer //Данный класс введен для удобства и содержит в себе текущий массив карт игрока (в том числе и главного игрока - человека, для него тоже будет создан экземпляр данного класса), и различные необходимые счета (побед, очков и тд)
    {
        List<BJCard> currentMassiv; //Текущий массив карт
        int _id=0;//ID, по дефолту будет ноль, не помню, зачем
        int _playerCounter; //Количество очков, исходя из расклада карт (текущего массива)
        int _winnings;//Количество побед игрока
        public int PlayerCounter
        {
             get
            {
                return _playerCounter;
            }

            set
            {
                _playerCounter = value;
            }
        } //Оборачиваем очки игрока в публичное свойство, ибо на него надо будет воздействовать извне

        public int Id
        {
            get
            {
                return _id;
            }

            
        }  //У этого свойства есть только get, тк нефиг изменять ИД игрока во время игры

        //Со свойствами внизу то же самое, что и с первым свойством
        public List<BJCard> CurrentMassiv
        {
            get
            {
                return currentMassiv;
            }

            set
            {
                currentMassiv = value;
            }
        } 

        public int Winnings
        {
            get
            {
                return _winnings;
            }

            set
            {
                _winnings = value;
            }
        }


        BJController Controller;//Создаем переменную контроллер, где содержатся все полезные методы и свойства для игры (ну так проще)
        
        public BJPlayer(int id,BJController controller) //Конструктор, принимает в себя ИД будущего игрока и контроллер. Последнее очень важно, тк контроллер содержит полезные методы и важные данные об игре (счет, колода),и, что очень важно, экземпляр основной формы, воздействуя на который мы можем добавлять в нее визуальную информацию (карты, сообщения и прочие интересности)
        {
            //Инициализируем введенные переменные
            Winnings = 0;
            PlayerCounter = 0;
            CurrentMassiv = new List<BJCard>();

            if (id<=4) //Игра сделана так, что ИД игроков должны идти ровно от 1 до 2/3/4 (да, это не очень хорошо, но я приму любые светлые идеи), а если хоть у одного игрока экземпляр будет содержать ИД, отличный от циферок от 1 до 4, например 6, игра пойдет по...плохо будет, короче, поэтому мы и контролируем сей момент, чтобы по крайней мере избежать иключения
            _id = id;
            Controller = controller;
            
        }
        Point locationHelper; //Немного ненужная переменная, для метода ниже, в процессе разработки может быть исключена, нужна для временного хранения позиции последней карты колоды
        public void TurnReaction(int id) //В классе контроллера, этот метод (точнее метод конкретного экземпляра) будет добавлен к обработчикам события смены хода, и принимать будет в себя переменную с ИДшником игрока, чей черед ходить
        {
            //Controller.CountAllScores();
            if (_id==id) //Важная строчка - проверяем, совпадает ли ИД текущего экземпляра класса с ИД того игрока, чей черед ходить
            {
                while (PlayerCounter<=16) //Глупенькая логика - пока число очков будет не больше 16, берем новые карты
                {
                    //Thread.Sleep(1500); //чтобы все не было мгновенно
                    locationHelper = currentMassiv.Last().Location; //
                    if (Controller.CurrentDeck.Count != 0)
                    {
                        currentMassiv.Add(Controller.CurrentDeck.Last());
                        currentMassiv.Last().Location = new Point(locationHelper.X + 20, locationHelper.Y + 20);
                        currentMassiv.Last().ShowBack();
                    }            
                    Controller.CardWasTaken(Id);
                    Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());
                    Controller.CountAllScores();
                    
                    
                    //Добавить карту на стол (нужен код)
                }
                if (PlayerCounter>21)
                {
                    //Код оповещения
                }
                if (PlayerCounter==21)
                {
                    
                }
                //Thread.Sleep(1000);
                Controller.NextTurn(id+1);
            }
        }

        public void CountScores()
        {
            PlayerCounter = 0;
           for (int i=0; i<CurrentMassiv.Count;i++)
            {
                
                PlayerCounter += currentMassiv[i].CardValue;
                //PlayerCounter += CurrentMassiv[i].CardValue;
            }
        }
        public void ShowAllCards()
        {
            foreach (BJCard crd in CurrentMassiv)
            {
                crd.ShowFace();
            }
        }

        public void TakeTwoStartCards()
        {

            if (Id == 1)
            {    //Первая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location = new Point(70, 230);
                currentMassiv.Last().ShowFace();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());
                //Вторая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location = new Point(90, 250);
                currentMassiv.Last().ShowFace();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());

                Controller.CardWasTaken(Id);

            }
            else
            if (Id == 2)
            {    //Первая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location = new Point(250, 230);
                currentMassiv.Last().ShowBack();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());
                //Вторая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location= new Point(270, 250);
                currentMassiv.Last().ShowBack();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());

                Controller.CardWasTaken(Id);

            }
            else
             if (Id == 3)
            {

                //Первая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location = new Point(430, 230);
                currentMassiv.Last().ShowBack();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());
                //Вторая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location = new Point(450,250);
                currentMassiv.Last().ShowBack();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());

                Controller.CardWasTaken(Id);
            }
            else
             if (Id == 4)
            {

                //Первая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location = new Point(610, 230);
                currentMassiv.Last().ShowBack();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());
                //Вторая карта
                currentMassiv.Add(Controller.CurrentDeck.Last());
                currentMassiv.Last().Location = new Point(630, 250);
                currentMassiv.Last().ShowBack();
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());

                Controller.CardWasTaken(Id);
            }
        }
    }
}
