﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class BJCard:PictureBox //Наследуем все свойства и события от класса Picturebox, чтобы добавить функциональность
    {
       //Ниже переменные, введенные сверху, оборачиваются в свойства (никакого глубокого смысла это не несет, но это делают умные программисты)
        public int CardValue { get; set; }
        private Image BackImage { get; set; }
        private Image FrontImage { get; set; }

        
        public BJCard(Image frontImage, Image backImage, int cardValue) //При создании экземпляра карты, надо передать в него передник, рубашку, и номинал. В дальнейшем, возможно, придется отказаться от конструктора, чтобы инициализировать все эти свойства напрямую, а то это не кашерно как-то
        {
            //Ну эт понятно
            BackImage = backImage;
            FrontImage = frontImage;
            CardValue = cardValue;
            //А эт, мб, не понятно
            SizeMode=PictureBoxSizeMode.StretchImage; //Делаем так, чтобы картинка(текущая) растягивалась на всю ширину нашего контрола
            Size = new Size(77, 103);

        }

        public void ShowFace()//Показываем передник
        {
            Image = FrontImage; //Image - это свойство, наследуемое от Picturebox, оно содержит ссылку на картинку, которая отображается в данный момент
        }
        public void ShowBack()//Показываем рубашку
        {
            Image = BackImage;
        }
    }
}
