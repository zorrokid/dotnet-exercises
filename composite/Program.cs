using System;

namespace composite
{
    class Program
    {
        private static IPainter FindCheapestPainter(double sqMeters, Painters painters) =>
            painters.GetAvailable().GetCheapestOne(sqMeters);

        private static IPainter FindFastestPainter(double sqMeters, Painters painters) =>
            painters.GetAvailable().GetFastestOne(sqMeters);
        private static IPainter WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
        {
            double velocitiesSum =  painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
                .Sum();

            TimeSpan time = 
                TimeSpan.FromHours(1 / velocitiesSum);

            double cost = painters
                .Where(painter => painter.IsAvailable)
                .Select(painter => 
                    painter.EstimateCompensation(sqMeters) / 
                        painter.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                .Sum();

            return new PropotionalPainter
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                PricePerHour = cost / time.TotalHours
            };

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
