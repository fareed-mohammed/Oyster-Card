using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OysterCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card();
            Console.WriteLine("Loading a card with £30 \n");
            card.AddMoney(30);

            Journey journeyHolbornToCourt = new Journey(new Fare());
            journeyHolbornToCourt.SetStartPoint(Transport.TUBE, new StationZone(Station.HOLBORN), card);
            journeyHolbornToCourt.SetEndPoint(new StationZone(Station.EARLS_COURT));

            Console.WriteLine($"Card Balance after first journey (Tube Holborn to Earl’s Court)  is £{card.GetBalance()} \n");

            Journey journeyBusEarlToChelsea = new Journey(new Fare());
            journeyBusEarlToChelsea.SetStartPoint(Transport.BUS, null, card);
            journeyBusEarlToChelsea.SetEndPoint(null);

            Console.WriteLine($"Card Balance after second journey (328 bus from Earl’s Court to Chelsea) is £{card.GetBalance()} \n");

            Journey journeyEarlsToHammersmith = new Journey(new Fare());
            journeyEarlsToHammersmith.SetStartPoint(Transport.TUBE, new StationZone(Station.EARLS_COURT), card);
            journeyEarlsToHammersmith.SetEndPoint(new StationZone(Station.HAMMERSMITH));

            Console.WriteLine($"Card Balance after third journey (Tube Earl’s court to Hammersmith) is £{card.GetBalance()} \n");
            Console.ReadLine();
        }
    }
}
