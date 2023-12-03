using System;


// usage (1d6): int roll = Dice.Roll(6, 1); (if char needed .ToString[0])
public class Dice
{
    public static int Roll(int sides, int count = 1)
    {
        int total = 0;
        for (int i = 0; i < count; i++)
        {
            total += new Random().Next(1, sides + 1);
        }
        return total;
    }
}