namespace NumbersGame
{//Zoran Matovic NET23
    internal class Program
    {
        //METHOD - We get a random number                
        internal static int GetRandomNr(int maxValue)
        {
            Random random = new Random();
            return random.Next(1, maxValue + 1);
        }

        //METHOD - We check userinput against winning number
        internal static void CheckGuess(int guess, int correctNr, int rounds)
        {
            if (guess < correctNr)
            {
                Console.WriteLine("Du gissade för lågt!"); //if user guess low
            }
            else if (guess > correctNr)
            {
                Console.WriteLine("Du gissade för högt!"); // if user guess high
            }
            else
            {
                Console.WriteLine("Wooho! Du gissade rätt"); // correct guess
                Console.WriteLine($"Du behövde {rounds} gissningar.");
            }
        }
        //METHOD - We check if userinput is close, alerts user if the guess is close.
        internal static void CheckIfClose(int guess, int correctNr)
        {
            int difference = Math.Abs(correctNr - guess);

            if (difference == 1)
            {
                Console.WriteLine("Nu bränns det!!");  //1 nr away
            }
            else if (difference == 2)
            {
                Console.WriteLine("Det börjar närma sig!");  // 2 nr away
            }
        }



        static void Main(string[] args)
        {
            bool playAgain;          // declaring variables
            int rounds = 0;
            int userGuess;
            int winner;
            int maxNr = 0;
            int maxRounds = 0;
            int menuChoise;


            Console.WriteLine("Välkommen till gissa numret.\nJag tänker på ett nummer, gissa vilket!");

            do
            {

                Console.WriteLine("\n********MENY********");   //display menu to user
                Console.WriteLine("********************");
                Console.WriteLine("* 1 * Lätt  (1-10) *");
                Console.WriteLine("* 2 * Medel (1-20) *");
                Console.WriteLine("* 3 * Svår  (1-50) *");
                Console.WriteLine("* 4 * Välj själv   *");
                Console.WriteLine("********************");
                Console.WriteLine();
                Console.Write("Val: ");


                while (!int.TryParse(Console.ReadLine(), out menuChoise) || menuChoise < 1 || menuChoise > 4) //if user choose other than 1-4 
                {                                                                                            //or write other than numbers
                    Console.WriteLine("Välj endast 1-4!");
                    Console.Write("Val: ");
                }





                switch (menuChoise)
                {
                    case 1:               //Lätt - user get 5 guesses, random 1-10
                        maxRounds = 5;
                        maxNr = 10;
                        break;

                    case 2:               //Medel - user get 6 guesses, random 1-20
                        maxRounds = 6;
                        maxNr = 20;
                        break;


                    case 3:               // Svår - user get 5 guesses, random 1-50
                        maxRounds = 5;
                        maxNr = 50;
                        break;

                    case 4:                //Custom - user can choose maxRounds and maxNr                       
                        Console.Write("Hur många gissningar? ");
                        while (!int.TryParse(Console.ReadLine(), out maxRounds) || maxRounds < 1)
                        {
                            Console.WriteLine("Endast heltal, försök igen!");
                            Console.Write("Hur många gissningar? ");
                        }


                        Console.Write("\nJag kommer tänka på ett tal mellan 1-? \nDu väljer maxgräns själv. \nAnge maxtal ");
                        while (!int.TryParse(Console.ReadLine(), out maxNr) || maxNr < 1)
                        {
                            Console.WriteLine("Endast heltal, försök igen!");
                            Console.Write("Ange maxtal ");
                        }

                        break;

                }


                winner = GetRandomNr(maxNr);  //call method to get the winning nr

                do
                {
                    Console.Write("\nAnge ett nr ");        //prompt user to make a guess

                    while (!int.TryParse(Console.ReadLine(), out userGuess))    //TryParse to make sure program does not crash
                    {
                        Console.WriteLine("Skriv endast in heltal, försök igen.");
                        Console.Write("Ange ett nr ");
                    }

                    rounds++;                                //increment variable to keep count on how many guesses user have done
                    CheckGuess(userGuess, winner, rounds);  // call method to check userGuess against winner
                    CheckIfClose(userGuess, winner);        // call method to see if userinput is close


                    if (rounds >= maxRounds && userGuess != winner)
                    {
                        Console.WriteLine("\nDina gissningar är tyvärr slut");  //if user have no more guesses
                        Console.WriteLine($"Det rätta numret var {winner} ");  // we show winning number
                    }

                } while (rounds < maxRounds && userGuess != winner);  //we keep looping until user wins or have no more guesses

                Console.WriteLine("\nVill du spela igen?"); //ask user to play again j/n 
                Console.Write("j/n  ");
                string answer = Console.ReadLine().ToLower();  //make sure answer is lowercase


                if (answer == "j")   //if j game starts again
                {
                    playAgain = true;  //set to true so Do-While loops again
                    rounds = 0;   // we reset rounds to 0
                }
                else             // if n or if user types something else we end program
                {
                    Console.WriteLine("spelet avslutas...");
                    playAgain = false;

                }


            } while (playAgain);





            Console.ReadKey();

        }
    }
}