using System;
using System.Collections.Generic;
using System.Linq;

namespace sequences
{
    class Program
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum(painter => painter.EstimateCompensation(sqMeters));
        }

        private static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(painter => painter.IsAvailable)
                .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
