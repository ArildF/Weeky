using System;
using System.Collections.Generic;
using System.Concurrency;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using Weeky.Model;

namespace Weeky
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppStateFile file;
            if (e.Args.Length > 0)
            {
                file = AppStateFile.Create(e.Args[0]);
            }
            else
            {
                file =
                    AppStateFile.Create(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                     "Default.weeky"));
            }

            var appState = file.Load();

            var mainViewModel = new MainViewModel(appState);
            var window = new MainWindow {DataContext = mainViewModel};
            window.Show();

            var states = Observable.FromEvent(evt => mainViewModel.Changed += evt,
                                              evt => mainViewModel.Changed -= evt)
                .Select(_ => mainViewModel.State);

            states.ObserveOn(Scheduler.ThreadPool)
                .Throttle(TimeSpan.FromSeconds(5))
                .Subscribe(state => file.Save(state));
        }

    }
}
