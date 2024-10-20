namespace MetricSystem
{
    public static class Conversion
    {
        public static decimal InchesToCentimeters(decimal number)
        {
            return number * 2.54M;
        }

        public static decimal CentimetersToInches(decimal number)
        {
            return number * 0.393701M;
        }

        public static decimal FeetToMeters(decimal number)
        {
            return number * 0.3048M;
        }

        public static decimal MetersToFeet(decimal number)
        {
            return number * 3.2808M;
        }
    }

    namespace SquaredValues
    {
        public static class Areas
        {
            public static decimal SquaredInchesToCentimeters(decimal number)
            {
                return number * 6.4516M;
            }

            public static decimal SquaredCentimetersToInches(decimal number)
            {
                return number * .155M;
            }

            public static decimal AcreToHectare(decimal number)
            {
                return number * .4047M;
            }
        }

        namespace CubedValues
        {
            public static class Volumes
            {
                public static decimal LitreToGallons(decimal number)
                {
                    return number * .2642M;
                }
            }
        }
    }
}