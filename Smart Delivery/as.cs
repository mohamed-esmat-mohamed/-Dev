using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Delivery
{
    public partial class Shipment
    {
        public string TrackingStatus { get; private set; }

        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;
            OnTrackingStatusChanged(newStatus);
        }
        partial void OnTrackingStatusChanged(string newStatus);
    }
}
