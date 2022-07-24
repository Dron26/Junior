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
        private Dictionary<DetailForWarehouse, int> _detailsInStockWarehouse = new();
        private bool _isSelectStart;
        private bool _isSelectExite;
        private bool _isSolvent;
        private bool _isStoreliquidation;

        private string userInput;
        public AutoRepairShop()
        {
            _repairMaster = new("Борис");
            _currency = " руб.";
            _isSelectStart = false; 
            _isSelectExite = false; 
            _isSolvent = false;
            _isStoreliquidation = false;
        }

        public void Work()
        {
            ShowMenuStart();

            if (ChoiceLaunchShop())
            {
                FillGroupDetailInStockWarehouse();
                CreateCustomersQueue();

                while (_isSelectExite == false & _clientsQueue.Count != 0)
                {
                    ActionSelection();

                }
                ShowExiteText();
            }
        }

        private void ShowMenuStart()
        {
            Console.WriteLine("");
            Console.WriteLine("Добро пожаловать в автомастерскую");
            Console.WriteLine("1 - Приступить к работе");
            Console.WriteLine("Другое - Выход");
        }

        private bool ChoiceLaunchShop()
        {
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    _isSelectStart = true;
                    break;
            }

            Console.Clear();
            return _isSelectStart;
        }

        private void CreateCustomersQueue()
        {
            int countCustomer = 20;
            string randomName;

            List<string> name = new()
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
                randomName = name[_random.Next(0, name.Count)];
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

                if ((_warehouse.TryGetDetail(brokenDetail.Name, out DetailForWarehouse newDetail) == false))
                {
                    isReplacementDetailDishonest = true;

                }

                isDetailRepaired = TryReplacementDetail(client, newDetail, isReplacementDetailDishonest);

                if (isDetailRepaired == true)
                {
                    _cashRegister.ReplenishmentAmount(price);
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

        private void ActionSelection()
        {
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
                    ChoiceMenuWarehouse();
                    break;
                case "3":
                    _isSelectExite = true;
                    break;
            }
        }

        private void ChoiceMenuWarehouse()
        {
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

            FillGroupDetailInStockWarehouse();

            foreach (var detail in _detailsInStockWarehouse)
            {
                Console.WriteLine($"{detail.Key.Name}  -   {detail.Value}шт, цена за штуку {detail.Key.Price} {_currency}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void PurchaseDetails()
        {
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

                FillGroupDetailInStockWarehouse();
                ShowDetailGroup(DetailsGroup);

                userInput = Console.ReadLine();

                if (userInput.ToLower() == "e")
                {
                    isInputExite = true;
                }
                else
                {
                    soughtDetail = new DetailForWarehouse(userInput, _warehouse.GetPriceDetail(userInput));

                    foreach (var detail in _detailsInStockWarehouse)
                    {
                        if (detail.Key.Name == soughtDetail.Name)
                        {
                            if (_cashRegister.DebitingFunds(soughtDetail.Price) == true)
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
                        if (_cashRegister.DebitingFunds(soughtDetail.Price) == true)
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

        private void FillGroupDetailInStockWarehouse()
        {
            _detailsInStockWarehouse = _warehouse.GetDetailsInStock();
        }

        private bool IsClientSolvent(Client client, int price)
        {
            if (price <= client.GetAmountInWallet())
            {
                _isSolvent = true;
            }

            return _isSolvent;
        }

        private bool TryReplacementDetail(Client client, DetailForWarehouse newDetail, bool isReplacementDetailDishonest)
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
                if (_warehouse.TryGetRandomDetail(out DetailForWarehouse randomDetail) == true)
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

            Console.WriteLine(" Теперь сервис должен выплатить компенсацию клиенту!\n");
            Console.WriteLine($" Сумма компенсации составит:{sumBonus}\n");
            Console.WriteLine($"  \n\nБаланс средств автосервиса: {_cashRegister.AmoutMoney} {_currency}");
            Console.ReadLine();

            if (_cashRegister.DebitingFunds(sumBonus) == false)
            {
                Console.WriteLine($"{_repairMaster.Name} : К сожалению автосервис не может оплатить штраф, так как не хватает средств");
                Console.WriteLine($"{_repairMaster.Name} : Автосервис будет закрыт, средства будут переведены вам в ближайшее время. До новых встреч");
                _isStoreliquidation = true;
                ShowExiteText();
                Console.ReadLine();
                _clientsQueue.Clear();
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

        private void ShowExiteText()
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
    }

    class CashRegister
    {
        private readonly int _minAmoutMoney;
        private readonly int _maxAmoutMoney;
        private readonly Random _random = new();
        private int _amoutMoney;

        public int AmoutMoney { get { return _amoutMoney; } }


        public CashRegister()
        {
            _amoutMoney = _random.Next(_minAmoutMoney, _maxAmoutMoney);
            _minAmoutMoney = 10000;
            _maxAmoutMoney = 12000;
        }

        public bool DebitingFunds(int purchasePrice)
        {
            bool isPurchaseCompleted = false;

            if (purchasePrice <= _amoutMoney)
            {
                _amoutMoney -= purchasePrice;
                isPurchaseCompleted = true;
            }

            return isPurchaseCompleted;
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

    class Warehouse
    {
        private readonly Dictionary<DetailForWarehouse, int> _details = new();
        private readonly Dictionary<string, int> _detailsGroup = new();
        private readonly Random _random = new();

        public Warehouse()
        {
            CreateDetails();
        }

        public void ShowStockDetails()
        {
            Console.WriteLine(" На скдаже в наличии есть:");

            foreach (var detail in _details)
            {
                Console.WriteLine($"{detail.Key.Name} - {detail.Value}шт ,цена за штуку {detail.Key.Price}");
            }
        }

        public Dictionary<DetailForWarehouse, int> GetDetailsInStock()
        {
            Dictionary<DetailForWarehouse, int> tempDetails = new();

            foreach (var detail in _details)
            {
                tempDetails.Add(detail.Key, detail.Value);
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

        public bool TryGetDetail(string name, out DetailForWarehouse newDetail)
        {
            bool isAvaidle = false;

            newDetail = null;

            foreach (var detail in _details)
            {
                if (detail.Key.Name == name & detail.Value > 0)
                {
                    newDetail = detail.Key;
                    isAvaidle = true;
                    break;
                }
            }

            return isAvaidle;
        }

        public void AddDetail(DetailForWarehouse purchasedDetail)
        {
            foreach (var detail in _details)
            {
                if (detail.Key.Name == purchasedDetail.Name)
                {
                    int countDetails = detail.Value;
                    countDetails++;
                    _details[detail.Key] = countDetails;
                    break;
                }
            }
        }

        public void CreateDetail(DetailForWarehouse newDetail)
        {
            int number = 1;

            _details.Add(new DetailForWarehouse(newDetail.Name, newDetail.Price), number);
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

        public void SaleDetail(DetailForWarehouse newDetail)
        {
            if (_details.ContainsKey(newDetail))
            {
                _details.TryGetValue(newDetail, out int countDetails);
                countDetails--;
                _details[newDetail] = countDetails;
                if (countDetails == 0)
                {
                    _details.Remove(newDetail);
                }
            }
        }

        public bool TryGetRandomDetail(out DetailForWarehouse randomDetail)
        {
            bool isAvaidle = false; randomDetail = null;
            int number;
            int count;
            int countDetail = 0;

            foreach (var detail in _details)
            {
                countDetail += detail.Value;
            }

            if (countDetail > 0)
            {
                while (isAvaidle == false)
                {
                    count = 0;
                    number = _random.Next(0, _details.Count);

                    foreach (var detail in _details)
                    {
                        if (count != number)
                        {
                            count++;
                        }
                        else
                        {
                            if (TryGetDetail(detail.Key.Name, out DetailForWarehouse newDetail))
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
                int number = _random.Next(minCountDetails, maxCountDetails);

                _details.Add(new DetailForWarehouse(item.Key, item.Value), number);
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
        public Car Car = new();

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

        public Dictionary<int, Detail> Details { get; private set; }

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
            _amoutMoney = _random.Next(_minAmoutMoney, _maxAmoutMoney);
            _minAmoutMoney = 5000;
            _maxAmoutMoney = 20000;
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
}
