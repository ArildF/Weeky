using System;
using System.Windows.Input;
using Weeky.Model;

namespace Weeky
{
    public enum DayState
    {
        NotSet,
        Bad,
        Good
    }

    public class DayViewModel : ViewModelBase
    {
        private readonly Day _day;
        private readonly Action _changed;
        private readonly ICommand _toggleStateCommand;

        public DayViewModel(Day day, Action changed)
        {
            _day = day;
            _changed = changed;
            _toggleStateCommand = new DelegateCommand(ToggleState);
        }

        private void ToggleState()
        {
            _day.NextState();
            this.OnPropertyChanged(vm => vm.State);

            _changed();
        }

        public DayState State
        {
            get { return _day.State;  }
        }

        public bool IsToday
        {
            get{ return _day.Date == DateTime.Today; }
        }

        public ICommand ToggleStateCommand
        {
            get { return _toggleStateCommand; }
        }
        public string MainText
        {
            get { return _day.Date.Day.ToString(); } 
        }

        public bool IsHoliday
        {
            get{ return _day.Date.DayOfWeek == DayOfWeek.Sunday;}
        }

        public DateTime Date
        {
            get { return _day.Date; }
        }


    }
}
