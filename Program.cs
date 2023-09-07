namespace NumbersGame
{//Zoran Matovic NET23
    internal class Program
    {
        //METHOD - We get a random number
        internal static int GetRandomNr(int maxValue)
        {
            int max = maxValue + 1;
            Random random = new Random();
            return random.Next(1, max);
        }
        //METHOD - We check userGuess against winnerNr
        internal static void CheckGuess(int guess, int correctNr)
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
            }

            if (guess - correctNr < 2 && guess - correctNr > 0)
            {
                Console.WriteLine("Nu va du riktigt nära."); //if user is high but very close
            }
            else if (correctNr - guess < 2 && correctNr - guess > 0)
            {
                Console.WriteLine("Nu bränns det!"); //if user is low but very close
            }

        }



        static void Main(string[] args)
        {
            bool loop;
            bool loop2;
            int rounds = 0;
            int userGuess = 0;
            int winner;
            int maxNr = 0;
            int maxRounds = 0;
            int meny = 0;


            Console.WriteLine("Välkommen till gissa numret.");
            Console.WriteLine("Jag tänker på ett nummer. Du ska gissa vilket?");

            do
            {
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
                    try
                    {
                        meny = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        loop2 = false;

                    }


                    switch (meny)
                    {
                        case 1: //Lätt - user get 5 guesses, 1-10
                            maxRounds = 5;
                            maxNr = 10;
                            loop2 = true;
                            break;

                        case 2: //Medel - user get 6 guesses, 1-20
                            maxRounds = 6;
                            maxNr = 20;
                            loop2 = true;
                            break;


                        case 3:// Svår - user get 5 guesses, 1-50
                            maxRounds = 5;
                            maxNr = 50;
                            loop2 = true;
                            break;


                        case 4: // Custom - user choose number of guesses and maxnr
                            bool check = false;
                            int temp = 0;
                            int temp2 = 0;

                            while (!check)
                            {
                                Console.WriteLine("Välj max antal gissninar");
                                check = int.TryParse(Console.ReadLine(), out temp);

                                if (!check)
                                {
                                    Console.WriteLine("Endast heltal, försök igen!");
                                }

                            }
                            check = false;
                            while (!check)
                            {
                                Console.WriteLine("Jag kommer tänka på ett tal mellan 1-? Du väljer maxgräns själv. Ange maxtal");
                                check = int.TryParse(Console.ReadLine(), out temp2);

                                if (!check)
                                {
                                    Console.WriteLine("Endast heltal, försök igen!");
                                }

                            }

                            maxRounds = temp;
                            maxNr = temp2;
                            loop2 = true;
                            break;

                        default:
                            Console.WriteLine("Välj ett nr 1-4");
                            meny = 0;
                            loop2 = false;
                            break;

                    }

                } while (!loop2);

                winner = GetRandomNr(maxNr);//call method to get the winning nr

                while (rounds < maxRounds)
                {
                    int temp = 0;
                    bool check = false;
                    while (!check)
                    {
                        Console.Write("Ange ett nr ");
                        check = int.TryParse(Console.ReadLine(), out temp);

                        if (!check)
                        {
                            Console.WriteLine("Skriv endast in heltal, försök igen");
                        }

                    }
                    check = false;
                    userGuess = temp;
                    rounds++;

                    CheckGuess(userGuess, winner);

                    if (userGuess == winner)
                    {
                        Console.WriteLine($"Du behövde {rounds} gissningar.");
                        break;
                    }

                }


                if (rounds >= maxRounds && userGuess != winner)
                {
                    Console.WriteLine("\nDina gissningar är tyvärr slut");
                    Console.WriteLine($"Det rätta numret var {winner} ");
                }

                Console.WriteLine("\nVill du spela igen?"); //ask user to play again j/n 
                Console.WriteLine("j/n");
                string answer = Console.ReadLine();

                if (answer == "j")// if j we loop back again
                {
                    loop = false;
                    rounds = 0;
                }
                else if (answer == "n") //if n game will end
                {
                    Console.WriteLine("spelet avslutas...");
                    loop = true;
                }
                else
                {
                    loop = true; // if user types something else than j/n game will end

                }

            } while (!loop);

            Console.ReadKey();

        }
    }
}