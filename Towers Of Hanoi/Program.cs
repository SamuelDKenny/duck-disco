

var t1 = new int[] { 1, 2, 3 };
var t2 = new int[] { 0, 0, 0 };
var t3 = new int[] { 0, 0, 0 };

DisplayTowers(t1, t2, t3);

//win condition
while(t3[0] == 0)
{
    //get user input
    int inputFrom;
    int input2;
    Console.Write("\nEnter the tower number to move from (1, 2, or 3): ");
    string userChoice = Console.ReadLine();
    int.TryParse(userChoice, out inputFrom);

    //convert input to tower choice
    switch (inputFrom)
    {
        case 1:

            TowerMove(t1, t2);

        break;

        case 2:
        
            if (t2[2] == 0)
            {
                Console.WriteLine("There is nothing here to move!\n");
                break;
            }

            Console.Write("\nWhich tower would you like to move to: ");
            string choice2 = Console.ReadLine();
            if (int.TryParse(choice2, out input2))
            {
                if (input2 == 1)
                {
                    TowerMove(t2, t1);
                }

                else if (input2 == 2)
                {
                    break;
                }

                else if (input2 == 3)
                {
                    TowerMove(t2, t3);
                }

                else
                {
                    Console.WriteLine($"There is no tower - {input2}"); ;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

        break;

        case 3:

            TowerMove(t3, t2);

        break;

        default:

            Console.WriteLine($"\nInvalid input! \"{inputFrom}\"");
            Console.WriteLine("please enter tower number.");

        break;
           
    }

    DisplayTowers(t1, t2, t3);

}


//display towers method

static void DisplayTowers(int[] t1, int[] t2, int[] t3)
{
    Console.Clear();
    var discs = new string[] { "     |     ", "   [===]   ", "  [=====]  ", " [=======] " };

    Console.WriteLine();
    Console.WriteLine("      -Tower1-    -Tower2-    -Tower3-  ");
    Console.WriteLine();
    Console.WriteLine("         |           |           |      ");

    for (int i = 0; i < t1.GetLength(0); i++)
    {
        Console.WriteLine($"    {discs[t1[i]]} {discs[t2[i]]} {discs[t3[i]]}");
    }
    Console.WriteLine("  #####################################");
}

//check and move disc method

static void TowerMove(int[] towerA, int[] towerB)
{
    //find moving value
    bool validMove = true;
    int moving = 0;
    int iMoving = 0;

    foreach (int value in towerA)
    {
        if (value > 0)
        {
            moving = value;
            iMoving = Array.IndexOf(towerA, moving);
            break;
        }
    }

    if (moving == 0)
    {
        Console.WriteLine();
        Console.WriteLine("There is nothing here to move!\n");
    }

    //find value of target top
    int tCheck = 0;
    int iTarget = 0;

    for (int i = 0; i < towerB.Length; i++)
    {
        if (towerB[i] > 0)
        {
            tCheck = towerB[i];
        }
        else
        {
            tCheck = 0;
        }
    }

    //find target index to replace
    for (int i = towerB.Length - 1; i >= 0; i--)
    {
        if (towerB[i] == 0)
        {
            iTarget = i;
            break;
        }
    }

    validMove = moving < tCheck || tCheck == 0;

    if (validMove)
    {
        towerB[iTarget] = moving;
        towerA[iMoving] = 0;
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Smallest must stay on top!\n");
    }

}