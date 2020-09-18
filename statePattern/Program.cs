using System;

namespace statePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Account account = new Account(() => { Console.WriteLine("Unfrozen"); });
            
            account.Deposit(2.2M);
            account.Freeze();
            account.Deposit(2.2M);
            account.Close();
        }
    }
}
