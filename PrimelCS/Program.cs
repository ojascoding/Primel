namespace PrimelCS
{
    public class PrimelCS
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Console.WriteLine("How many digits would you like to play with? Min 2, Max 5");
            int digits = new int();

            if (int.TryParse(Console.ReadLine(), out var output))
            {
                digits = output;
            }

            while (digits < 2 || digits > 5)
            {
                Console.WriteLine("Please enter a digits amount between 2 and 5");
                digits = Convert.ToInt32(Console.ReadLine());
            }

            List<int> primeNumbers = new List<int>();

            FindAllPrimeNumbers(primeNumbers);

            Random random = new Random();

            Char[] randomNumCharacters = GenerateRandomPrimeNum();

// Console.WriteLine(randomNum);

            while (true)
            {
                int correctCount = 0;
                Console.WriteLine("\nEnter a " + digits + "-Digit Number");
                Char[] guess = new char[digits];

                List<Char> markedChars = new List<Char>();

                if (int.TryParse(Console.ReadLine(), out var result))
                {
                    guess = result.ToString().ToCharArray();
                }

                while (guess.Length != digits)
                {
                    Console.WriteLine("Please enter the correct amount of digits");
                    guess = (Console.ReadLine()).ToCharArray();
                }

                for (int i = 0; i < digits; i++)
                {
                    if (guess[i] == randomNumCharacters[i])
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(guess[i]);
                        Console.ResetColor();
                        markedChars.Add(guess[i]);
                        correctCount++;
                    }

                    else if (randomNumCharacters.Contains(guess[i]) && !markedChars.Contains(guess[i]))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(guess[i]);
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.Write(guess[i]);
                    }
                }

                if (correctCount == digits)
                {
                    Console.WriteLine("\nYou win!\nWould you like to play again? Respond with yes or no");
                    string answer = Console.ReadLine().ToLower();

                    if (answer == "yes")
                    {
                        Run();
                    }

                    break;
                }
            }


            Char[] GenerateRandomPrimeNum()
            {
                int randomNum;

                while (true) //generates a random number of the digits specified
                {
                    randomNum = primeNumbers[random.Next(primeNumbers.Count)];
                    if (randomNum.ToString().Length == digits)
                        break;
                }

                Char[] randChar = randomNum.ToString().ToCharArray();
                return randChar;
            }

            void FindAllPrimeNumbers(List<int> list)
            {
                int flag = 0;

                for (int i = 3; i < 100000; i++)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            flag = 1;
                            break;
                        }
                    }

                    if (flag == 0)
                    {
                        list.Add(i);
                    }

                    flag = 0;
                }
            }
        }
    }
}