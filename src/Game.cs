using System;
using System.Data;

public class Game
{
    private Cell[,] grid = new Cell[10, 10];
    private Cell playerUnderlyingCell;
    private RuleOverlay ruleOverlay;
    private int playerX = 0;
    private int playerY = 0;
    private bool isRunning = true;
    private bool debug = false;

    public Game(string[] args)
    {
        Console.Clear();
        string[] validargs = { "debug", "map" };
        /* TODO
            parse all args, if debug is present, set debug to true
            if map is present, next arg is the map file path
        */

        InitializeGrid();

        ruleOverlay = new RuleOverlay(grid);
    }

    public void Run()
    {
        Render();
        HandleInput();
    }

    private void InitializeGrid(string? mapPath = null)
    {
        Map map = new Map();
        map.LoadMap(mapPath ?? "map.txt");
        grid = map.grid;
        playerX = map.spawnPoint[0];
        playerY = map.spawnPoint[1];
        playerUnderlyingCell = CellDefinitions.Floor;
    }



    private void Render()
    {
        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                Cell cell = grid[y, x];
                if (!cell.HasTag("noclear"))
                {
                    Console.SetCursorPosition(x, y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
        }


        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                Cell cell = grid[y, x];
                if (!cell.HasTag("invisible") && !cell.HasTag("noclear"))
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = cell.Color;
                    Console.Write(cell.Symbol);
                    Console.ResetColor();
                }
            }
        }
    }

    private void HandleInput()
    {
        // Implement input handling
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.W:
                TryMovePlayer(0, -1);
                break;
            case ConsoleKey.S:
                TryMovePlayer(0, 1);
                break;
            case ConsoleKey.A:
                TryMovePlayer(-1, 0);
                break;
            case ConsoleKey.D:
                TryMovePlayer(1, 0);
                break;
            case ConsoleKey.UpArrow:
                TryInteractWithCell(0, -1);
                break;
            case ConsoleKey.DownArrow:
                TryInteractWithCell(0, 1);
                break;
            case ConsoleKey.LeftArrow:
                TryInteractWithCell(-1, 0);
                break;
            case ConsoleKey.RightArrow:
                TryInteractWithCell(1, 0);
                break;
            case ConsoleKey.O:
                TryInteractWithCell(0, 0);
                break;
            case ConsoleKey.R:
                if (ruleOverlay.isOpened) ruleOverlay.CloseOverlay();
                else ruleOverlay.OpenOverlay();
                break;
            case ConsoleKey.Escape:
                isRunning = false;
                break;
        }

        Render();
        HandleInput();
    }

    private void TryMovePlayer(int dx, int dy)
    {
        int newX = playerX + dx;
        int newY = playerY + dy;

        // Check grid boundaries and cell walkability
        if (newX >= 0 && newX < grid.GetLength(1) && newY >= 0 && newY < grid.GetLength(0))
        {
            Cell targetCell = grid[newY, newX];
            if (targetCell.HasTag("walkable"))
            {
                // Restore the previous cell
                grid[playerY, playerX] = playerUnderlyingCell;

                // Update player position
                playerX = newX;
                playerY = newY;

                // Remember the new underlying cell
                playerUnderlyingCell = grid[playerY, playerX];

                // Set the player cell
                grid[playerY, playerX] = new Cell('@', ConsoleColor.White);
                grid[playerY, playerX].AddTag("player");
            }
        }
    }

    private void TryInteractWithCell(int dx, int dy)
    {
        int newX = playerX + dx;
        int newY = playerY + dy;

        // Check grid boundaries and cell walkability
        if (newX >= 0 && newX < grid.GetLength(1) && newY >= 0 && newY < grid.GetLength(0))
        {
            Cell targetCell = grid[newY, newX];
            if (targetCell.HasTag("interactable"))
            {
                targetCell.OnPlayerInteract(grid, targetCell.coordinates);
            }
        }
    }

}
