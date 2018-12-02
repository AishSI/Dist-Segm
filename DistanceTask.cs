using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Вычисление длинны отрезка по координатам (x1, y1) (x2, y2);
		public static double GetDistanceToSide(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
		}

		// Скалярное произведение векторов;
		public static double GetScalarVector(double p0x, double p0y, double p1x, double p1y, double px, double py)
		{
			return (px - p0x) * (p1x - p0x) + (py - p0y) * (p1y - p0y);
		}

		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			double ab = GetDistanceToSide(ax, ay, bx, by);
			double ac = GetDistanceToSide(ax, ay, x, y);
			double cb = GetDistanceToSide(x, y, bx, by);

			//Получаем скалярные произведения векторов
			double scalarACAB = GetScalarVector(ax, ay, bx, by, x, y);
			double scalarBCBA = GetScalarVector(bx, by, ax, ay, x, y);

			if (ab == 0) return ac;
			if (scalarACAB >= 0 && scalarBCBA >= 0)
			{
				double p = (ac + cb + ab) / 2.0;
				double s = Math.Sqrt(Math.Abs((p * (p - ac) * (p - cb) * (p - ab))));
				return (2.0 * s) / ab;
			}
			if (scalarACAB < 0 || scalarBCBA < 0) return Math.Min(ac, cb);
			return 0;
		}
	}
}