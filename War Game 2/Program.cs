using System.ComponentModel;
using System.Diagnostics.Tracing;
using War_Game_2.Models;

Deck deck = new Deck();
deck.ShuffleDeck();

List<Card> pool = new List<Card>();

Player player1 = new Player();
Player player2 = new Player();
deck.DealCards(player1, player2);

Card player1Card;
Card player2Card;


while (player1.IsReady() || player2.IsReady())
{
    player1Card = player1.SendCard();
    player2Card = player2.SendCard();
    pool.Add(player1Card);
    pool.Add(player2Card);
    Console.WriteLine("Karta gracza 1 to " + player1Card.Rank + " of " + player1Card.Suit);
    Console.WriteLine("Karta gracza 2 to " + player2Card.Rank + " of " + player2Card.Suit);

    int n = player1Card.CompareCards(player2Card);
    switch (n)
    {
        case 1:
            Console.WriteLine("Wygrywa gracz 1");
            foreach (Card card in pool)
            {
                player1.ReceiveCard(card);
            }
            pool.Clear();
            break;
        case -1:
            Console.WriteLine("Wygrywa gracz 2");
            foreach (Card card in pool)
            {
                player2.ReceiveCard(card);
            }
            pool.Clear();
            break;
        case 0:
            Console.WriteLine();
            if (player1.IsReady() || player2.IsReady())
            {
                Console.WriteLine("Jedne z graczy nie ma już kolejnych kart do wyłożenia");
                break;
            }
            else
            {
                Console.WriteLine("Gracze wykładają po jednej zakrytej karcie");
                player1Card = player1.SendCard();
                player2Card = player2.SendCard();
                pool.Add(player1Card);
                pool.Add(player2Card);
            }
            break;
    }

}

if (player1.readyCheck() == false)
{
    Console.WriteLine("Wygrywa gracz 2");
}
else
{
    Console.WriteLine("Wygrywa gracz 1");
}

Console.ReadKey();