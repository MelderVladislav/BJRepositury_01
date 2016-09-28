using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
  static  class BJMassiv
    {
        
       static public List<BJCard>  GetUsualCards()
        {
            List<BJCard> cardMassiv = new List<BJCard>();
            cardMassiv.Add(new BJCard(Properties.Resources._6_of_clubs,Properties.Resources.X9CDPAqV7UY,6));
            cardMassiv.Add(new BJCard(Properties.Resources._6_of_diamonds, Properties.Resources.X9CDPAqV7UY, 6));
            cardMassiv.Add(new BJCard(Properties.Resources._6_of_hearts, Properties.Resources.X9CDPAqV7UY, 6));
            cardMassiv.Add(new BJCard(Properties.Resources._6_of_spades, Properties.Resources.X9CDPAqV7UY, 6));

            cardMassiv.Add(new BJCard(Properties.Resources._7_of_clubs, Properties.Resources.X9CDPAqV7UY, 7));
            cardMassiv.Add(new BJCard(Properties.Resources._7_of_diamonds, Properties.Resources.X9CDPAqV7UY, 7));
            cardMassiv.Add(new BJCard(Properties.Resources._7_of_hearts, Properties.Resources.X9CDPAqV7UY, 7));
            cardMassiv.Add(new BJCard(Properties.Resources._7_of_spades, Properties.Resources.X9CDPAqV7UY, 7));

            cardMassiv.Add(new BJCard(Properties.Resources._8_of_clubs, Properties.Resources.X9CDPAqV7UY, 8));
            cardMassiv.Add(new BJCard(Properties.Resources._8_of_diamonds, Properties.Resources.X9CDPAqV7UY, 8));
            cardMassiv.Add(new BJCard(Properties.Resources._8_of_hearts, Properties.Resources.X9CDPAqV7UY, 8));
            cardMassiv.Add(new BJCard(Properties.Resources._8_of_spades, Properties.Resources.X9CDPAqV7UY, 8));

            cardMassiv.Add(new BJCard(Properties.Resources._9_of_clubs, Properties.Resources.X9CDPAqV7UY, 9));
            cardMassiv.Add(new BJCard(Properties.Resources._9_of_diamonds, Properties.Resources.X9CDPAqV7UY, 9));
            cardMassiv.Add(new BJCard(Properties.Resources._9_of_hearts, Properties.Resources.X9CDPAqV7UY, 9));
            cardMassiv.Add(new BJCard(Properties.Resources._9_of_spades, Properties.Resources.X9CDPAqV7UY, 9));

            cardMassiv.Add(new BJCard(Properties.Resources._10_of_clubs, Properties.Resources.X9CDPAqV7UY, 10));
            cardMassiv.Add(new BJCard(Properties.Resources._10_of_diamonds, Properties.Resources.X9CDPAqV7UY, 10));
            cardMassiv.Add(new BJCard(Properties.Resources._10_of_hearts, Properties.Resources.X9CDPAqV7UY, 10));
            cardMassiv.Add(new BJCard(Properties.Resources._10_of_spades, Properties.Resources.X9CDPAqV7UY, 10));

            cardMassiv.Add(new BJCard(Properties.Resources.jack_of_clubs2, Properties.Resources.X9CDPAqV7UY, 2));
            cardMassiv.Add(new BJCard(Properties.Resources.jack_of_diamonds2, Properties.Resources.X9CDPAqV7UY, 2));
            cardMassiv.Add(new BJCard(Properties.Resources.jack_of_hearts2, Properties.Resources.X9CDPAqV7UY, 2));
            cardMassiv.Add(new BJCard(Properties.Resources.jack_of_spades2, Properties.Resources.X9CDPAqV7UY, 2));

            cardMassiv.Add(new BJCard(Properties.Resources.queen_of_clubs2, Properties.Resources.X9CDPAqV7UY, 3));
            cardMassiv.Add(new BJCard(Properties.Resources.queen_of_diamonds2, Properties.Resources.X9CDPAqV7UY, 3));
            cardMassiv.Add(new BJCard(Properties.Resources.queen_of_hearts2, Properties.Resources.X9CDPAqV7UY, 3));
            cardMassiv.Add(new BJCard(Properties.Resources.queen_of_spades2, Properties.Resources.X9CDPAqV7UY, 3));

            cardMassiv.Add(new BJCard(Properties.Resources.king_of_clubs2, Properties.Resources.X9CDPAqV7UY, 4));
            cardMassiv.Add(new BJCard(Properties.Resources.king_of_diamonds2, Properties.Resources.X9CDPAqV7UY, 4));
            cardMassiv.Add(new BJCard(Properties.Resources.king_of_hearts2, Properties.Resources.X9CDPAqV7UY, 4));
            cardMassiv.Add(new BJCard(Properties.Resources.king_of_spades2, Properties.Resources.X9CDPAqV7UY, 4));

            cardMassiv.Add(new BJCard(Properties.Resources.ace_of_clubs, Properties.Resources.X9CDPAqV7UY, 11));
            cardMassiv.Add(new BJCard(Properties.Resources.ace_of_diamonds, Properties.Resources.X9CDPAqV7UY,11));
            cardMassiv.Add(new BJCard(Properties.Resources.ace_of_hearts, Properties.Resources.X9CDPAqV7UY,11));
            cardMassiv.Add(new BJCard(Properties.Resources.ace_of_spades2, Properties.Resources.X9CDPAqV7UY, 11));

            Random ran = new Random();
            // var cardMassivFinal = cardMassiv.OrderBy(item => (new Random()).Next()).ToList();

            var cardMassivFinal = cardMassiv.OrderBy(item => ran.Next()).ToList();
            return cardMassivFinal;



        }

    }
}
