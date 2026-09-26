using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery
{
    public partial class Shipment
    {
        public static int TotalShipmentsCreated;

        static Shipment()
        {
            Console.WriteLine("Shipment System Initialized");
        }


        public string TrackingCode { get; set; }
        public string ShipmentType { get; set; }
        public double WeightInKg { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }

        public Shipment(string trackingCode, string shipmentType, double weightInKg,
                         DeliveryAddress deliveryAddress, string initialTrackingStatus)
        {
            TrackingCode = trackingCode;
            ShipmentType = shipmentType;
            WeightInKg = weightInKg;
            DeliveryAddress = deliveryAddress;
            TrackingStatus = initialTrackingStatus; 

            TotalShipmentsCreated++;
        }

        public double EstimatedCost
        {
            get { return WeightInKg * 10; }
        }

        public void PrintShipment()
        {
            Console.WriteLine(
                $"{TrackingCode} | {ShipmentType} | {WeightInKg} KG | {TrackingStatus} | " +
                $"Address: {DeliveryAddress.City} | Estimated Cost: {EstimatedCost}");
        }
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        public Shipment CopyShipment()
        {
            return (Shipment)this.MemberwiseClone();
        }


        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }


        public Shipment DeepCopy()
        {
            Shipment copy = (Shipment)this.MemberwiseClone();
            copy.DeliveryAddress = new DeliveryAddress(this.DeliveryAddress.City);
            return copy;
        }

        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }
    }
}
