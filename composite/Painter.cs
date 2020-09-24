using System;

namespace composite
{
    public interface IPainter
    {
        double EstimateCompensation(double sqMeters);
        TimeSpan EstimateTimeToPaint(double sqMeters);
        
        bool IsAvailable { get; }
    }   
}