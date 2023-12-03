using System;

public static class CellDefinitions
{
    public static Cell Wall => new Cell('#', ConsoleColor.Gray) { Tags = { "solid" } };
    public static Cell Floor => new Cell('.', ConsoleColor.White) { Tags = { "walkable" } };
    public static Cell Door => new Cell('D', ConsoleColor.DarkYellow, false) { Tags = { "door", "interactable" } };
    public static Cell Trap => new Cell('.', ConsoleColor.Red) { Tags = { "walkable", "trap" } };
    public static Cell StealthTrap => new Cell('.', ConsoleColor.Gray) { Tags = { "walkable", "trap" } };
    public static Cell Exit => new Cell('E', ConsoleColor.Green) { Tags = { "walkable", "exit" } };
    public static Cell Void => new Cell(' ', ConsoleColor.Black) { Tags = { "solid" } };
    public static Cell Player => new Cell('@', ConsoleColor.Yellow) { Tags = { "player", "walkable" } };


    public static Cell[] All = new Cell[]
    {
        Wall,
        Floor,
        Door,
        Trap,
        StealthTrap,
        Exit,
        Void,
        Player
    };
}
