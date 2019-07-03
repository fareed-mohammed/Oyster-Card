using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OysterCard.Tests
{
    [TestClass]
    public class FareTests
    {
        [TestMethod]
        [ExpectedException(typeof(FareException), "You don't have enough balance!")]
        public void TestValidadeBusException()
        {
            Card card = new Card(Fare.BUS_FARE - 1f);
            Fare fare = new Fare();
            fare.Validate(Transport.BUS, card);
        }

        [TestMethod]
        [ExpectedException(typeof(FareException), "You don't have enough balance!")]
        public void TestValidateTubeFareException()
        {

            Card card = new Card(Fare.BASIC_TUBE_FARE - 1f);
            Fare fare = new Fare();
            fare.Validate(Transport.TUBE, card);
        }

        [TestMethod]
        public void TestChargeMaxTube()
        {
            Card card = new Card(Fare.BASIC_TUBE_FARE);
            Fare fare = new Fare();
            fare.ChargeMax(Transport.TUBE, card);
            Assert.AreEqual(0f, card.GetBalance());
        }

        [TestMethod]
        public void TestChargeMaxBus()
        {
            Card card = new Card(Fare.BUS_FARE);
            Fare fare = new Fare();
            fare.ChargeMax(Transport.BUS, card);
            Assert.AreEqual(0f, card.GetBalance());
        }

        [TestMethod]
        public void TestChargeBus()
        {
            Card card = new Card(Fare.BUS_FARE);
            Fare fare = new Fare();
            Journey jorneyBusEarlToChelsea = new Journey(fare);
            jorneyBusEarlToChelsea.SetStartPoint(Transport.BUS, null, card);
            jorneyBusEarlToChelsea.SetEndPoint(null);
            fare.Charge(Transport.BUS, jorneyBusEarlToChelsea, card);
            Assert.AreEqual(0f, card.GetBalance());
        }

        [TestMethod]
        public void TestChargeTubeZoneOne()
        {
            Card card = new Card(Fare.BASIC_TUBE_FARE);
            Fare fare = new Fare();
            Journey jorneyBusEarlToChelsea = new Journey(fare);
            jorneyBusEarlToChelsea.SetStartPoint(Transport.TUBE, new StationZone(Station.HOLBORN), card);
            jorneyBusEarlToChelsea.SetEndPoint(new StationZone(Station.EARLS_COURT));
            Assert.AreEqual(Fare.BASIC_TUBE_FARE - Fare.ZONE_ONE_FARE, card.GetBalance());
        }

        [TestMethod]
        public void TestChargeTubeAnyZoneOutSideZoneOne()
        {
            Card card = new Card(Fare.BASIC_TUBE_FARE);
            Fare fare = new Fare();
            Journey jorneyBusEarlToChelsea = new Journey(fare);
            jorneyBusEarlToChelsea.SetStartPoint(Transport.TUBE, new StationZone(Station.HAMMERSMITH), card);
            jorneyBusEarlToChelsea.SetEndPoint(new StationZone(Station.EARLS_COURT));
            Assert.AreEqual(Fare.BASIC_TUBE_FARE - Fare.ANY_ZONE_OUTSIDE_ZONE_ONE_FARE, card.GetBalance());
        }

        [TestMethod]
        public void TestChargeTubeTwoInZoneOne()
        {
            Card card = new Card(Fare.BASIC_TUBE_FARE);
            Fare fare = new Fare();
            Journey jorneyBusEarlToChelsea = new Journey(fare);
            jorneyBusEarlToChelsea.SetStartPoint(Transport.TUBE, new StationZone(Station.HAMMERSMITH), card);
            jorneyBusEarlToChelsea.SetEndPoint(new StationZone(Station.HOLBORN));
            Assert.AreEqual(Fare.BASIC_TUBE_FARE - Fare.TWO_ZONES_INC_ZONE_ONE_FARE, card.GetBalance());
        }

        [TestMethod]
        public void TestChargeTubeTwoExcludingZoneOne()
        {
            Card card = new Card(Fare.BASIC_TUBE_FARE);
            Fare fare = new Fare();
            Journey jorneyBusEarlToChelsea = new Journey(fare);
            jorneyBusEarlToChelsea.SetStartPoint(Transport.TUBE, new StationZone(Station.HAMMERSMITH), card);
            jorneyBusEarlToChelsea.SetEndPoint(new StationZone(Station.WIMBLEDON));
            Assert.AreEqual(Fare.BASIC_TUBE_FARE - Fare.TWO_ZONES_EXC_ZONE_ONE_FARE, card.GetBalance());
        }

        [TestMethod]
        public void TestChargeTubeThreeZones()
        {
            Card card = new Card(Fare.BASIC_TUBE_FARE);
            Fare fare = new Fare();
            Journey jorneyBusEarlToChelsea = new Journey(fare);
            jorneyBusEarlToChelsea.SetStartPoint(Transport.TUBE, new StationZone(Station.HOLBORN), card);
            jorneyBusEarlToChelsea.SetEndPoint(new StationZone(Station.WIMBLEDON));
            Assert.AreEqual(Fare.BASIC_TUBE_FARE - Fare.THREE_ZONES_FAIR, card.GetBalance());
        }

        [TestMethod]
        public void Test1()
        {
            Card card = new Card(Fare.BASIC_TUBE_FARE);
            Fare fare = new Fare();
            Journey journeyBusEarlToChelsea = new Journey(fare);
            journeyBusEarlToChelsea.SetStartPoint(Transport.TUBE, new StationZone(Station.HOLBORN), card);
            journeyBusEarlToChelsea.SetEndPoint(new StationZone(Station.WIMBLEDON));
            Assert.AreEqual(Fare.BASIC_TUBE_FARE - Fare.THREE_ZONES_FAIR, card.GetBalance());
        }
    }
}
