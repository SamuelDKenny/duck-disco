

var t1 = new int[] { 1, 2, 3 };
var t2 = new int[] { 0, 0, 0 };
var t3 = new int[] { 0, 0, 0 };

DisplayTowers(t1, t2, t3);

//win condition
//while(t3[0] == 0)
// {
//get user input
int inputFrom;
int inputTo;
Console.Write("\nEnter the tower number to move from (1, 2, or 3): ");
string userChoice = Console.ReadLine();
int.TryParse(userChoice, out inputFrom);

//convert input to tower choice



// }


//display towers method

static void DisplayTowers(int[] t1, int[] t2, int[] t3)
{
    Console.Clear();
    var discs = new string[] { "     |     ", "  [===]  ", " [=====] ", "[=======]" };

    Console.WriteLine();
    Console.WriteLine("     -Tower1-   -Tower2-   -Tower3-  ");
    Console.WriteLine();
    Console.WriteLine("        |          |           |      ");

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
}