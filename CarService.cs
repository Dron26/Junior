using System;
using System.Collections.Generic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AutoRepairShop autoRepairShop = new();
            autoRepairShop.Work();
        }
    }

    class AutoRepairShop
    {
        private readonly string _currency;
        private readonly Queue<Client> _clientsQueue = new();
        private readonly Warehouse _warehouse = new();
        private readonly RepairMaster _repairMaster;
        private readonly CashRegister _cashRegister = new();
        private readonly Random _random = new();

        public AutoRepairShop()
        {
            _repairMaster = new("Борис");
            _currency = " руб.";
        }

        public void Work()
        {
            bool _isSelectExite = false;
            bool _isStoreliquidation = false;

            ShowMenuStart();

            if (IsStoreOpen())
            {
                CreateCustomersQueue();

                while (_isSelectExite == false & _clientsQueue.Count != 0)
                {
                    _isSelectExite = ActionSelection();
                }

                ShowExiteText(_isStoreliquidation);
            }
        }

        private void ShowMenuStart()
        {
            Console.WriteLine("");
            Console.WriteLine("Добро пожаловать в автомастерскую");
            Console.WriteLine("1 - Приступить к работе");
            Console.WriteLine("Другое - Выход");
        }

        private bool IsStoreOpen()
        {
            string userInput = Console.ReadLine();
            Console.Clear();
            return userInput == "1";
        }

        private void CreateCustomersQueue()
        {
            int countCustomer = 10;
            string randomName;

            List<string> names = new()
            {
                "Александр",
                "Михаил",
                "Даниил",
                "Матвей",
                "Иван",
                "Кирилл",
                "Егор",
                "Дмитрий",
                "Роман",
                "Артем",
                "Анна",
                "Мария",
                "Софья",
                "Александра",
                "Ксения",
                "Василиса",
                "Анастасия",
                "Алиса",
                "Вероника",
                "Полина",
            };

            for (int i = 0; i <= countCustomer; i++)
            {
                randomName = names[_random.Next(0, names.Count)];
                _clientsQueue.Enqueue(new Client(randomName));
            }
        }

        private void ReceiveCar()
        {
            Client client = _clientsQueue.Dequeue();
            int sleepTimeStep = 80;
            int countStepForSleep = 7;
            int count = 0;
            int price;
            bool isReplacementDetailDishonest = false;
            Detail brokenDetail;
            Car clientCar = client.Car;
            bool isDetailRepaired = false;

            Console.Clear();
            Console.WriteLine($"Клиент - {client.Name} : Добрый день! Вот моя машина, пожалуйста проверьте ее, что то барахлит");
            Console.WriteLine($"Мастер сервиса - {_repairMaster.Name}: хорошо сейчас проверим!");

            while (count != countStepForSleep)
            {
                System.Threading.Thread.Sleep(sleepTimeStep);
                Console.Write(" . ");
                count++;
            }

            brokenDetail = clientCar.BrokenDetail;
            price = _warehouse.GetPriceDetail(brokenDetail.Name);

            Console.WriteLine($"{_repairMaster.Name}: Я обнаружил сломанную деталь, это: {client.Car.BrokenDetail.Name}");
            Console.WriteLine($"{_repairMaster.Name}: Стоимость детали и ремонта составит: {price} {_currency}");

            if (IsClientSolvent(client, price) == false)
            {
                Console.WriteLine($"{_repairMaster.Name}: У вас недостаточно средств, пожалуйста покиньте ремонтный бокс и возвращайтесь когда у вас появятся средства.Извините");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{_repairMaster.Name}: Так как у вас достаточно средств, предлагаю замену детали");
                Console.WriteLine($"{client.Name}: Хорошо меняем!");

                Console.ReadLine();

                if ((_warehouse.TryGetDetail(brokenDetail.Name, out Cell newDetail) == false))
                {
                    isReplacementDetailDishonest = true;

                }

                isDetailRepaired = TryReplacementDetail(client, newDetail, isReplacementDetailDishonest);

                if (isDetailRepaired == true)
                {
                    _cashRegister.ReplenishesFunds(price);
                    client.Buy(price);
                    Console.WriteLine("Замена прошла удачно!");
                    Console.WriteLine("Клиент оплатил работу и покинул сервис!");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{_repairMaster.Name}: К сожалению на складе автосервиса отсутствует необходимая деталь.");
                    BonusPayment(price, client);
                }

                if (isReplacementDetailDishonest == true & isDetailRepaired == true)
                {
                    if (ChanceFindViolation() == true)
                    {
                        Console.Clear();
                        Console.WriteLine(" Удача на стороне клиента, он обнаружил нарушение! Сервис заменил не ту деталь!");
                        BonusPayment(price, client);
                    }
                }
            }
        }

        private bool ActionSelection()
        {
            bool _isSelectExite = false;
            string userInput;

            Console.Clear();
            Console.WriteLine("  Наш автосервис популярен к нам выстроилась очередь из клиентов на ремонт авто");
            Console.WriteLine("  Нажмите:\n  1 - Чтобы принять клиента");
            Console.WriteLine("  2 - Посетить склад запчастей");
            Console.WriteLine("  3 - Закрыть автосервис");
            Console.WriteLine($"  \n\nБаланс средств:  {_cashRegister.AmoutMoney} {_currency}");

            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ReceiveCar();
                    break;
                case "2":
                    VisitWarehouse();
                    break;
                case "3":
                    _isSelectExite = true;
                    break;
            }

            return _isSelectExite;
        }

        private void VisitWarehouse()
        {
            string userInput;

            Console.Clear();
            Console.WriteLine("  Нажмите:\n  1 - Проверить сток запчастей");
            Console.WriteLine("  2 - Закупить детали");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ShowStockDetailsWarehouse();
                    break;
                case "2":
                    PurchaseDetails();
                    break;
            }

            Console.Clear();
        }

        private void ShowStockDetailsWarehouse()
        {
            Console.WriteLine("  В наличии на складе:");

            foreach (Cell cell in _warehouse.GetDetailsInStock())
            {
                Console.WriteLine($"{cell.Name}  -   {cell.Quantity}шт, цена за штуку {cell.Price} {_currency}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void PurchaseDetails()
        {
            string userInput;
            bool isDetailBuy = false;
            bool isEnoughMoney = true;
            bool isInputExite = false;
            Dictionary<string, int> DetailsGroup = _warehouse.GetDetailsGroup();
            DetailForWarehouse soughtDetail;

            while (isDetailBuy == false & isEnoughMoney == true & isInputExite == false)
            {
                Console.Clear();
                Console.WriteLine("  Для выхода нажмите (E)xite\n");
                Console.WriteLine($"  Баланс средств:  {_cashRegister.AmoutMoney} {_currency}");
                Console.WriteLine("  Введите название детали для ее покупки:\n");

                ShowDetailGroup(DetailsGroup);

                userInput = Console.ReadLine();

                if (userInput.ToLower() == "e")
                {
                    isInputExite = true;
                }
                else
                {
                    soughtDetail = new DetailForWarehouse(userInput, _warehouse.GetPriceDetail(userInput));

                    foreach (Cell cell in _warehouse.GetDetailsInStock())
                    {
                        if (cell.Name == soughtDetail.Name)
                        {
                            if (_cashRegister.DebitsFunds(soughtDetail.Price) == true)
                            {
                                _warehouse.AddDetail(soughtDetail);
                                isDetailBuy = true;
                                break;
                            }
                            else
                            {
                                isEnoughMoney = false;
                                break;
                            }
                        }
                    }

                    if (isDetailBuy == false & DetailsGroup.ContainsKey(soughtDetail.Name))
                    {
                        if (_cashRegister.DebitsFunds(soughtDetail.Price) == true)
                        {
                            _warehouse.CreateDetail(soughtDetail);
                            isDetailBuy = true;
                        }
                        else
                        {
                            isEnoughMoney = false;
                        }
                    }

                    if (isDetailBuy == true)
                    {
                        Console.WriteLine("\n  Поздравляю с покупкой!");
                        Console.ReadLine();
                    }
                    else if (isEnoughMoney == false)
                    {
                        Console.WriteLine("  Недостаточно средств");
                        Console.ReadLine();
                    }
                    else if (isDetailBuy == false & isEnoughMoney == true)
                    {
                        Console.WriteLine("  Вы ввели неверные данные");
                        Console.ReadLine();
                    }
                }
            }
        }

        private bool IsClientSolvent(Client client, int price)
        {
            bool _isSolvent = false;

            if (price <= client.GetAmountInWallet())
            {
                _isSolvent = true;
            }

            return _isSolvent;
        }

        private bool TryReplacementDetail(Client client, Cell newDetail, bool isReplacementDetailDishonest)
        {
            bool isDetailRepaired = false;
            bool isDetailSold = false;

            if (isReplacementDetailDishonest == false)
            {
                _warehouse.SaleDetail(newDetail);
                isDetailSold = true;
            }
            else
            {
                if (_warehouse.TryGetRandomDetail(out Cell randomDetail) == true)
                {
                    _warehouse.SaleDetail(randomDetail);
                    isDetailSold = true;
                }
            }

            if (isDetailSold == true)
            {
                client.Car.ReplacementBrokenDetail();
                isDetailRepaired = true;
            }
            return isDetailRepaired;
        }

        private void BonusPayment(int price, Client client)
        {
            int halfPart = 2;
            int minBonus = price / halfPart;
            int maxBonus = price;
            int sumBonus = _random.Next(minBonus, maxBonus) + maxBonus;
            bool _isStoreliquidation;

            Console.WriteLine(" Теперь сервис должен выплатить компенсацию клиенту!\n");
            Console.WriteLine($" Сумма компенсации составит:{sumBonus}\n");
            Console.WriteLine($"  \n\nБаланс средств автосервиса: {_cashRegister.AmoutMoney} {_currency}");
            Console.ReadLine();

            if (_cashRegister.DebitsFunds(sumBonus) == false)
            {
                Console.WriteLine($"{_repairMaster.Name} : К сожалению автосервис не может оплатить штраф, так как не хватает средств");
                Console.WriteLine($"{_repairMaster.Name} : Автосервис будет закрыт, средства будут переведены вам в ближайшее время. До новых встреч");
                ShowExiteText(_isStoreliquidation = true);
                Console.ReadLine();
                StoreLiquidation();
            }
            else
            {
                client.ReplenishmentWallet(sumBonus);
            }
        }

        private bool ChanceFindViolation()
        {
            bool isClientFindViolation = false;
            int maxChance = 100;
            int halfMaxChance = maxChance / 2;
            int number = _random.Next(maxChance);

            if (number < halfMaxChance)
            {
                isClientFindViolation = true;
            }

            return isClientFindViolation;
        }

        private void ShowExiteText(bool _isStoreliquidation)
        {
            if (_isStoreliquidation == true)
            {
                Console.WriteLine($"Не все клиенты успели пройти ремонт((, для них это печальные новости, ведь в очереди осталось {_clientsQueue.Count} машин");
                Console.WriteLine("Наш Автосервис закрывается");
            }
            else
            {
                Console.WriteLine("Все клиенты прошли осмотр и ремонт!");
                Console.WriteLine("Наш Автосервис закрывается");
            }
        }

        private void ShowDetailGroup(Dictionary<string, int> DetailsGroup)
        {
            foreach (var detail in DetailsGroup)
            {
                Console.WriteLine($"{detail.Key} - {detail.Value} {_currency}");
            }
        }

        public void StoreLiquidation()
        {
            _clientsQueue.Clear();
        }
    }

    class CashRegister
    {
        private readonly int _minAmoutMoney;
        private readonly int _maxAmoutMoney;
        private readonly Random _random = new();

        public int AmoutMoney { get; private set; }


        public CashRegister()
        {
            AmoutMoney = _random.Next(_minAmoutMoney, _maxAmoutMoney);
            _minAmoutMoney = 0;
            _maxAmoutMoney = 0;
        }

        public bool DebitsFunds(int purchasePrice)
        {
            bool isPurchaseCompleted = false;

            if (purchasePrice <= AmoutMoney)
            {
                AmoutMoney -= purchasePrice;
                isPurchaseCompleted = true;
            }

            return isPurchaseCompleted;
        }

        public void ReplenishesFunds(int price)
        {
            if (price > 0)
            {
                AmoutMoney += price;
            }
            else if (price + AmoutMoney >= _maxAmoutMoney)
            {
                AmoutMoney = _maxAmoutMoney;
            }
        }
    }

    class Warehouse
    {
        private readonly List<Cell> _details = new();
        private readonly Dictionary<string, int> _detailsGroup = new();
        private readonly Random _random = new();

        public Warehouse()
        {
            CreateDetails();
        }

        public void ShowStockDetails()
        {
            Console.WriteLine(" На скдаже в наличии есть:");

            foreach (Cell detail in _details)
            {
                Console.WriteLine($"{detail.Name} - {detail.Quantity}шт ,цена за штуку {detail.Price}");
            }
        }

        public List<Cell> GetDetailsInStock()
        {
            List<Cell> tempDetails = new();

            for (int i = 0; i < _details.Count; i++)
            {
                tempDetails.Add(new Cell(_details[i].Name, _details[i].Price, _details[i].Quantity));
            }

            return tempDetails;
        }

        public Dictionary<string, int> GetDetailsGroup()
        {
            Dictionary<string, int> tempDetailsGroup = new();

            foreach (var item in _detailsGroup)
            {
                tempDetailsGroup.Add(item.Key, item.Value);
            }

            return tempDetailsGroup;
        }

        public bool TryGetDetail(string name, out Cell newDetail)
        {
            bool isAvaidle = false;

            newDetail = null;

            foreach (Cell detail in _details)
            {
                if (detail.Name == name & detail.Quantity > 0)
                {
                    newDetail = detail;
                    isAvaidle = true;
                    break;
                }
            }

            return isAvaidle;
        }

        public void AddDetail(DetailForWarehouse purchasedDetail)
        {
            foreach (Cell detail in _details)
            {
                if (detail.Name == purchasedDetail.Name)
                {
                    int countDetails = detail.Quantity;
                    countDetails++;
                    detail.SetQuantity(countDetails);
                    break;
                }
            }
        }

        public void CreateDetail(DetailForWarehouse newDetail)
        {
            int number = 1;

            _details.Add(new Cell(newDetail.Name, newDetail.Price, number));
        }

        public int GetPriceDetail(string detailName)
        {
            int price = 0;

            foreach (var detail in _detailsGroup)
            {
                if (detail.Key == detailName)
                {
                    price = detail.Value;
                    break;
                }
            }
            return price;
        }

        public void SaleDetail(Cell newDetail)
        {
            if (_details.Contains(newDetail))
            {
                int countDetails = _details[_details.IndexOf(newDetail)].Quantity;
                countDetails--;
                _details[_details.IndexOf(newDetail)].SetQuantity(countDetails);

                if (countDetails == 0)
                {
                    _details.Remove(newDetail);
                }
            }
        }

        public bool TryGetRandomDetail(out Cell randomDetail)
        {
            bool isAvaidle = false; randomDetail = null;
            int number;
            int count;
            int countDetail = 0;

            foreach (Cell cell in _details)
            {
                countDetail += cell.Quantity;
            }

            if (countDetail > 0)
            {
                while (isAvaidle == false)
                {
                    count = 0;
                    number = _random.Next(0, _details.Count);

                    foreach (Cell detail in _details)
                    {
                        if (count != number)
                        {
                            count++;
                        }
                        else
                        {
                            if (TryGetDetail(detail.Name, out Cell newDetail))
                            {
                                randomDetail = newDetail;
                                isAvaidle = true;
                            }
                            else
                            {
                                isAvaidle = false;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                isAvaidle = false;
            }

            return isAvaidle;
        }

        private void CreateDetails()
        {
            int maxCountDetails = 1;
            int minCountDetails = 1;
            int number = 0;

            Dictionary<string, int> DetailsAndPriceGroup = new()
            {
                { "Стойка амортизатора", 4000 },
                { "Тормозные колодки", 2000 },
                { "Воздушный фильтр", 400 },
                { "Масляный фильтр", 480 },
                { "Ремень ГРМ", 5000 },
                { "Свечи зажигания", 6000 },
                { "Аккумулятор", 8000 },
                { "Набор плавких предохранителей", 100 }
            };

            foreach (var item in DetailsAndPriceGroup)
            {
                _detailsGroup.Add(item.Key, item.Value);
            }

            foreach (var item in _detailsGroup)
            {
                int count = _random.Next(minCountDetails, maxCountDetails);
                _details.Add(new Cell(item.Key, item.Value, count));
                number++;
            }
        }
    }

    class Detail
    {
        public string Name { get; private set; }

        public Detail(string name)
        {
            Name = name;
        }
    }

    class DetailForWarehouse : Detail
    {
        public int Price { get; private set; }
        public DetailForWarehouse(string name, int price) : base(name)
        {
            Price = price;
        }
    }

    class Client : Human
    {
        private readonly Wallet _wallet = new();
        private readonly Car _car = new();

        public Car Car { get { return _car; } set {; } }

        public Client(string name) : base(name)
        {
        }

        public void Buy(int price)
        {
            _wallet.Purchase(price);
        }

        public int GetAmountInWallet()
        {
            return _wallet.AmoutMoney;
        }

        public void ReplenishmentWallet(int price)
        {
            _wallet.ReplenishmentAmount(price);
        }



    }

    class Car
    {
        public Detail BrokenDetail { get; private set; }

        private Dictionary<int, Detail> Details = new();

        public Car()
        {
            SetDetails();
            SetBrokenDetail();
        }

        public void ReplacementBrokenDetail()
        {
            BrokenDetail = new Detail("");
        }

        private void SetBrokenDetail()
        {
            Random random = new();
            int mumber = random.Next(0, Details.Count);
            BrokenDetail = Details[mumber];
        }

        private void SetDetails()
        {
            List<string> DetailsName = new()
            {
                { "Стойка амортизатора" },
                { "Тормозные колодки" },
                { "Воздушный фильтр" },
                { "Масляный фильтр" },
                { "Ремень ГРМ" },
                { "Свечи зажигания" },
                { "Аккумулятор" },
                { "Набор плавких предохранителей" }
            };

            for (int i = 0; i < DetailsName.Count; i++)
            {
                Details.Add(i, (new Detail(DetailsName[i])));
            }
        }
    }

    class Wallet
    {
        private readonly Random _random = new();
        private readonly int _minAmoutMoney;
        private readonly int _maxAmoutMoney;
        private int _amoutMoney;

        public int AmoutMoney { get { return _amoutMoney; } }

        public Wallet()
        {
            _minAmoutMoney = 10000;
            _maxAmoutMoney = 15000;
            _amoutMoney = _random.Next(_minAmoutMoney, _maxAmoutMoney);
        }

        public void Purchase(int purchasePrice)
        {
            _amoutMoney -= purchasePrice;
        }

        public void ReplenishmentAmount(int price)
        {
            if (price > 0)
            {
                _amoutMoney += price;
            }
            else if (price + _amoutMoney >= _maxAmoutMoney)
            {
                _amoutMoney = _maxAmoutMoney;
            }
        }
    }

    class RepairMaster : Human
    {
        public RepairMaster(string name) : base(name)
        {
        }
    }

    class Human
    {
        public string Name { get; private set; }

        public Human(string name)
        {
            Name = name;
        }
    }

    class Cell
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Quantity { get; private set; }
        public Cell(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public void SetQuantity(int quantity)
        {
            if (quantity >= 0)
            {
                Quantity = quantity;
            }
        }
    }
}
