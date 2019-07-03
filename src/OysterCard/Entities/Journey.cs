using System;

namespace OysterCard
{
    public class Journey
    {
        private StationZone _startPoint;
        private StationZone _endPoint;
        private Transport _transport;

        private Card _card;
        private Fare _fare;

        public Journey(Fare fare)
        {
            _fare = fare;
        }

        public StationZone GetStartPoint()
        {
            return _startPoint;
        }

        public void SetStartPoint(Transport transport, StationZone startPoint, Card card)
        {
            try
            {
                _fare.Validate(transport, card);
                _fare.ChargeMax(transport, card);   

            }
            catch (FareException ex)
            {
                Console.WriteLine(ex.Message);
            }

            _transport = transport;
            _card = card;
            _startPoint = startPoint;
        }

        public StationZone GetEndPoint()
        {
            return _endPoint;
        }

        public void SetEndPoint(StationZone endPoint)
        {
            _endPoint = endPoint;
            _fare.Charge(_transport, this, _card);
        }
    }
}
