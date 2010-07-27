using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weeky.Model
{
    public class AppState
    {
        public Day[] Days
        {
            get
            {
                return _dict.Values.Where(d => d.State != DayState.NotSet).ToArray(); 
            }
            set
            {
                _dict = value.ToDictionary(d => d.Date);
            }
        }

        public string Title { get; set; }

        private Dictionary<DateTime, Day> _dict = new Dictionary<DateTime, Day>();

        public AppState()
        {
        }

        public AppState(Day[] days)
        {
            Days = days;
        }

        public Day GetOrCreateDay(DateTime dateTime)
        {
            Day day;
            if (_dict.TryGetValue(dateTime, out day))
            {
                return day;
            }
            day =  new Day(dateTime, DayState.NotSet);
            SetDay(day);
            return day;
        }

        public void SetDay(Day day)
        {
            _dict[day.Date] = day;
        }
    }
}
