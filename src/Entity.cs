class Entity
{
    /* public int EntityID { get; set; }
    public string Name { get; set; }
    public char Symbol { get; set; }
    public ConsoleColor Color { get; set; }
    public Cell cell { get; set; }

    public int moveChance { get; set; }
    public int attackChance { get; set; }
    public int health { get; set; }
    public int attack { get; set; }
    public int defense { get; set; }

    public Entity(int entityID, string name, char symbol, ConsoleColor color, Cell cell, int moveChance, int attackChance, int health, int attack, int defense)
    {
        EntityID = entityID;
        Name = name;
        Symbol = symbol;
        Color = color;
        this.cell = cell;
        this.moveChance = moveChance;
        this.attackChance = attackChance;
        this.health = health;
        this.attack = attack;
        this.defense = defense;
    }

    public void Move(int[] direction)
    {
        int[] newCoordinates = new int[2] { cell.coordinates[0] + direction[0], cell.coordinates[1] + direction[1] };
        Cell targetCell = cell.grid[newCoordinates[1], newCoordinates[0]];
        if (targetCell.HasTag("walkable"))
        {
            cell.grid[cell.coordinates[1], cell.coordinates[0]] = cell.underlyingCell;
            cell.underlyingCell = targetCell;
            cell.grid[newCoordinates[1], newCoordinates[0]] = cell;
            cell.coordinates = newCoordinates;
        }
        else
        {
            break;
        }
    }

    public void RollMove()
    {
        int roll = Dice.Roll(100, 1);
        if (roll <= moveChance)
        {
            int[] direction = new int[2] { Dice.Roll(3, 1) - 2, Dice.Roll(3, 1) - 2 };
            Move(direction);
        }
    } */
}