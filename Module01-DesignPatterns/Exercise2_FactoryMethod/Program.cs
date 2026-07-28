using System;

namespace DesignPatterns.FactoryMethod
{
    public interface INotification
    {
        void Send(string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[EMAIL SENT]: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[SMS SENT]: {message}");
        }
    }

    public abstract class NotificationFactory
    {
        public abstract INotification CreateNotification();

        public void Deliver(string message)
        {
            var notification = CreateNotification();
            notification.Send(message);
        }
    }

    public class EmailFactory : NotificationFactory
    {
        public override INotification CreateNotification() => new EmailNotification();
    }

    public class SmsFactory : NotificationFactory
    {
        public override INotification CreateNotification() => new SmsNotification();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Executing Factory Method Pattern ---");

            NotificationFactory emailFactory = new EmailFactory();
            emailFactory.Deliver("Welcome to the Deep Skilling program!");

            NotificationFactory smsFactory = new SmsFactory();
            smsFactory.Deliver("Your OTP is 492011.");
        }
    }
}