using System.ComponentModel;
using System.Diagnostics.Tracing;
using War_Game_2.Models;

Deck deck = new Deck();
List <Card> pool  = new List<Card>();
deck.ShuffleDeck();
Player player1 = new Player();
Player player2 = new Player();

player1.Name = "gracz1";
player2.Name = "gracz2";
deck.DealCards(player1, player2);

Card player1Card;
Card player2Card;


bool gameOver = false;
while (!gameOver)
{
    if (player1.readyCheck() == false || player2.readyCheck() == false)
    {
        gameOver = true;
        Console.WriteLine("Jedne z graczy nie ma już kolejnych kart do wyłożenia");
    }
    else
    {
        player1Card = player1.SendCard();
        player2Card = player2.SendCard();
        pool.Add(player1Card);
        pool.Add(player2Card);
        Console.WriteLine("pobrano karty");
        Console.WriteLine("Karta gracza 1 to " + player1Card.Name + " " + player1Card.Suit);
        Console.WriteLine("Karta gracza 2 to " + player2Card.Name + " " + player2Card.Suit);

        // porównanie kart
        // gracz 1 wygrywa
        if (player1Card.Value > player2Card.Value)
        {
            Console.WriteLine("Karta gracza 1 jest mocniejsza. Gracz 1 zgarnia karty z puli");
            foreach (Card card in pool)
            {
                player1.ReceiveCard(card);
            }
            pool.Clear();
        }
        // gracz 2 wygrywa
        else if (player1Card.Value < player2Card.Value)
        {
            Console.WriteLine("Karta gracza 2 jest mocniejsza. Gracz 2 zgarnia karty z puli");
            foreach (Card card in pool)
            {
                player2.ReceiveCard(card);
            }
            pool.Clear();
        }
        // remis
        else
        {
            Console.WriteLine("remis");
            if (player1.readyCheck() == false || player2.readyCheck() == false)
            {
                gameOver = true;
                Console.WriteLine("Jedne z graczy nie ma już kolejnych kart do wyłożenia");
            }
            else
            {
                Console.WriteLine("Gracze wykładają po jednej zakrytej karcie");
                player1Card = player1.SendCard();
                player2Card = player2.SendCard();
                pool.Add(player1Card);
                pool.Add(player2Card);
            }

        }
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