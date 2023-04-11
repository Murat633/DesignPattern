using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new SmsSender());
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("saved");
        }
        public abstract void Send(Body body);
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender",body.Title);
        }
    }

    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender", body.Title);
        }
    }
    //...

    class CustomerManager
    {
        MessageSenderBase _messageSender;
        public CustomerManager(MessageSenderBase messageSender)
        {
            _messageSender = messageSender;
        }

        public void UpdateCustomer()
        {
            _messageSender.Send(new Body { Title = "About the course!" });
            Console.WriteLine("updated customer");
        }
    }
}
