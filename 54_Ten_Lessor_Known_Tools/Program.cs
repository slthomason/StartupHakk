//RabbitMQ

using RabbitMQ.Client;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);

            Console.WriteLine(" [x] Sent {0}", message);
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}


//SignalR
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}

//SignalR Client Side
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.on("ReceiveMessage", (user, message) => {
    // Update the UI with the received message
});

connection.start();

//Sentry: Error Monitoring and Tracking for .NET Applications

using Sentry;

try
{
    // Code that might throw an exception
}
catch (Exception ex)
{
    var e = new SentryEvent(ex);
    SentrySdk.CaptureEvent(e);
}

//Hangfire: Scheduling Background Tasks and Jobs in .NET Applications
using Hangfire;

RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring Job"), Cron.Minutely);

//MassTransit: A Distributed Application Framework for Messaging and Event-Driven Architectures
using System;
using System.Threading.Tasks;
using MassTransit;

namespace MyApp
{
    public class Program
    {
        public static async Task Main()
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            await busControl.StartAsync();

            try
            {
                await busControl.Send(new MyMessage { Text = "Hello, world!" });
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }

    public class MyMessage
    {
        public string Text { get; set; }
    }
}


//CsvHelper: A library for reading and writing CSV files in C# applications
using (var reader = new StreamReader("path/to/your/file.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    csv.Configuration.HasHeaderRecord = true; // set to true if your CSV file has a header row
    csv.Configuration.RegisterClassMap<MyClassMap>(); // if you need to map the CSV data to a C# object

    var records = csv.GetRecords<MyClass>().ToList(); // get a list of C# objects from the CSV file
}


//Nethereum: Interact with Ethereum blockchain using .NET

using Nethereum.Web3;

var web3 = new Web3("http://localhost:8545");
var balance = await web3.Eth.GetBalance.SendRequestAsync("0x6a1c6e2d6b50c6b52a6a32c6e42a8e1d6a8115f5");
Console.WriteLine($"Balance: {balance}");

//CardanoSharp: A .NET Library for Interacting with the Cardano Blockchain
using CardanoSharp;
using CardanoSharp.Wallet;
using CardanoSharp.Wallet.Models.Transactions;
using System;
using System.Threading.Tasks;

namespace CardanoSharpExample
{
   public class Program
    {
        public static async Task Main(string[] args)
        {
            var nodeUrl = "https://cardano-node-url.com"; // Replace with the URL of your Cardano node
            var cardanoSharp = new CardanoSharp(nodeUrl);

            var blockHeight = await cardanoSharp.GetBlockchainHeight();
            Console.WriteLine("Current Cardano blockchain height: " + blockHeight);
        }
    }
}

//BlockM3: A .NET Library for Building Blockchain-Based Applications

using BlockM3;
using BlockM3.AES;
using BlockM3.BlockChain;
using BlockM3.Cryptography;
using BlockM3.Validators;

// Generate a Bitcoin address
BitcoinAddressGenerator generator = new BitcoinAddressGenerator();
string privateKey = "examplePrivateKey";
string publicKey = generator.GeneratePublicAddress(privateKey);
Console.WriteLine("Public Address: " + publicKey);



//Neo: A Blockchain Platform with .NET Based Virtual Machine

using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

public class HelloWorld : SmartContract
{
    public static void Main(string message)
    {
        Storage.Put(Storage.CurrentContext, "Hello", message);
    }
}