namespace Data.Dtos
{
    public class StatsOutputDto<T>
    {
        public T Value { get; set; }
        public DateTime Date { get; set; }

        public StatsOutputDto(T value, DateTime date)
        {
            Value = value;
            Date = date;
        }
    }
}
