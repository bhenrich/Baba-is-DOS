using System;
using System.Collections.Generic;

public class Cell
{
    public char Symbol { get; set; }
    public ConsoleColor Color { get; set; }
    public HashSet<string> Tags { get; private set; }
    public bool State { get; set; } = false;
    public int[] coordinates { get; set; }

    public Cell(char symbol, ConsoleColor color, bool state = false)
    {
        Symbol = symbol;
        Color = color;
        Tags = new HashSet<string>();
        State = state;
    }

    public void AddTag(string tag)
    {
        Tags.Add(tag);
    }

    public void RemoveTag(string tag)
    {
        Tags.Remove(tag);
    }

    public bool HasTag(string tag)
    {
        return Tags.Contains(tag);
    }

    // Triggered when the player walks against the cell
    public virtual void OnPlayerBump()
    {
    }

    // Triggered when the player walks over the cell
    public virtual void OnPlayerWalkOver()
    {
    }

    // Triggered when the player interacts with the cell
    public virtual void OnPlayerInteract(Cell[,] grid, int[] coordinates)
    {
        // Get the specific cell from the grid using coordinates
        Cell targetCell = grid[coordinates[1], coordinates[0]];

        // Check if the targeted cell is a door
        if (targetCell.HasTag("door"))
        {
            // Toggle the state of the door
            targetCell.State = !targetCell.State;

            if (targetCell.State)
            {
                targetCell.Symbol = 'O';
                targetCell.AddTag("walkable");
            }
            else
            {
                targetCell.Symbol = 'D';
                targetCell.RemoveTag("walkable");
            }
        }
    }

}
