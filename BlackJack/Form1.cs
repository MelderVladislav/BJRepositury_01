using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace BlackJack
{
    
    public partial class Form1 : Form
    {
        BJController Controller; //Подготовили ссылку для экземпляра класса с необходимыми методами
        public Form1(int num)
        {
            InitializeComponent(); //это здесь по дефолту
            Controller = new BJController(this);//присваиваем переменной значение экземпляра класса, и передаем в него экземпляр текущей формы (this - это текущий экземпляр Form1)
            // конструктор этой формы принимает в себя целое число, и в зависимости от того, чему оно равно, мы и вводим нужное количество игроков
            if (num == 2) Controller.CreateTwoPlayers(); //методы можно посмотреть в классе BJController
            else if (num == 3) Controller.CreateThreePlayers();
            else if (num==4) Controller.CreateFourPlayers();
            

        }
        public void ShowMessage(string Message) //Этот метод пригодится, если понадобится вывести сообщение в текущей форме, из класса BJController это сделать напрямую проблематично
        {
            MessageBox.Show(Message); //Эта функция выведет сообщение, которое будет передано в метод
        }
        private void pictureBox1_Click(object sender, EventArgs e) //обработчик кнопки "Хватит" (красная)
        {
            Controller.NextTurn(2); //Метод NextTurn вызывает событие, принимающее идентификатор следующего игрока, в данном случае он равен 2, тк как этот обработчик способен вызвать только игрок-человек, а так как игроку-человеку мы назначаем ИД равный 1, то следующим будет виртуальный игрок и ИД равным 2
        }

        private void pictureBox2_Click(object sender, EventArgs e) //обработчик кнопки "Еще" (Зеленая)
        {
            if (Controller.CurrentDeck.Count != 0) //Это сделано во избежание ситуации, когда в колоде не осталось карт, а игрок берет новую (тогда возникнет исключение)
            {
                Controller.MainPlayer.CurrentMassiv.Add(Controller.CurrentDeck.Last()); //MainPlayer(игрок человек) у нас выведен в отдельное поле класса BJControl, так им легче управлять, в данном случае мы добавляем в массив его карт новую из колоды (колода тоже выведена отдельным свойством в классе BJControl
                Controller.CurrentDeck.Remove(Controller.CurrentDeck.Last());//Теперь надо удалить из колоды взятую карту
                Controller.MainPlayer.CurrentMassiv.Last().Location = Controller.MainPlayer.CurrentMassiv[Controller.MainPlayer.CurrentMassiv.Count - 2].Location; //Только что мы пополнили массив карт игрока новой картой, она стала в ней ПОСЛЕДНЕЙ, но у нее еще нет конкретной позиции, поэтому мы присваиваем ей позицию ПРЕДПОСЛЕДНЕЙ карты, чтобы в следующей строчке его чуть скорректировать
                Controller.MainPlayer.CurrentMassiv.Last().Location = new Point(Controller.MainPlayer.CurrentMassiv.Last().Location.X + 20, Controller.MainPlayer.CurrentMassiv.Last().Location.Y + 20); //Здесь мы чуть изменяем позицию последней карты, чтобы она была на 20 пикселей правей и 20 пикселей ниже ПРЕДЫДУЩЕЙ карты. Здесь важно отметить, что данная операция еще не добавляет карту в форму, а просто дает ей свойство Location
                
                Controller.MainPlayer.CurrentMassiv.Last().ShowFace();//Метод ShowFace класса BJCard делает основной картинкой (картинкой, которая отображается) передник карты (карта, где указан ее номинал)
                Controls.Add(Controller.MainPlayer.CurrentMassiv.Last());//Этим действием мы добавляем и отображаем ПОСЛЕДНЮЮ карту в массиве главного игрока(человека) на форму

                Controller.MainPlayer.CountScores(); //Этот метод осуществляет подсчет очков 
            }
        }
        public void UpdateGamesCount(string str)//Этот метод обновляет Label, где отображается количество прошедших игр
        {
            GameCounterLabel.Text = str; 
        }
        public void ResetAll(string message) //Метод завершения игры
        {
           
            MessageBox.Show(message);//Здесь выводится финальное сообщение
            this.Close();//Здесь окно игры закрывается 

        }
    }
}
