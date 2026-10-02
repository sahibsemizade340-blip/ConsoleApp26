namespace ConsoleApp26
{
    internal class Program
    {
        static object lockObject = new object();

        static double balance = 1000;

        static void Withdraw(object user)
        {
            lock (lockObject)
            {
                if (balance >= 600)
                {
                    Thread.Sleep(100);

                    balance -= 600;

                    Console.WriteLine($"{user} 600 AZN pul cixartdi");
                    Console.WriteLine($"Qaliq balans: {balance} AZN");
                }
                else
                {
                    Console.WriteLine($"{user} ucun balans kifayet deyil");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Kart adi: BirKart");
            Console.WriteLine("Balans: " + balance + " AZN");

            Console.WriteLine();

            Thread t1 = new Thread(Withdraw);
            Thread t2 = new Thread(Withdraw);

            t1.Start("ATM");
            t2.Start("Magaza");

            t1.Join();
            t2.Join();

            Console.WriteLine();
            Console.WriteLine("Son balans: " + balance + " AZN");

            Console.ReadLine();
        }
    }
}
