﻿using NATS.Client;
using Newtonsoft.Json;
using System.Text;

namespace Post_Service.Messaging
{
    public class NatsService : IMessageService
    {
        private IConnection connection = null;
        private IAsyncSubscription subscription = null;
        private readonly string connectionString = "";

        public NatsService()
        {
            Connect();
            Subscribe("Post-Service");
        }

        public void Connect()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            Options options = ConnectionFactory.GetDefaultOptions();
            options.Url = connectionString;

            Console.WriteLine("Trying to connect to the NATS Server");

            try
            {
                connection = connectionFactory.CreateConnection(options);
                Console.WriteLine("Succesfully connected to the NATS server");
            }
            catch
            {
                Console.WriteLine("Failed to connect to the NATS server");
            }
        }

        public void Publish<T>(string target, T data)
        {
            string message = JsonConvert.SerializeObject(NatsMessage.Create(target, data));
            connection.Publish(target, Encoding.UTF8.GetBytes(message));

            Console.WriteLine("Message sent: " + message);
        }

        public void Subscribe(string target)
        {
            EventHandler<MsgHandlerEventArgs> handler = (sender, args) =>
            {
                // print the message
                string receivedMessage = Encoding.UTF8.GetString(args.Message.Data);
                Console.WriteLine("Message received: " + receivedMessage);
            };

            subscription = connection.SubscribeAsync(target);
            if (subscription != null)
            {
                subscription.MessageHandler += handler;
                subscription.Start();
            }
        }
    }
}