namespace Business.Utility
{
    public class MonthUtility
    {
        public int GetMonthId(string month)
        {
            if (string.IsNullOrEmpty(month))
            {
                return 0;
            }

            month = month.Trim().ToLower();

            switch (month)
            {
                case "0":
                    return 0;

                case "january":
                        return 1;

                case "jan":
                    return 1;

                case "february":
                    return 2;

                case "feb":
                    return 2;

                case "march":
                    return 3;

                case "mar":
                    return 3;

                case "april":
                    return 4;

                case "apr":
                    return 4;

                case "may":
                    return 5;

                case "june":
                    return 6;

                case "july":
                    return 7;

                case "august":
                    return 8;

                case "aug":
                    return 8;

                case "september":
                    return 9;

                case "sep":
                    return 9;

                case "october":
                    return 10;

                case "oct":
                    return 10;

                case "november":
                    return 11;

                case "nov":
                    return 11;

                case "december":
                    return 12;

                case "dec":
                    return 12;

                default:
                    return -1;
            }
        }
    }
}
