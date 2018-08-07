using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime resultDate = startDate;
            dayCount -= 1;

            if (weekEnds != null && dayCount > 0)
            {
                foreach (WeekEnd weekEnd in weekEnds)
                {
                    int daysToWeekEndStart = (weekEnd.StartDate - resultDate).Days - 1;

                    if (daysToWeekEndStart > 0 || daysToWeekEndStart == 0)
                    {
                        if (dayCount - daysToWeekEndStart >= 0)
                        {
                            resultDate = resultDate.AddDays(daysToWeekEndStart);
                            dayCount -= daysToWeekEndStart;
                        }
                        else
                        {
                            resultDate = resultDate.AddDays(dayCount);
                            dayCount = 0;
                        }

                        if (dayCount > 0)
                        {
                            int daysInWeekEnd = (weekEnd.EndDate - weekEnd.StartDate).Days + 1;
                            resultDate = resultDate.AddDays(daysInWeekEnd);
                        }
                    }
                }
            }

            if (dayCount > 0)
            {
                resultDate = resultDate.AddDays(dayCount);
            }

            return resultDate;
        }
    }
}
