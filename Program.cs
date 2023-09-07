namespace NumbersGame
{//Zoran Matovic NET23
    internal class Program
    {
        internal static int GetRandomNr(int maxValue)  //METHOD - We get a random number
        {
            Random random = new Random();
            return random.Next(1, maxValue + 1);
        }


        internal static void CheckGuess(int guess, int correctNr, int rounds)    //METHOD - We check userGuess against winnerNr
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
                Console.WriteLine("\nWooho! Du gissade rätt"); // correct guess
                Console.WriteLine($"Du behövde {rounds} gissningar.");
            }

            int difference = Math.Abs(correctNr - guess);

            if (difference == 1)
            {
                Console.WriteLine("Nu bränns det!!");
            }
            else if (difference == 2)
            {
                Console.WriteLine("Det börjar närma sig!");
            }

        }



        static void Main(string[] args)
        {
            bool playAgain;
            int rounds = 0;
            int userGuess;
            int winner;
            int maxNr = 0;
            int maxRounds = 0;
            int menuChoise;


            Console.WriteLine("Välkommen till gissa numret.");
            Console.WriteLine("Jag tänker på ett nummer, gissa vilket!");

            do
            {

                Console.WriteLine("\n********MENY********");
                Console.WriteLine("********************");
                Console.WriteLine("* 1 * Lätt  (1-10) *");
                Console.WriteLine("* 2 * Medel (1-20) *");
                Console.WriteLine("* 3 * Svår  (1-50) *");
                Console.WriteLine("* 4 * Custom       *");
                Console.WriteLine("********************");
                Console.WriteLine();
                Console.Write("Välj ");


                while (!int.TryParse(Console.ReadLine(), out menuChoise) || menuChoise < 1 || menuChoise > 4)
                {
                    Console.WriteLine("Välj endast 1-4!");
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
                        Console.WriteLine("Hur många gissningar?");
                        while (!int.TryParse(Console.ReadLine(), out maxRounds) || maxRounds < 1)
                        {
                            Console.WriteLine("Endast heltal, försök igen!");
                        }


                        Console.WriteLine("Jag kommer tänka på ett tal mellan 1-? Du väljer maxgräns själv. Ange maxtal");
                        while (!int.TryParse(Console.ReadLine(), out maxNr) || maxNr < 1)
                        {
                            Console.WriteLine("Endast heltal, försök igen!");
                        }
                        break;

                }


                winner = GetRandomNr(maxNr);  //call method to get the winning nr

                do
                {
                    Console.Write("Ange ett nr ");

                    while (!int.TryParse(Console.ReadLine(), out userGuess))
                    {
                        Console.WriteLine("Skriv endast in heltal, försök igen");
                    }

                    rounds++;

                    CheckGuess(userGuess, winner, rounds);


                    if (rounds >= maxRounds && userGuess != winner)
                    {
                        Console.WriteLine("\nDina gissningar är tyvärr slut");
                        Console.WriteLine($"Det rätta numret var {winner} ");
                    }

                } while (rounds < maxRounds && userGuess != winner);

                Console.WriteLine("\nVill du spela igen?"); //ask user to play again j/n 
                Console.Write("j/n  ");
                string answer = Console.ReadLine();


                if (answer == "j" || answer == "J")   //if J/j game starts again
                {
                    playAgain = true;
                    rounds = 0;
                }
                else if (answer == "n" || answer == "N")   //if N/n game will end
                {
                    Console.WriteLine("spelet avslutas...");
                    playAgain = false;
                }
                else
                {
                    playAgain = false;     // if user types something else than j/n game will end

                }


            } while (playAgain);



            Console.ReadKey();

        }
    }
}