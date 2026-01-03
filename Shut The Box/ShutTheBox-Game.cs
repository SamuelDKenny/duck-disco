using System;

class Program
{
    private static Random random = new Random();
    static void Main()
    {
        List<int> boxNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        int dice1 = 0;
        int dice2 = 0;
        int diceRoll = dice1 + dice2;
        int selectedNumber = 0;
        bool playable = true;

        //Setup Gamestate

        Console.Clear();
        PrintBox(boxNumbers);
        Console.WriteLine("  Welcome to shut the box");
        Console.WriteLine("   Press Enter to begin.");
        Console.ReadKey();
        Console.Clear();
       
            do
            {
                PrintBox(boxNumbers);  
                playable = false;

                if (diceRoll == 0)
                {
                    dice1 = RollD6(); 
                    dice2 = RollD6();
                    diceRoll = dice1 + dice2;
                }
                Console.WriteLine("\tYou  Rolled");
                Console.WriteLine($"\t[{dice1}]\t[{dice2}]");
                Console.WriteLine("Close flaps to the value of:");
                Console.WriteLine($"\t  (( {diceRoll} ))");

                //check rolled number can be closed

                for(int i = 0; i < boxNumbers.Count; i++) 
                {
                    int check = boxNumbers[i];
                    if (check == diceRoll) playable = true;

                    for (int j = 0; j < boxNumbers.Count; j++)
                    {
                        if (boxNumbers[j] == boxNumbers[i]) continue;

                        check = boxNumbers[j] + boxNumbers[i];

                        if (check == diceRoll) playable = true;

                        for (int k = 0; k < boxNumbers.Count; k++)
                        {
                            if (boxNumbers [k] == boxNumbers[j]||boxNumbers [k] == boxNumbers[i]) continue;

                            check = boxNumbers[k] + boxNumbers[j] + boxNumbers[i];

                            if (check == diceRoll) playable = true;
                        }
                    }
                }

                if (!playable) break;
            
                // Validate and remove user input 

                Console.WriteLine("please select a number to close");
                Console.Write("Number: ");
                while (playable)
                {
                    string? input = Console.ReadLine();
                    try
                    { 
                        int numberImput = Convert.ToInt32(input);
                        
                        if (boxNumbers.Contains(numberImput)&& numberImput <= diceRoll)
                        {
                            selectedNumber = numberImput;
                            break;
                        }
                        else throw new FormatException();

                    }
                    catch(FormatException)
                    { 
                        Console.Write("Please enter a valid number: ");

                    }

                }
                
                boxNumbers.Remove(selectedNumber);
                diceRoll = diceRoll - selectedNumber;


                if (boxNumbers.Count == 0 ) break;
           
                Console.Clear();

            } while (playable);

            // End Game State
        if (boxNumbers.Count == 0 )
        {
            Console.Clear();
            PrintBox(boxNumbers);
            Console.WriteLine("\tYou  Rolled");
            Console.WriteLine($"\t[{dice1}]\t[{dice2}]");
            Console.WriteLine("************************");
            Console.WriteLine("\t++ You Win ++");
            Console.WriteLine("************************");
            
        }

        else
        {
            Console.Clear();
            PrintBox(boxNumbers);
            Console.WriteLine("\tYou  Rolled");
            Console.WriteLine($"\t[{dice1}]\t[{dice2}]");
            Console.WriteLine("--------------------------");
            Console.WriteLine("\t-Game Over-");
            Console.WriteLine("--------------------------");
        
        }
        
        
        
    }

        public static int RollD6()
        {
            return random.Next(1,7);
        }

        static void PrintBox(List<int> boxNumbers)
        {
            int [] boxFlaps = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            Console.Write(" ");
            foreach ( int flap in boxFlaps)
            {
               
                if (boxNumbers.Contains((int)flap))
                Console.Write($"|{flap}|");

                else
                Console.Write("   ");
            }
            
            Console.Write("\n/");
            foreach ( int flap in boxFlaps)
            {

                if (!boxNumbers.Contains((int)flap))
                    Console.Write("| |");
                
                else
                Console.Write("   ");
            }

            Console.Write("\\\n");
    
        }
}
