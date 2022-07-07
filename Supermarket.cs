using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new();

            while (supermarket.GetCustomersQueue() != 0)
            {
                supermarket.Work();
                supermarket.SaleAtCheckout();
                Console.ReadLine();
                Console.Clear();
            }

            supermarket.Close();
        }
    }

    class Supermarket
    {

        private Queue<Bayer> _customersQueue = new();
        private List<Product> _goods = new();
        private readonly Random _random = new ();

        public Supermarket()
        {
            CreateProduct();
            CreateCustomersQueue();
            FillShoppingBasket();

        }

        public void Work()
        {
            Console.WriteLine("  Меню управления Супермаркетом \n\n");
            Console.Write($"  {_customersQueue.Count}");
            Console.WriteLine("  покупателей на текущий момент в очереди");
            Console.WriteLine("  Сейчас на кассе находится клиент");
            GetAmountPurchase(_customersQueue.Peek());
            Console.WriteLine($"  Сумма его товаров к покупке: {GetAmountPurchase(_customersQueue.Peek())} руб");
            Console.ReadLine();
            Console.Clear();
        }

        public void SaleAtCheckout()
        {
            Bayer bayer = _customersQueue.Peek();
            int AmountInWallet = bayer.GetAmountInWallet();

            if (GetAmountPurchase(bayer) >= AmountInWallet)
            {
                ReturnProducts(bayer);
            }

            Console.WriteLine(" У покупателя достаточно средств, он произвел оплату и покинул магазин");
            bayer.BuyProduct(GetAmountPurchase(bayer));
            _customersQueue.Dequeue();
        }

        public int GetCustomersQueue()
        {
            return _customersQueue.Count;
        }

        public void Close()
        {
            Console.WriteLine("  Все покупатели преобрели товар и покинули магазин.Приходите еще!");
            Console.ReadLine();
            Console.Clear();
        }

        private void CreateCustomersQueue()
        {
            int countCustomer = 10;

            for (int i = 0; i <= countCustomer; i++)
            {
                _customersQueue.Enqueue(new Bayer());
            }
        }

        private void FillShoppingBasket()
        {
            Random random = new ();
            int numberProduct;
            int countProductShoppingBasket = 10;

            foreach (Bayer bayer in _customersQueue)
            {
                for (int i = 0; i < countProductShoppingBasket; i++)
                {
                    numberProduct = random.Next(0, _goods.Count);

                    bayer.AddProduct(_goods[numberProduct]);
                }
            }
        }

        private int GetAmountPurchase(Bayer bayer)
        {
            int amountPurchase = 0;
            foreach (Product product in bayer.GetProductShoppingBasket())
            {
                amountPurchase += product.Price;
            }
            return amountPurchase;
        }

        private List<Product> CreateProduct()
        {
            Random random = new();
            int minPrice = 25;
            int maxPrice = 2500;
            int maxOrderCount = 5;
            int minOrderCount = 1;

            List<string> goodsGroupByKilograms = new()
            {
                "Клубника ранняя",
                "Яблоко",
                "Груша",
                "Айва",
                "Rонфеты Карнавальная Маска",
                "Кекс с изюмом",
                "Шоколадка Аленка",
                "Пирожок с капустой",
                "Пирожок с картошкой",
                "Кофе Cafe Pele",
                "Кофе Nescafe Gold",
                "Чай Greenfield Black Tea",
                "Чай Лисма"
            };

            foreach (string product in goodsGroupByKilograms)
            {
                int randomPrice = random.Next(minPrice, maxPrice);
                int orderCount = random.Next(minOrderCount, maxOrderCount);

                for (int i = 0; i <= orderCount; i++)
                {
                    _goods.Add(new Product(product, randomPrice));
                }
            }


            return _goods;
        }

        private void ReturnProducts(Bayer bayer)
        {
            int numberReturnProduct;
            List<Product> products = new();
            products = bayer.GetProductShoppingBasket();
            Console.WriteLine("  У покупателя недостаточно средств,\n ему необходимо вернуть часть товаров \n\n");

            while (GetAmountPurchase(bayer) >= bayer.GetAmountInWallet())
            {
                numberReturnProduct = _random.Next(0, products.Count);
                Console.WriteLine($"  Возврат товара: {products[numberReturnProduct].Name}   -   цена товара:  {products[numberReturnProduct].Price}");
                bayer.ReturnProducts(numberReturnProduct);
            }
            Console.WriteLine("  \n\n Теперь остался товар доступный  для покупки");
        }

    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    class Bayer
    {
        private readonly Wallet _wallet = new();
        private readonly ShoppingBasket _shoppingBasket = new();

        public void AddProduct(Product product)
        {
            _shoppingBasket.AddProduct(product);
        }

        public void BuyProduct(int price)
        {
            _wallet.Purchase(price);
        }

        public int GetAmountInWallet()
        {
            return _wallet.GetAmount();
        }

        public List<Product> GetProductShoppingBasket()
        {
            return _shoppingBasket.GetProducts();
        }

        public void ReturnProducts(int numberReturnProduct)
        {
            _shoppingBasket.ReturnProduct(numberReturnProduct);
        }

    }

    class Wallet
    {
        private readonly Random _random = new();
        private readonly int _minAmoutMoney = 10000;
        private readonly int _maxAmoutMoney = 15000;
        private int _amoutMoney;

        public Wallet()
        {
            _amoutMoney = _random.Next(_minAmoutMoney, _maxAmoutMoney);
        }

        public void Purchase(int purchasePrice)
        {
                _amoutMoney -= purchasePrice;
        }

        public int GetAmount()
        {
            return _amoutMoney;
        }
    }

    class ShoppingBasket
    {
        private readonly List<Product> _goods = new();

        public void AddProduct(Product product)
        {
            _goods.Add(new Product(product.Name, product.Price));
        }

        public List<Product> GetProducts()
        {
            return _goods;
        }

        public void ReturnProduct(int numberReturnProduct)
        {
            _goods.RemoveAt(numberReturnProduct);
        }
    }







}
