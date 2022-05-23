using System;
using System.Collections.Generic;

namespace Seller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new();
            store.Reception();
            store.Work();
        }
    }

    class Store
    {
        private readonly List<ShipmentProducts> products = new();
        private readonly Seller seller = new();
        private readonly Bayer bayer = new();

        public void Work()
        {
            string userInput;
            bool isWorking = true;

            seller.Voice(1);

            while (isWorking)
            {
                Console.WriteLine("  \n  1 - Купить товаров \n  2 - Проверить свои корзину  \n  3 - Выход");
                bayer.ShowWallet();            
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        BuyProduct();
                        break;
                    case "2":
                        bayer.ShowBoughtProduct();
                        break;
                    case "3":
                        isWorking = false;
                        break;
                }

                Console.Clear();
            }
        }

        public void Reception()
        {
            string name = null;
            int count = 1;

            foreach (Product product in Supplaier.Delivery())
            {
                if (name == product.Name)
                {
                    count++;
                }
                else
                {
                    if (name != null)
                    {
                        products.Add(new ShipmentProducts(product.Name, product.Price, product.Category, product.ExpirationDate, count));
                        count = 1;
                    }
                    name = product.Name;
                }
            }
        }

        private void BuyProduct()
        {
            int price;
            bool isWork = true;
            
            while (isWork == true) 
            {
                Console.Clear();
                bayer.ShowWallet();

                if (products.Count==0)
                {
                    seller.Voice(8);
                    Console.ReadLine();
                    break;
                }

                ShowGoods();

                if (SelectProduct(out ShipmentProducts product, out int  count) == false)
                { 
                    break;
                }

                price = product.Price * count;
                seller.Voice(5);
                Console.WriteLine($"{price}");
                bayer.BuyProduct(isWork, price);
                
                if (isWork == true)
                {
                    bayer.AddProduct(product, count);
                    isWork = false;
                }
                else
                {
                    seller.Voice(7);
                    Console.ReadLine();
                    break;
                }

                product.Sale(count);
                SaleProduct(product);
                seller.Voice(6);
                Console.ReadLine();
            }
        }

        private void ShowGoods()
        {
            int top;
            int leftPositionName = 8;
            int leftPositionPrice = 40;
            int LeftPositionExpirationDate = 60;
            int leftPositionNumber = 90;
            string line = null;

            for (int i = 0; i < leftPositionNumber + 3; i++)
            {
                line += '-';
            }

            Console.WriteLine("\n Номер:  Название товара:               Цена товара:         Срок гоности до <д/м/г>:      На прилавке есть(шт/кг)");
            Console.WriteLine(line);

            foreach (ShipmentProducts product in products)
            {
                top = Console.CursorTop;
                Console.Write($" {products.IndexOf(product)}");
                Console.SetCursorPosition(leftPositionName, top);
                Console.Write($" {product.Name}");
                Console.SetCursorPosition(leftPositionPrice, top);
                Console.Write($"{product.Price}");
                Console.SetCursorPosition(LeftPositionExpirationDate, top);
                Console.Write($"{product.ExpirationDate.Day} / {product.ExpirationDate.Month} /  {product.ExpirationDate.Year}");
                Console.SetCursorPosition(leftPositionNumber, top);
                Console.WriteLine($"{product.Quantity}");
                Console.WriteLine(line);
            }
        }

        private bool TryGetProduct(int number, out ShipmentProducts tryProduct)
        {
            tryProduct = null;
            bool isProductGet = false;

            foreach (ShipmentProducts product in products)
            {
                if (products.IndexOf(product) == number)
                {
                    tryProduct = products[products.IndexOf(product)];
                    isProductGet = true;
                    break;
                }
            }

            return isProductGet;
        }

        private void SaleProduct(ShipmentProducts tryProduct)
        {
            if (tryProduct.Quantity == 0)
            {
                products.RemoveAt(products.IndexOf(tryProduct));
            }
        }

        private bool SelectProduct(out ShipmentProducts tryProduct, out int count )
        {
            tryProduct=null;
            string inputNumber;
            string inputCount;
            bool isProductSelected = false;

            count = 0;
            seller.Voice(1);
            seller.Voice(2);
            inputNumber = Console.ReadLine();
            seller.Voice(3);
            inputCount = Console.ReadLine();

            if (int.TryParse(inputNumber, out int tryNumber) != true | int.TryParse(inputCount, out int tryCount) != true)
            {
                isProductSelected = false;
            }
            else
            {
                if (tryNumber > products.Count| tryNumber < 0 | tryCount == 0)
                {
                    isProductSelected = false;
                }
                else
                {
                    if (TryGetProduct(tryNumber, out ShipmentProducts product) == false | tryCount > product.Quantity)
                    {
                        isProductSelected = false;
                    }
                    else
                    {
                        count = tryCount;
                        tryProduct = product;
                        isProductSelected = true;
                    }
                }
            }

            if (isProductSelected == false)
            {
                seller.Voice(4);
                Console.ReadLine();
            }

            return isProductSelected;
        }
    }

    class Seller
    {
        private readonly List<string> _utterances=new();
        public Seller()
        {           
            List<string> groupUtterances = new()
            {
                "  Добро пожаловать в мой магазин!\n  Выбирайте что вам приглянется, все свежее!",
                "  Выберите понравившийся Вам товар указав его номер в списке и колличество ",
                "  Укажите номер:",
                "  Укажите количество",
                "  Вы ввели неверные данные",
                "  Цена выбранной позиции :",
                "  Удачная покупка!",
                "  У вас не достаточно средств",
                "  Извините, у нас закончился товар приходите завтра"
            };

            foreach (string utterence in groupUtterances)
            {
                _utterances.Add(utterence);
            }
        }

        public void Voice(int topic)        
        {
            ConsoleColor color = ConsoleColor.Green;
            Console.ForegroundColor = color;
            Console.WriteLine(_utterances[topic]);
            Console.ResetColor();
        } 
    }

    class Product
    {
        public string Name { get; }
        public int Price { get; }
        public int Category { get; }
        public DateTime ExpirationDate { get; }

        public Product(string name, int price, int category, DateTime expirationDate)
        {
            Name = name;
            Price = price;
            Category = category;
            ExpirationDate = expirationDate;
        }
    }

    class Bayer
    {
        private readonly Wallet wallet = new();
        private readonly ShoppingBasket shoppingBasket = new();

        public void ShowBoughtProduct()
        {
            shoppingBasket.ShowAllProduct();
        }

        public void AddProduct(Product product, int count)
        {
            shoppingBasket.AddProduct(product,count);
         }

        public bool BuyProduct(bool isPriceGet, int price)  
        {
            bool isPurchaseCompleted = false;

            if (isPriceGet == true)
            {
                isPurchaseCompleted = wallet.Purchase(price);
            }

            return isPurchaseCompleted;
        }

        public void ShowWallet()
        {
            wallet.ShowInfo();
        }
    }

    class Wallet
    {
        private readonly Random _random = new();
        private readonly int _minAmoutMoney = 2000;
        private readonly int _maxAmoutMoney = 7000;
        private readonly ConsoleColor color = ConsoleColor.Red;
        private readonly string currency = " руб.";
        private int _amoutMoney;

        public Wallet()
        {
            _amoutMoney = _random.Next(_minAmoutMoney, _maxAmoutMoney);
        }

        public bool Purchase(int purchasePrice)
        {
            bool isPurchaseCompleted = false;

            if (purchasePrice <= _amoutMoney)
            {
                _amoutMoney -= purchasePrice;
                isPurchaseCompleted = true;
                ShowInfo();
            }

            return isPurchaseCompleted;
        }

        public void ShowInfo()
        {
            int positionX = 5;
            int positionY = 50;
            int positionDefaultX = Console.CursorLeft;
            int positionDefaultY = Console.CursorTop;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(positionX, positionY);
            Console.WriteLine($"Сумма в кошельке : {_amoutMoney}{currency}");
            Console.SetCursorPosition(positionDefaultX, positionDefaultY);
            Console.ResetColor();
        }
    }

    class ShoppingBasket
    {
        private readonly List<ShipmentProducts> goods = new();

        public void AddProduct(Product product, int count)
        { 
            goods.Add(new ShipmentProducts(product.Name, product.Price, product.Category, product.ExpirationDate, count));
        }

        public void ShowAllProduct()
        {
            ConsoleColor color = ConsoleColor.Yellow;
            int positionX = 5;
            int positionY = 53;
            Console.ForegroundColor = color;
            int positionDefaultX = Console.CursorLeft;
            int positionDefaultY = Console.CursorTop;

            Console.SetCursorPosition(positionX, positionY-1);
            Console.Write($"В вашей корзине есть: ");

            foreach (ShipmentProducts product in goods)
            {
                Console.SetCursorPosition(positionX, positionY++);
                Console.WriteLine($"{product.Quantity} шт/кг {product.Name}, Цена 1 шт/кг: {product.Price},  Срок гоности до : {product.ExpirationDate.Day} / {product.ExpirationDate.Month} /  {product.ExpirationDate.Year}"  );
            }

            Console.SetCursorPosition(positionDefaultX, positionDefaultY);
            Console.ResetColor();
            Console.ReadLine();
        }
    }

    class ShipmentProducts : Product
    {
        public int Quantity { get; private set; }

        public ShipmentProducts(string name, int price, int idCategory, DateTime expirationDate, int number)
            : base(name, price, idCategory, expirationDate)
        {
            Quantity = number;
        }

        public void Sale( int count )
        {
            Quantity -= count;  
        }
    }

    class Supplaier
    {
        private static List<Product> OrderAssembly()
        {
            Random random = new();
            List<Product> goods = new();
            int _minPrice = 25;
            int _maxPrice = 2500;
            int category=0;
            int ExpirationYear = 2022;
            DateTime _moment = new (ExpirationYear, 1, 1);
            int maxOrderCount=10;
            int minOrderCount = 1;

            List<string> goodsGroupByKilograms = new()
            {
                "Клубника ранняя",
                "Яблоко",
                "Груша",
                "Айва",
                "Rонфеты Карнавальная Маска",
                "Кекс с изюмом"
            };
            List<string> goodsGroupByPiece = new()
            {
                "Шоколадка Аленка",
                "Пирожок с капустой",
                "Пирожок с картошкой","Cafe Pele",
                "Nescafe Gold",
                "Greenfield Black Tea",
                "Лисма"
            };
            List<string> ListOfGroup;

            while (category!=1)
            {
                if (goods.Count == 0)
                {
                    ListOfGroup = goodsGroupByKilograms;
                    category = 0;
                }
                else
                {
                    ListOfGroup = goodsGroupByPiece;
                    category = 1;
                }

                foreach (string product in ListOfGroup)
                {
                    int ExpirationDay = random.Next(366);
                    int randomPrice = random.Next(_minPrice, _maxPrice);
                    int orderCount = random.Next(minOrderCount, maxOrderCount);

                    _moment.AddDays(ExpirationDay);
                    for (int i = 0; i <= orderCount; i++)
                    {
                        goods.Add(new Product(product, randomPrice, category, _moment.AddDays(ExpirationDay)));
                    }                   
                }
            }

            return goods;
        }

        public static List<Product> Delivery()
        {
            return OrderAssembly();
        }
    }
}
