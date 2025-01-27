using System;
using System.Collections.Generic;

public class Point3D
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return $"Point Coordinates: ({X}, {Y}, {Z})";
    }
}

public interface ICloneable
{
    object Clone();
}

public class MathOperations
{
    public void Add(int a, int b) => Console.WriteLine($"Sum: {a + b}");
    public void Subtract(int a, int b) => Console.WriteLine($"Difference: {a - b}");
    public void Multiply(int a, int b) => Console.WriteLine($"Product: {a * b}");
    public void Divide(int a, int b)
    {
        if (b != 0)
            Console.WriteLine($"Quotient: {a / b}");
        else
            Console.WriteLine("Cannot divide by zero.");
    }
}

public abstract class Discount
{
    public string DiscountType { get; set; }
    public abstract decimal CalculateDiscount(decimal price, int quantity);
}

public class PercentageDiscount : Discount
{
    public decimal Percentage { get; set; }
    public PercentageDiscount(decimal percentage)
    {
        Percentage = percentage;
        DiscountType = "Percentage Discount";
    }
    public override decimal CalculateDiscount(decimal price, int quantity) => price * quantity * (Percentage / 100);
}

public class FlatDiscount : Discount
{
    public decimal FlatAmount { get; set; }
    public FlatDiscount(decimal flatAmount)
    {
        FlatAmount = flatAmount;
        DiscountType = "Flat Discount";
    }
    public override decimal CalculateDiscount(decimal price, int quantity) => FlatAmount * Math.Min(quantity, 1);
}

public class BuyOneGetOneDiscount : Discount
{
    public BuyOneGetOneDiscount() { DiscountType = "Buy One Get One Discount"; }
    public override decimal CalculateDiscount(decimal price, int quantity) => quantity > 1 ? price / 2 * (quantity - 1) : 0;
}

public abstract class User
{
    public string Name { get; set; }
    public abstract Discount GetDiscount();
}

public class RegularUser : User
{
    public RegularUser(string name) { Name = name; }
    public override Discount GetDiscount() => new PercentageDiscount(5);
}

public class PremiumUser : User
{
    public PremiumUser(string name) { Name = name; }
    public override Discount GetDiscount() => new FlatDiscount(100);
}

public class GuestUser : User
{
    public GuestUser(string name) { Name = name; }
    public override Discount GetDiscount() => null;
}

public class Program
{
    public static void Main()
    {
        Point3D p1 = new Point3D(10, 10, 10);
        Console.WriteLine(p1.ToString());

        Console.WriteLine("Enter coordinates for point 2 (X Y Z):");
        var input = Console.ReadLine()?.Split(' ');
        int x = int.Parse(input[0]);
        int y = int.Parse(input[1]);
        int z = int.Parse(input[2]);
        Point3D p2 = new Point3D(x, y, z);

        Console.WriteLine(p1 == p2);

        List<Point3D> points = new List<Point3D> { p1, p2 };
        points.Sort((a, b) => a.X == b.X ? (a.Y == b.Y ? a.Z.CompareTo(b.Z) : a.Y.CompareTo(b.Y)) : a.X.CompareTo(b.X));

        foreach (var point in points)
        {
            Console.WriteLine(point.ToString());
        }

        Console.WriteLine("Enter your type (Regular, Premium, Guest):");
        string userType = Console.ReadLine();
        User user;

        switch (userType)
        {
            case "Regular":
                user = new RegularUser("Regular User");
                break;
            case "Premium":
                user = new PremiumUser("Premium User");
                break;
            case "Guest":
                user = new GuestUser("Guest User");
                break;
            default:
                Console.WriteLine("Invalid user type.");
                return;
        }

        Console.WriteLine("Enter product price:");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter product quantity:");
        int quantity = int.Parse(Console.ReadLine());

        Discount discount = user.GetDiscount();
        decimal totalDiscount = discount != null ? discount.CalculateDiscount(price, quantity) : 0;
        decimal finalPrice = (price * quantity) - totalDiscount;

        Console.WriteLine($"Total Discount: {totalDiscount}");
        Console.WriteLine($"Final Price: {finalPrice}");
    }
}