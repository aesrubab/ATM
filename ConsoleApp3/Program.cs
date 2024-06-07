using ConsoleApp3;

namespace AtmSystem
{

    class Program
    {
        static void Main(string[] args)
        {
            Atm atm = new Atm(10000, "1907");

            Console.WriteLine("PIN kodunuzu daxil edin:");
            string pin = Console.ReadLine();
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
