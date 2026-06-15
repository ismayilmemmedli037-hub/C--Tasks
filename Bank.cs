using Bank;
using System;
class Program
{
    static void AddTransaction(User user, string operation)
    {
        user.Transactions[user.TransactionCount] = new OperationTransaction
        {
            Operation = operation,
            Time = DateTime.Now
        };

        user.TransactionCount++;
    }
    static void Main()
    {
        User[] users = new User[5];
        // /////////////////////////////////////////////////////////////////////////////////
        users[0] = new User { Name = "Ismayil", Surname = "Memmeldi", CreditCard = new Card { PAN = "7777777777777777", PIN = "8888", CVC = "888", ExpireDate = "12/10", Balance = 15000 } };
        // /////////////////////////////////////////////////////////////////////////////////
        users[1] = new User { Name = "Fatima", Surname = "Abdullasoy", CreditCard = new Card { PAN = "8888888888888888", PIN = "7777", CVC = "777", ExpireDate = "01/12", Balance = 15000 } };
        // /////////////////////////////////////////////////////////////////////////////////
        users[2] = new User { Name = "Amil", Surname = "Eyvazli", CreditCard = new Card { PAN = "6666666666666666", PIN = "6666", CVC = "666", ExpireDate = "09/26", Balance = 12500 } };
        // /////////////////////////////////////////////////////////////////////////////////
        users[3] = new User { Name = "Cavid", Surname = "Ibadzade", CreditCard = new Card { PAN = "5555555555555555", PIN = "5555", CVC = "555", ExpireDate = "12/26", Balance = 8000 } };
        // /////////////////////////////////////////////////////////////////////////////////
        users[4] = new User { Name = "Yusuf", Surname = "Bagirov", CreditCard = new Card { PAN = "4444444444444444", PIN = "4444", CVC = "444", ExpireDate = "05/26", Balance = 300 } };
        // /////////////////////////////////////////////////////////////////////////////////

        while (true)
        {
            Console.Write("PIN daxil et: ");
            string pin = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].CreditCard.PIN == pin)
                {
                    Console.WriteLine($"{users[i].Name} {users[i].Surname} xos gelmisiniz zehmet olmasa asagidakilardan birini secerdiniz");
                    Console.WriteLine();
                    found = true;
                    while (true)
                    {
                        Console.WriteLine("1 - Balans");
                        Console.WriteLine("2 - Nagd pul");
                        Console.WriteLine("3 - Edilen emeliyyat siyahisi");
                        Console.WriteLine("4 - Kartdan karta kocurme");
                        Console.WriteLine("5 - Exit");
                        Console.Write("Secimini daxil et: ");
                        string secim1 = Console.ReadLine();
                        Console.WriteLine();

                        if (secim1 == "1")
                        {
                            Console.WriteLine($"Balans: {users[i].CreditCard.Balance}");
                            AddTransaction(users[i], "Balans yoxlandi");
                            Console.WriteLine();
                        }
                        else if (secim1 == "2")
                        {
                            Console.WriteLine("1 - 10 AZN");
                            Console.WriteLine("2 - 20 AZN");
                            Console.WriteLine("3 - 50 AZN");
                            Console.WriteLine("4 - 100 AZN");
                            Console.WriteLine("5 - Istediyin mebleg");
                            Console.Write("Secimini daxil et: ");
                            string secim2 = Console.ReadLine();
                            Console.WriteLine();
                            try
                            {
                                if (secim2 == "1")
                                {
                                    if (users[i].CreditCard.Balance < 10)
                                    {
                                        throw new Exception("Balans azdi");
                                    }
                                    users[i].CreditCard.Balance -= 10;
                                    AddTransaction(users[i], "10 AZN nagd cekildi");
                                    Console.WriteLine($"Balans: {users[i].CreditCard.Balance}");
                                }
                                else if (secim2 == "2")
                                {
                                    if (users[i].CreditCard.Balance < 20)
                                    {
                                        throw new Exception("Balans azdi");
                                    }
                                    users[i].CreditCard.Balance -= 20;
                                    AddTransaction(users[i], "20 AZN nagd cekildi");
                                    Console.WriteLine($"Balans: {users[i].CreditCard.Balance}");
                                }
                                else if (secim2 == "3")
                                {
                                    if (users[i].CreditCard.Balance < 50)
                                    {
                                        throw new Exception("Balans azdi");
                                    }
                                    users[i].CreditCard.Balance -= 50;
                                    AddTransaction(users[i], "50 AZN nagd cekildi");
                                    Console.WriteLine($"Balans: {users[i].CreditCard.Balance}");
                                }
                                else if (secim2 == "4")
                                {
                                    if (users[i].CreditCard.Balance < 100)
                                    {
                                        throw new Exception("Balans azdi");
                                    }
                                    users[i].CreditCard.Balance -= 100;
                                    AddTransaction(users[i], "100 AZN nagd cekildi");
                                    Console.WriteLine($"Balans: {users[i].CreditCard.Balance}");
                                }
                                else if (secim2 == "5")
                                {
                                    Console.Write("Mebleg daxil et: ");
                                    decimal mebleg = Convert.ToDecimal(Console.ReadLine());
                                    if (users[i].CreditCard.Balance < mebleg)
                                    {
                                        throw new Exception("Balans azdi");
                                    }
                                    users[i].CreditCard.Balance -= mebleg;
                                    AddTransaction(users[i], $"{mebleg} AZN nagd cekildi");
                                    Console.WriteLine($"Balans: {users[i].CreditCard.Balance}");
                                }
                                else
                                {
                                    Console.WriteLine("Yalnis secim");
                                }
                                Console.WriteLine();
                            }
                            catch (Exception error)
                            {
                                Console.WriteLine(error.Message);
                                Console.WriteLine();
                                continue;
                            }
                        }
                        else if (secim1 == "3")
                        {
                            Console.WriteLine("Emeliyyatar");
                            if (users[i].TransactionCount == 0)
                            {
                                Console.WriteLine("Emeliyyat yoxdu");
                            }
                            else
                            {
                                for (int j = 0; j < users[i].TransactionCount; j++)
                                {
                                    Console.WriteLine($"{users[i].Transactions[j].Time} - {users[i].Transactions[j].Operation}");
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (secim1 == "4")
                        {
                            while (true)
                            {
                                Console.Write("Kocurulen kartin PIN-ni daxil et: ");
                                string Pin = Console.ReadLine();
                                User target = null;

                                for (int j = 0; j < users.Length; j++)
                                {
                                    if (users[j].CreditCard.PIN == Pin)
                                    {
                                        target = users[j];
                                        break;
                                    }
                                }

                                if (target == null)
                                {
                                    Console.WriteLine("PIN yoxdu");
                                    Console.WriteLine();
                                    continue;
                                }

                                Console.Write("Mebleg daxil et: ");
                                decimal amount = Convert.ToDecimal(Console.ReadLine());

                                if (users[i].CreditCard.Balance < amount)
                                {
                                    Console.WriteLine("Balans azdi");
                                    Console.WriteLine();
                                    continue;
                                }

                                users[i].CreditCard.Balance -= amount;
                                target.CreditCard.Balance += amount;
                                AddTransaction(users[i], $"{amount} AZN {target.Name}  kocuruldu");
                                AddTransaction(target, $"{amount} AZN {users[i].Name} geldi");
                                Console.WriteLine("Tamamlandi");
                                Console.WriteLine();
                                break;
                            }
                        }
                        else if (secim1 == "5")
                        {
                            Console.WriteLine("Cixildi");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Yalnis secim");
                            Console.WriteLine();
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("PIN yoxdur");
                Console.WriteLine();
            }
        }
    }
}
