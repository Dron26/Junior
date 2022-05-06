using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeckOfCard deckOfCard = new DeckOfCard();
            Player player = new Player();
            bool isWork = true;
            ConsoleKeyInfo userInput;

            Console.WriteLine("  Сегодня день фокусов!\n  Достаньте любое количество карт и я угадаю какие вы карты достали!\n  Обещаю не подглядывать!");
            Console.ReadLine();


            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("  Дстать карту -  жмакай Enter\n  Сказать какие ты  взял карты - жмакай Space\n  Выйти - жмакай ESC");
                userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.Enter:
                        isWork = player.TakeCard(deckOfCard.DeckOfCardCount());
                        break;
                    case ConsoleKey.Spacebar:
                        deckOfCard.ShowGivenCards(player.TakenCards);
                        break;
                    case ConsoleKey.Escape:
                        isWork = false;
                        break;
                }

            }

        }

    }

    class DeckOfCard
    {
        Card card = new Card();
        private static Dictionary<int, string> Deck = new Dictionary<int, string>();
        
        public DeckOfCard()
        {
            CreatrDeck();
            SortDeck();
        }
        public int DeckOfCardCount()
        {
            int countCardInDeck = Deck.Count;
            return countCardInDeck;
        }

        public void CreatrDeck()
        {
            int id = 0;

            foreach (string suit in card.Suit)
            {
                foreach (string advantage in card.Advantage)
                {

                    Deck.Add(id, advantage+ "  "+suit  );
                    id++;
                }
            }
        }

        public void SortDeck()
        {
            Random random = new Random();

            for (int i = 0; i < Deck.Count; i++)
            {
                int number = random.Next(0, Deck.Count);
                string valueAdvantage = Deck[i];
                string valueSuit = Deck[i];
                Deck[i] = Deck[number];
                Deck[i] = Deck[number];
                Deck[number] = valueAdvantage;
                Deck[number] = valueSuit;
            }
        }

        public void ShowGivenCards(List<int> TakenCards)
        {
            Console.Clear();
            Console.WriteLine("Ты взял из колоды: ");

            for (int i = 0; i < TakenCards.Count; i++)
            {
                Console.WriteLine($"{Deck[TakenCards[i]]} ");
            }

            Console.ReadLine();
        }

    }

    class Card
    {
        public List<string> Advantage = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };
        public List<string> Suit = new List<string> { "Трефы", "Бубны", "Червы", "Пики", };

    }

    class Player
    {        
        Random random = new Random();
        int randomCard;
        private List<int> _takenCards = new List<int>();

        public bool TakeCard(int countCardInDeck)
        {
            bool isCardTaken = false;

            if (TakenCards.Count == countCardInDeck)
            {
                Console.WriteLine("ты выгреб всю колоду! Теперь нечего отгадывать))");
                return isCardTaken = false;
            }
            else
            {
                while (isCardTaken == false)
                {
                    randomCard = random.Next(0, countCardInDeck);

                    if (TakenCards.Count == 0)
                    {
                        TakenCards.Add(randomCard);
                        isCardTaken = true;
                    }
                    else
                    {
                        if (!TakenCards.Contains(randomCard))
                        {
                            TakenCards.Add(randomCard);
                            isCardTaken = true;
                        }

                    }

                }

                return isCardTaken = true;
            }

        }

        public List<int> TakenCards
        {
            get { return _takenCards; }
        }

    }
}
