//I made this in about an hour after you issued the challenge of making a Blackjack game
using System;
using System.Threading;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bExit = false;
            bool bSmallExit = false;
			bool bValid = false;
            var rand = new Random(Guid.NewGuid().GetHashCode());
            int iPlayerValue = 0;
            int iPlayerMoney = 2000;
            int iDealerValue = 0;
			int iBet = 0;
            string sInput;

            Console.WriteLine("Welcome to Blackjack! Press Enter to begin\n");
            Console.ReadLine();

            while (!bExit)
            {
                Console.Clear();

                iDealerValue = rand.Next(1, 11);
                Console.WriteLine("Dealer's current revealed value is " + iDealerValue);

                iPlayerValue = rand.Next(1, 11);
                Console.WriteLine("Your current value is " + iPlayerValue);

                while (!bValid)
				{
					Console.WriteLine("\nYour current cash is R " + iPlayerMoney);
					Console.WriteLine("How much do you wish to bet? (Payout is x2)");

					sInput = Console.ReadLine();
					Console.Clear();
					
					try
					{
						iBet = Int32.Parse(sInput);
						
						if ((iBet > iPlayerMoney) || (iBet < 1))
						{
							Console.WriteLine("Please enter a valid amount of money");
						}
						else
						{
							iPlayerMoney = iPlayerMoney - iBet;
							bValid = true;
						}
					}
					catch
					{
						Console.WriteLine("Please enter a valid bet");
					}
				}
				bValid = false;
				
				Console.Clear();
				Console.WriteLine("You have R" + iPlayerMoney + " and are betting R" + iBet);
                Console.WriteLine("Your current value is " + iPlayerValue);

                while (!bSmallExit)
                {
                    Console.WriteLine("\nDo you wish to hit or stand?");
                    sInput = Console.ReadLine();

                    if (sInput == "hit")
                    {
                        iPlayerValue = iPlayerValue + rand.Next(1, 11);
                        Console.WriteLine("You currently have " + iPlayerValue);
                    }
                    else if (sInput == "stand")
                        bSmallExit = true;
                    else
                        Console.WriteLine("Please enter a valid answer\n");

                    if (iPlayerValue > 21)
                    {
                        Console.WriteLine("You've busted!");
                        bSmallExit = true;
                    }
                    else if (iPlayerValue == 21)
                    {
                        Console.WriteLine("Blackjack!");
                        bSmallExit = true;
                    }
                }
                bSmallExit = false;

                if (iPlayerValue == 21)
                    Console.WriteLine("You win!");
                else if ((iPlayerValue > 21) || (iDealerValue > iPlayerValue))
                    Console.WriteLine("You lose!");
                else
                {
                    while ((iDealerValue < iPlayerValue))
                    {
                        iDealerValue = iDealerValue + rand.Next(1, 11);

                        Thread.Sleep(500);
                        Console.WriteLine("\nThe dealer currently has " + iDealerValue);

                    }

                    if ((iDealerValue > iPlayerValue) && (iDealerValue < 22))
                    {
                        Console.WriteLine("You lose R" + iBet + "!");
                    }
                    else
                    {
						iBet = iBet * 2;
						iPlayerMoney = iPlayerMoney + iBet;
                        Console.WriteLine("You win R" + iBet + "!");
                    }
                }

                if (iPlayerMoney <= 0)
                {
                    Console.WriteLine("Goodbye!");
                    bExit = true;
                }
				
				Console.ReadKey();

            }
            
            Console.ReadKey();
        }
    }
}
