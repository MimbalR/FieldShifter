using static System.Console;
// vars
const ConsoleColor defaultFontColor = ConsoleColor.White;

int numWidthMax = 8, numLengthMax = 8;
int[,] nums = new int[numLengthMax,numWidthMax];

int maxWindowCharLength = 90;

OptionChoice currentOptionSelected = OptionChoice.Action;

bool toFill = true; // this boolean saves whether to fill nums on next run, so on press enter
float quid = 10f;

// runtime
Clear(); // clear previous stuff
// program to use only carriage return, and no clears

// test zone
// we need character tests for max limits
// on first boot can have configuration file and set the correct size
// setting menu with certain keybind


while(true)
{
    if (toFill)
        FillNums();
    
    DrawGrid();
    DrawResources();
    DrawOptions();
    GetInput();
}

// functions
void FillNums()
{
    for (int i = 0; i < numLengthMax; i++)
    {
        for (int j = 0; j < numWidthMax; j++)
        {
            nums[i,j] = Random.Shared.Next(0, 5); // might want modifications to fill density
        }
    }
}

void DrawResources()
{
    // create a single string to draw (remove any color customization for each element) 
    // maybe worth attempting implementing later to see if any return on it occurs
    string drawStr = string.Empty;
    drawStr += $"Money: {MathF.Round(quid, 2)}£ |";
    ForegroundColor = ConsoleColor.Yellow;
    WriteLine(drawStr);
    WriteLine();
}

void DrawGrid()
{
    SetCursorPosition(0,0); // atempt at carriage return and overwrite method
    for (int y = 0; y < numLengthMax; y++)
    {
        for (int x = 0; x < numWidthMax; x++)
        {
            switch (nums[y, x])
            {
                case 0:
                    ForegroundColor = ConsoleColor.Green;
                    Write("$ ");
                    ForegroundColor = defaultFontColor;
                    break;
                case 1:
                    ForegroundColor = ConsoleColor.Cyan;
                    Write("$ ");
                    ForegroundColor = defaultFontColor;
                    break;
                case 2:
                    ForegroundColor = ConsoleColor.Yellow;
                    Write("% ");
                    ForegroundColor = defaultFontColor;
                    break;
                case 3:
                    ForegroundColor = ConsoleColor.Red;
                    Write("* ");
                    ForegroundColor = defaultFontColor;
                    break;
                case 4:
                    ForegroundColor = ConsoleColor.Blue;
                    Write("@ ");
                    ForegroundColor = defaultFontColor;
                    break;
            }
        }
        WriteLine();
    }

}

void DrawOptions()
{
    WriteLine();
    ForegroundColor = ConsoleColor.Blue;
    WriteLine(GenLengthOfChar('█', maxWindowCharLength));
    ForegroundColor = defaultFontColor;
    // above draws the seperation
    // now we write the options
    WriteLine();
    if (currentOptionSelected == OptionChoice.Action)
        ForegroundColor = ConsoleColor.Yellow;
    else
        ForegroundColor = defaultFontColor;
    Write($"{OptionChoice.Action} | ");
    if (currentOptionSelected == OptionChoice.Upgrade)
        ForegroundColor = ConsoleColor.Yellow;
    else
        ForegroundColor = defaultFontColor;
    Write($"{OptionChoice.Upgrade} | ");
    if (currentOptionSelected == OptionChoice.Research)
        ForegroundColor = ConsoleColor.Yellow;
    else
        ForegroundColor = defaultFontColor;
    Write($"{OptionChoice.Research} | ");
    if (currentOptionSelected == OptionChoice.Facility)
        ForegroundColor = ConsoleColor.Yellow;
    else
        ForegroundColor = defaultFontColor;
    Write($"{OptionChoice.Facility} | ");

    ForegroundColor = defaultFontColor;
    WriteLine();
    switch (currentOptionSelected)
    {
        case OptionChoice.Action:
            DrawActionChoices();
            break;
        case OptionChoice.Upgrade:
            DrawUpgradeChoices();
            break;
        case OptionChoice.Research:
            DrawResearchChoices();
            break;
        case OptionChoice.Facility:
            DrawFacilityChoices();
            break;
    }
}

void DrawActionChoices()
{
    string drawStr = string.Empty;
    drawStr += "Generic C-Harvest | ";
    drawStr += "Generic G-Harvest | ";
    ForegroundColor = ConsoleColor.Blue;
    WriteLine(drawStr);
}

void DrawUpgradeChoices()
{
    WriteLine(GenLengthOfChar(' ', maxWindowCharLength));
}

void DrawResearchChoices()
{
    WriteLine(GenLengthOfChar(' ', maxWindowCharLength));
}

void DrawFacilityChoices()
{
    WriteLine(GenLengthOfChar(' ', maxWindowCharLength));
}


void GetInput()
{
    ConsoleKeyInfo input = ReadKey(true);
    // next turn
    if (input.Key == ConsoleKey.Enter)
    {
        toFill = true;
        return;
    }
    toFill = false;
    switch (input.Key)
    {
        case ConsoleKey.Z:
            currentOptionSelected = OptionChoice.Action;
            return;
        case ConsoleKey.X:
            currentOptionSelected = OptionChoice.Upgrade;
            return;
        case ConsoleKey.C:
            currentOptionSelected = OptionChoice.Research;
            return;
        case ConsoleKey.V:
            currentOptionSelected = OptionChoice.Facility;
            return;
    }
}

// misc functions for use
string GenLengthOfChar(char c, int len)
{
    string s = string.Empty;
    for (int i = 0; i < len; i++)
    {
        s += c;
    }
    return s;
}

enum OptionChoice
{
    Action,
    Upgrade,
    Research,
    Facility
}