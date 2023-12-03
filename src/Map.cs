using System;
using System.Net.Mail;
using System.IO;

public class Map
{
    public int[] dimensions { get; set; }
    public int[] spawnPoint { get; set; }
    public Cell[,] grid { get; set; }


    public void LoadMap(string path)
    {
        string[] lines = File.ReadAllLines(path);

        spawnPoint = new int[2];
        spawnPoint = lines[0].Split(',').Select(int.Parse).ToArray();

        string metadata = lines[0];
        lines = lines.Skip(1).ToArray();

        dimensions = new int[2] { lines.Length, lines.Max(line => line.Length) };

        grid = new Cell[dimensions[0], dimensions[1]];

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < dimensions[1]; x++)
            {
                if (x < lines[y].Length)
                {
                    char symbol = lines[y][x];
                    // Create a new cell based on the symbol
                    grid[y, x] = CreateCellFromSymbol(symbol);
                    grid[y, x].coordinates = new int[2] { x, y };
                }
                else
                {
                    grid[y, x] = new Cell(' ', ConsoleColor.Black, false) { Tags = { "solid" } }; // For missing characters in the line
                }
            }
        }

        /* SpawnEntities(metadata); */

        grid[spawnPoint[1], spawnPoint[0]] = new Cell('@', ConsoleColor.Yellow) { Tags = { "player", "walkable" } };
    }

    private Cell CreateCellFromSymbol(char symbol)
    {
        switch (symbol)
        {
            case '#': return new Cell('#', ConsoleColor.Gray) { Tags = { "solid" } };
            case '.': return new Cell('.', ConsoleColor.White) { Tags = { "walkable" } };
            case 'D': return new Cell('D', ConsoleColor.DarkYellow, false) { Tags = { "door", "interactable" } };
            case 'T': return new Cell('.', ConsoleColor.Red) { Tags = { "walkable", "trap" } };
            case 'S': return new Cell('.', ConsoleColor.Gray) { Tags = { "walkable", "trap" } };
            case 'E': return new Cell('E', ConsoleColor.Green) { Tags = { "walkable", "exit" } };
            default: return new Cell(' ', ConsoleColor.Black) { Tags = { "solid" } }; // Default case for unknown symbols
        }
    }

    /* private Entity SpawnEntities(string metadata)
    {
        string entityData = metadata.Split('!')[1];

        string[] entityEntries = entityData.Split(';');
        // entityEntries format: "entitySymbol":"x","y"
        switch (entityEntries[0])
        {
            case 'G':
                return new Entity(0, "Goblin", 'G', ConsoleColor.DarkGreen, grid[entityEntries[2], entityEntries[4]], 50, 50, 10, 5, 5);
            default: return null;
        }
    } */

}