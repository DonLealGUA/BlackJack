namespace UtilitiesLib
{
    public class StringConverter
    {
        /*
        * Converts a type String to type int using the int.TryParse
        * returns the value if done correkt
        */
        public static bool ConvertStringToInt(string strNbr, out int result)
        {
            return int.TryParse(strNbr, out result);
        }

        /*
         * Converts a type String to type decimal using the decimal.TryParse
         * returns the value if done correkt
         */
        public static bool ConvertStringToDecimal(string strNbr, out decimal result)
        {
            return decimal.TryParse(strNbr, out result);
        }

        /*
         * Converts a type String to type int using the int.TryParse but also checks if its in a specefik range 
         *  returns the value if done correkt
         */
        public static bool ConvertStringToIntLimit(string strNbr, int lowLimit, int highLimit, out int result)
        {
            if (int.TryParse(strNbr, out result))
            {
                return result >= lowLimit && result <= highLimit;
            }

            return false;
        }

        /*
         * Converts a type String to type decimal using the decimal.TryParse but also checks if its in a specefik range 
         *  returns the value if done correkt
         */
        public static bool ConvertStringToDecimalLimit(string strNbr, decimal lowLimit, decimal highLimit, out decimal result)
        {
            if (decimal.TryParse(strNbr, out result))
            {
                return result >= lowLimit && result <= highLimit;
            }

            return false;
        }
    }
}