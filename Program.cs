string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
string file = Path.Combine(currentDirectory, "../../../input.txt");
string path = Path.GetFullPath(file);
string[] text = File.ReadAllText(path).Split("\n");

int count = 0;
int len = text.Length;
for (int i = 0; i < len; i++)
{
    for (int j = 0; j < len; j++)
    {
        if (i == 0 || i == len - 1 || j == 0 || j == len - 1)
        {
            count++;
            continue;
        }
        int val = text[i][j] - '0';
        List<int> topSide = new();
        List<int> leftSide = new();
        List<int> rightSide = new();
        List<int> bottomSide = new();
        // Check visibility from edges
        for (int k = 1; k <= i; k++) //check topside
        {
            topSide.Add(text[i - k][j] - '0');
        }
        for (int k = 1; k <= j; k++) //check left side
        {
            leftSide.Add(text[i][j - k] - '0');
        }
        for (int k = 1; k < len - j; k++) //check right side
        {
            rightSide.Add(text[i][j + k] - '0');
        }
        for (int k = 1; k < len - i; k++) //check bottom side
        {
            bottomSide.Add(text[i + k][j] - '0');
        }

        if (val > topSide.Max() || val > leftSide.Max()
        || val > rightSide.Max() || val > bottomSide.Max())
        { count++; }
    }
}

Console.WriteLine("Number of visible trees is: " + count);

// Part 2
int scenicScore = 0;
for (int i = 0; i < len; i++)
{
    for (int j = 0; j < len; j++)
    {
        if (i == 0 || i == len - 1 || j == 0 || j == len - 1)
        {
            continue;
        }
        int val = text[i][j] - '0';
        int topSide = 0;
        int leftSide = 0;
        int rightSide = 0;
        int bottomSide = 0;
        // Check visibility from edges
        for (int k = 1; k <= i; k++) //check topside
        {
            topSide++;
            if (val <= text[i - k][j] - '0')
            {
                break;
            }
        }
        for (int k = 1; k <= j; k++) //check left side
        {
            leftSide++;
            if (val <= text[i][j - k] - '0')
            {
                break;
            }
        }
        for (int k = 1; k < len - j; k++) //check right side
        {
            rightSide++;
            if (val <= text[i][j + k] - '0')
            { break; }
        }
        for (int k = 1; k < len - i; k++) //check bottom side
        {
            bottomSide++;
            if (val <= text[i + k][j] - '0')
                break;
        }
        int temp = topSide * leftSide * rightSide * bottomSide;
        if (temp > scenicScore)
        {
            scenicScore = temp;
        }
    }
}

Console.WriteLine("Highest scenic sore is: " + scenicScore);
