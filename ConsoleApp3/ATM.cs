namespace ConsoleApp3
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

        public void cashIn(decimal amount)
        {
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
}
