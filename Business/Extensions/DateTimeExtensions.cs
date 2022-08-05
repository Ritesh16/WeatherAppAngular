namespace Business.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static string ToTime(this long input)
        {

            var dateTime = epoch.AddSeconds(input);
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, easternZone);

            return easternTime.ToString("HH:mm");
        }
    }
}
