using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Weeky.Model;

namespace Weeky
{
    public class MainViewModel : ViewModelBase
    {
        private readonly AppState _state;
        private readonly ObservableCollection<DayViewModel> _days;
        private DayViewModel _currentlyInView;

        public event EventHandler Changed;

        protected void InvokeChanged(EventArgs e)
        {
            EventHandler handler = Changed;
            if (handler != null) handler(this, e);
        }

        public MainViewModel(AppState state)
        {
            _state = state;
            _days = new ObservableCollection<DayViewModel>();

            var startDate = DateTime.Today.AddDays(-35);
            while (startDate.DayOfWeek != DayOfWeek.Monday)
            {
                startDate = startDate.AddDays(1);
            }

            Enumerable.Range((startDate - DateTime.Today).Days, 62)
                .Select(i => DateTime.Today.AddDays(i))
                .Select(_state.GetOrCreateDay)
                .Select(d => new DayViewModel(d, () => InvokeChanged(EventArgs.Empty)))
                .ForEach(_days.Add);

            GoToToday();
        }

        public MainViewModel() : this(new AppState())
        {}


        private void GoToToday()
        {
            CurrentlyInView = _days.Where(d => d.Date == DateTime.Today).Single();
        }

        public DayViewModel CurrentlyInView
        {
            get {
                return _currentlyInView;
            }
            set {
                if (_currentlyInView != value)
                {
                    _currentlyInView = value;
                    this.OnPropertyChanged(vm => vm.CurrentlyInView);
                }
            }
        }

        public string Title
        {
            get { return _state.Title; }
            set
            {
                if (_state.Title != value)
                {
                    _state.Title = value;
                    this.OnPropertyChanged(vm => vm.Title);
                }
            }
        }
        public ObservableCollection<DayViewModel> Days
        {
            get { return _days; }
        }

        public AppState State
        {
            get { return _state; }
        }
    }
}
