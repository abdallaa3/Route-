using System;
using System.Collections.Generic;

public interface IShape
{
    double Area { get; }
    void DisplayShapeInfo();
}

public interface ICircle : IShape
{
    double Radius { get; set; }
}

public interface IRectangle : IShape
{
    double Width { get; set; }
    double Height { get; set; }
}

public class Circle : ICircle
{
    public double Radius { get; set; }
    public double Area => Math.PI * Radius * Radius;
    public void DisplayShapeInfo()
    {
        Console.WriteLine($"Circle: Radius = {Radius}, Area = {Area}");
    }
}

public class Rectangle : IRectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Area => Width * Height;
    public void DisplayShapeInfo()
    {
        Console.WriteLine($"Rectangle: Width = {Width}, Height = {Height}, Area = {Area}");
    }
}

public interface IAuthenticationService
{
    bool AuthenticateUser(string username, string password);
    bool AuthorizeUser(string username, string role);
}

public class BasicAuthenticationService : IAuthenticationService
{
    private readonly Dictionary<string, string> _users = new()
    {
        { "user1", "password1" },
        { "user2", "password2" }
    };

    private readonly List<string> _roles = new() { "admin", "user" };

    public bool AuthenticateUser(string username, string password)
    {
        return _users.ContainsKey(username) && _users[username] == password;
    }

    public bool AuthorizeUser(string username, string role)
    {
        return _roles.Contains(role);
    }
}

public interface INotificationService
{
    void SendNotification(string recipient, string message);
}

public class EmailNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"Sending email to {recipient}: {message}");
    }
}

public class SmsNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"Sending SMS to {recipient}: {message}");
    }
}

public class PushNotificationService : INotificationService
{
    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"Sending push notification to {recipient}: {message}");
    }
}

class Program
{
    static void Main()
    {
        ICircle circle = new Circle { Radius = 5 };
        circle.DisplayShapeInfo();

        IRectangle rectangle = new Rectangle { Width = 4, Height = 6 };
        rectangle.DisplayShapeInfo();

        IAuthenticationService authService = new BasicAuthenticationService();
        bool isAuthenticated = authService.AuthenticateUser("user1", "password1");
        bool isAuthorized = authService.AuthorizeUser("user1", "admin");
        Console.WriteLine($"Authenticated: {isAuthenticated}");
        Console.WriteLine($"Authorized: {isAuthorized}");

        INotificationService emailService = new EmailNotificationService();
        emailService.SendNotification("route@gmail.com", "Hello via Email!");

        INotificationService smsService = new SmsNotificationService();
        smsService.SendNotification("1234567890", "Hello via SMS!");

        INotificationService pushService = new PushNotificationService();
        pushService.SendNotification("user123", "Hello via Push Notification!");
    }
}