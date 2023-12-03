using System.Security.Principal;

class RuleOverlay
{
    public Cell[,] grid;
    public bool isOpened;

    public RuleOverlay(Cell[,] grid)
    {
        this.grid = grid;
        isOpened = false;
    }

    public void OpenOverlay()
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                if (grid[y, x].Symbol == '@')
                {
                    int _x = grid[x, y].coordinates[1];
                    int _y = grid[x, y].coordinates[0];

                    Console.SetCursorPosition(_x + 1, _y);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write("Baba");
                    int wordlength = 4;

                    for (int i = 0; i < wordlength; i++)
                    {
                        int tx = _x + 1 + i;
                        int ty = _y;

                        grid[ty, tx].AddTag("noclear");
                    }

                    Console.ResetColor();

                    x = grid.GetLength(1);
                    y = grid.GetLength(0);
                }
            }
        }
    }

    public void CloseOverlay()
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                if (grid[y, x].HasTag("noclear"))
                {
                    grid[y, x].RemoveTag("noclear");
                }
            }
        }
    }


}