using Business.Utility;

namespace Business.Services
{
    public class BaseService
    {
        public int GetMonthId(object month)
        {
            if (month == null)
            {
                throw new Exception("Invalid month passed.");
            }

            var monthId = 0;
            int.TryParse(month.ToString(), out monthId);
            if (monthId == 0)
            {
                var monthUtility = new MonthUtility();
                monthId = monthUtility.GetMonthId(month.ToString());
            }

            if (monthId > 12 || monthId < 0)
            {
                throw new Exception($"Month {month.ToString()} passed is not correct.");
            }

            return monthId;
        }
    }
}
