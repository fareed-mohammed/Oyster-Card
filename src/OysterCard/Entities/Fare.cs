using System;

namespace OysterCard
{
    public class Fare
    {
        public const float ZONE_ONE_FARE = 2.50f;
        public const float ANY_ZONE_OUTSIDE_ZONE_ONE_FARE = 2.00f;
        public const float TWO_ZONES_INC_ZONE_ONE_FARE = 3.00f;
        public const float TWO_ZONES_EXC_ZONE_ONE_FARE = 2.25f;
        public const float THREE_ZONES_FAIR = 3.20f;
        public const float BUS_FARE = 1.80f;
        public const float BASIC_TUBE_FARE = 3.20f;

        public void Validate(Transport transport, Card card)
        {
            if (transport.Equals(Transport.BUS))
                card.Validate(BUS_FARE);

            if (transport.Equals(Transport.TUBE))
                card.Validate(BASIC_TUBE_FARE);
        }

        public void ChargeMax(Transport transport, Card card)
        {
            if (transport.Equals(Transport.BUS))
                card.Out(BUS_FARE);

            if (transport.Equals(Transport.TUBE))
                card.Out(BASIC_TUBE_FARE);
        }

        public void Charge(Transport transport, Journey journey, Card card)
        {
            if (transport.Equals(Transport.TUBE))
            {
                int count = CountZones(journey);

                if (IsOneZones(count) && IsZoneTwo(journey))
                {
                    card.In(BASIC_TUBE_FARE - ANY_ZONE_OUTSIDE_ZONE_ONE_FARE);
                }
                else if (HaveZoneOne(journey) && IsOneZones(count))
                {
                    card.In(BASIC_TUBE_FARE - ZONE_ONE_FARE);
                }
                else if (!HaveZoneOne(journey) && IsOneZones(count))
                {
                    card.In(BASIC_TUBE_FARE - ANY_ZONE_OUTSIDE_ZONE_ONE_FARE);
                }
                else if (HaveZoneOne(journey) && IsTwoZones(count))
                {
                    card.In(BASIC_TUBE_FARE - TWO_ZONES_INC_ZONE_ONE_FARE);
                }
                else if (!HaveZoneOne(journey) && IsTwoZones(count))
                {
                    card.In(BASIC_TUBE_FARE - TWO_ZONES_EXC_ZONE_ONE_FARE);
                }
                else if (IsThreeZones(count))
                {
                    card.In(BASIC_TUBE_FARE - THREE_ZONES_FAIR);
                }            
            }
            else if (transport.Equals(Transport.BUS))
            {
                card.In(0f);
            }
        }   

        private bool IsZoneTwo(Journey journey)
        {
            return journey.GetEndPoint().GetZone().Contains("2") && journey.GetStartPoint().GetZone().Contains("2");
        }

        private int CountZones(Journey journey)
        {
            var zonesStart = journey.GetStartPoint().GetZone().Split(',');
            var zonesEnd = journey.GetEndPoint().GetZone().Split(',');

            int x = 10;

            for (int i = 0; i < zonesStart.Length; i++)
            {
                for (int j = 0; j < zonesEnd.Length; j++)
                {
                    int z = int.Parse(zonesStart[i]);
                    int y = int.Parse(zonesEnd[j]);
                    z = Math.Abs(z - y);
                    if (z < x)
                        x = z;
                }
            }

            return Math.Abs(x);
        }

        private bool IsThreeZones(int count)
        {
            return count == 2;
        }

        private bool IsTwoZones(int count)
        {
            return count == 1;
        }

        private bool IsOneZones(int count)
        {
            return count == 0;
        }

        private bool HaveZoneOne(Journey journey)
        {
            return journey.GetEndPoint().GetZone().Contains("1") || journey.GetStartPoint().GetZone().Contains("1");
        }
    }
}
