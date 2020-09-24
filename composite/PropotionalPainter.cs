using System;

namespace composite
{
    class PropotionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }
        public double PricePerHour { get; set; }
        public bool IsAvailable => true;

        public double EstimateCompensation(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * PricePerHour;

        public TimeSpan EstimateTimeToPaint(double sqMeters) => 
            TimeSpan.FromHours(TimePerSqMeter.TotalHours * sqMeters);
    }
}