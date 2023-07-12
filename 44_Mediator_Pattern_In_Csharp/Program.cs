using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            var TaxiCenter = new TaxiCenter();
            var Taxi1 = new ConcreateTaxi(TaxiCenter);
            var Taxi2 = new ConcreateTaxi(TaxiCenter);
            TaxiCenter.RegisterTaxies(Taxi1);
            TaxiCenter.RegisterTaxies(Taxi2);
            Taxi1.NotifyColleague("41.40338, 2.17403");

            Console.WriteLine(Taxi2.GetMessage());

            Console.ReadKey();

        }
    }

    interface ITaxiCenter
    {
        void NotifyColleague(Taxi taxi, string message);
    }

    class TaxiCenter : ITaxiCenter
    {

        private readonly List<Taxi> Taxies;

        public TaxiCenter()
        {
            Taxies = new List<Taxi>();
        }

        public void RegisterTaxies(Taxi taxi)
        {
            Taxies.Add(taxi);
        }

        void ITaxiCenter.NotifyColleague(Taxi givenTaxi, string message)
        {
            foreach (Taxi _taxi in Taxies)
            {
                if (_taxi != givenTaxi)
                {
                    _taxi.Receive($"My GPS Coordinates are:  {message}");
                }
            }
        }

    }

    abstract class Taxi
    {

        protected string ReceivedMessage
        {
            get;
            set;
        }

        protected ITaxiCenter TaxiCenter;
        public Taxi(ITaxiCenter TaxiCenter)
        {
            this.TaxiCenter = TaxiCenter;

        }
        public abstract void NotifyColleague(string message);

        public abstract void Receive(string message);
        public abstract string GetMessage();

    }

    class ConcreateTaxi : Taxi
    {
        public ConcreateTaxi(ITaxiCenter TaxiCenter) : base(TaxiCenter)
        {

        }

        public override void NotifyColleague(string message)
        {
            this.TaxiCenter.NotifyColleague(this, message);
        }

        public override void Receive(string message)
        {
            this.ReceivedMessage = message;
        }
        public override string GetMessage() => ReceivedMessage;
    }

    class ConcreateTaxi2 : Taxi
    {
        public ConcreateTaxi2(ITaxiCenter TaxiCenter) : base(TaxiCenter)
        {

        }
        public override void NotifyColleague(string message)
        {
            this.TaxiCenter.NotifyColleague(this, message);
        }

        public override void Receive(string message)
        {
            this.ReceivedMessage = message;
        }
        public override string GetMessage() => ReceivedMessage;

    }

}