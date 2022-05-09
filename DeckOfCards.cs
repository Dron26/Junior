using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    internal class Program
    {      
        static void Main(string[] args)
        {
            DeckOfCard deckOfCard = new DeckOfCard();
            Player player = new Player(deckOfCard.CountCardInDeck);
            bool isWork = true;
            ConsoleKeyInfo userInput;
            Program program = new Program();

            Console.WriteLine("  Сегодня день фокусов!\n  Достаньте любое количество карт и я угадаю какие вы карты достали!\n  Обещаю не подглядывать!");
            Console.ReadLine();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("  Дстать карту -  жмакай Enter\n  Сказать какие ты  взял карты - жмакай Space\n  " +
                    $"Выйти - жмакай ESC\n\n" );
                player.ShowCountCards();

                userInput = Console.ReadKey(true);
              
                switch (userInput.Key)
                {
                    case ConsoleKey.Enter:
                        program.TryPlayerTakeCard(deckOfCard, player);
                        break;
                    case ConsoleKey.Spacebar:
                        player.ShowDeck();
                        break;
                    case ConsoleKey.Escape:
                        isWork = false;
                        break;
                }
            }
        }

        private bool TryPlayerTakeCard( DeckOfCard deckOfCard, Player player)
        {
            if (deckOfCard.IsCardGiven(out Card card) == true)
            {
                player.TakenCard(card);
                return true;
            }
            else
            {
                Console.WriteLine("ты выгреб всю колоду! Теперь нечего отгадывать))");
                Console.ReadLine() ;
                return false;
            }
        }
    }



    class DeckOfCard
    {
        private List<string> Advantage = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
        private List<string> Suit = new List<string> { "Трефы", "Бубны", "Червы", "Пики", };
        private static List<Card> Deck = new List<Card>();
        private Random random = new Random();
        private int randomNumber;
        private int countCardTaken = Deck.Count;

        public int CountCardInDeck => Deck.Count;

        public DeckOfCard()
        {
            foreach (string suit in Suit)
            {
                foreach (string advantage in Advantage)
                {
                    Deck.Add(new Card(advantage , suit));                    
                }
            }
            SortDeck();
        }

        public bool IsCardGiven(out Card card)
        {
            randomNumber = random.Next(0, CountCardInDeck);
            bool isCardGiven = false;
            card = null;

            if (Deck.Count == 0)
            {
                return isCardGiven = false;
            }
            else
            {
                while (isCardGiven == false)
                {
                    if (Deck[randomNumber] != null)
                    {
                        card = Deck[randomNumber];
                        Deck.Remove(card);
                        isCardGiven = true;
                    }
                    else
                    {
                        randomNumber = random.Next(0, CountCardInDeck);
                        isCardGiven = false;
                    }
                }

                return isCardGiven;
            }
        }

        private void SortDeck()
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                randomNumber = random.Next(0, Deck.Count);
                Card value = Deck[i];
                Deck[i] = Deck[randomNumber];
                Deck[randomNumber] = value;
            }
        }

    }

    class Card
    {
        public string Advantage { get; }
        public string Suit { get; }
        public Card(string advantage, string suit)
        {
            Advantage = advantage;
            Suit = suit;
        }
    }

    class Player
    {
        private int _countCardInDeck;
        private List<Card> _takenCards = new List<Card>();

        public Player(int number)
        {
            _countCardInDeck= number;
        }

        public void TakenCard(Card card)
        {
            _takenCards.Add(card);
        }

        public void ShowDeck()
        {
            Console.Clear();

            foreach (Card card in _takenCards)
            {
                Console.WriteLine($"{card.Advantage}-{card.Suit}");
            }

            Console.ReadLine();
        }

        public void ShowCountCards()
        {
            int count = _takenCards.Count%10;
            string text = $"У вас в руках {_takenCards.Count}";
            if (count > 0 && count < 2)
                text=$"{text} карта";
            else if (count > 1 && count < 5)
                text=$"{text} карты";
            else if (count == 0 || count > 4 && count <= 10)
                text=$"{text} карт";
            Console.WriteLine(text);
        }
    }
}
