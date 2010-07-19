using System;

namespace Weeky.Model
{
    public class Day
    {
        public Day(DateTime date, DayState state)
        {
            Date = date;
            State = state;
        }

        public Day()
        {
            Date = DateTime.Today;
        }

        public DateTime Date { get; set; }

        public DayState State { get; set; }

        public void NextState()
        {
            State = State + 1;
            if (State > DayState.Good)
            {
                State = DayState.NotSet;
            }
        }
    }
}