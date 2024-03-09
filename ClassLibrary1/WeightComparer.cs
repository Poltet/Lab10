using System;
using System.Collections;

namespace ClassLibrary1
{
    public class WeightComparer: IComparer
    {
        public int Compare(object x, object y)
        {
            CelestialBody body1 = x as CelestialBody;
            CelestialBody body2 = y as CelestialBody;
            if (body1.Weight < body2.Weight) 
                return -1;
            else
                if (body1.Weight == body2.Weight)
                    return 0;
            else 
                return 1;
        }
    }
}
