using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        // Вычисление длинны отрезка по координатам (x1, y1) (x2, y2);
        public static double GetDistanceToSide (double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2-x1)*(x2-x1) + (y2-y1)* (y2 - y1));
        }

        // Скалярное произведение векторов;
        public static double scalarVector(double P0x, double P0y, double P1x, double P1y, double Px, double Py)
        {            
            return ((Px - P0x) * (P1x - P0x) + (Py - P0y) * (P1y - P0y));
        }

        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            double AB = GetDistanceToSide(ax, ay, bx, by);
            double AC = GetDistanceToSide(ax, ay, x, y);
            double CB = GetDistanceToSide(x, y, bx, by);

            //Получаем скалярные произведения векторов
            double scalarACAB = scalarVector(ax,ay,bx,by,x,y);
            double scalarBCBA = scalarVector(bx, by,ax,ay,x,y);

            if (AB == 0) return AC;
            else if (scalarACAB >= 0 && scalarBCBA >= 0)
            {
                double p = (AC + CB + AB) / 2.0;
                double s = Math.Sqrt(Math.Abs((p * (p - AC) * (p - CB) * (p - AB))));
                return (2.0 * s) / AB;
            }
            else if (scalarACAB < 0 || scalarBCBA < 0) return Math.Min(AC, CB);
            else return 0;
        }
	}
}

