using System;
using System.Numerics;
using System.Xml.Serialization;

namespace AtmSystem
{

    public class Atm
    {
        private decimal balance;
        private string pin;
        private int pinAttempts;

        public Atm(decimal initialBalance, string initialPIN)
        {
            balance = initialBalance;
            pin = initialPIN;
            pinAttempts = 0;
        }

        public void EnteredPin(string enteredPIN)
        {
            if (pinAttempts >= 3)
            {
                throw new Exception("Hesabbb bloklandi!!");
            }

            if (enteredPIN == pin)
            {
                pinAttempts = 0;
                Console.WriteLine("Hesaba daxil oldu");
            }
            else
            {
                pinAttempts++;
                throw new Exception("Yalnis pin");
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Balansınız:{balance} AZN");
        }

        public void cashOut(decimal amount)
        {
            if (amount > balance)
            {
                throw new Exception("Kifayet qeder balans yoxudr");
            }
            balance -= amount;
            Console.WriteLine($"Yeni balans: {balance} AZN");
        }

        public void cashIn(decimal amount) {
            balance -= amount;
            Console.WriteLine($"Yeni balans: {balance} AZN");
        }
        public void ChangePIN(string oldPIN, string newPIN)
        {
            if (oldPIN != pin)
            {
                throw new Exception("duzgun daxil edin");
            }
            pin = newPIN;
            Console.WriteLine("pin deyisdirildi");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atm atm = new Atm(10000, "1907");

            Console.WriteLine("PIN kodunuzu daxil edin:");
            string pin = Console.ReadLine();
            //adada
            try
            {
                atm.EnteredPin(pin);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                Console.WriteLine("\nSeçiminizi edin:");
                Console.WriteLine("1. Balance");
                Console.WriteLine("2. Cash out");
                Console.WriteLine("3. Cash out");
                Console.WriteLine("4. Change pin");
                Console.WriteLine("5. Exit");
                Console.Write("Seçim: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            atm.CheckBalance();
                            break;
                        case "2":
                            Console.Write("Meblegi daxil edin: ");
                            decimal amountOut = Convert.ToDecimal(Console.ReadLine());
                            atm.cashOut(amountOut);
                            break;
                        case "3":
                            Console.Write("Meblegi daxil edin: ");
                            decimal amountIn = Convert.ToDecimal(Console.ReadLine());
                            atm.cashIn(amountIn);
                            break;
                        case "4":
                            Console.Write("Kohne pini daxil edin: ");
                            string oldPIN = Console.ReadLine();
                            Console.Write("Yeni pini daxil edin: ");
                            string newPIN = Console.ReadLine();
                            atm.ChangePIN(oldPIN, newPIN);
                            break;
                        case "5":
                            Console.WriteLine("cixis");
                            return;
                        default:
                            Console.WriteLine("Yanlıs secim");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
