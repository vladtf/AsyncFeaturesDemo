using Caliburn.Micro;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncFeaturesDemo.ViewModels
{
    public class MainViewModel : Screen
    {
        #region Private backing fields

        private int _myProperty1;
        private int _myProperty3;
        private int _myProperty4;
        private int _myProperty2; 
        #endregion

        public MainViewModel()
        {
            MyProperty1 = 0;
            MyProperty2 = 0;
            MyProperty3 = 0;
            MyProperty4 = 0;

        }

        #region Public properties
        public int MyProperty1
        {
            get { return _myProperty1; }
            set { Set(ref _myProperty1, value); }
        }

        public int MyProperty2
        {
            get { return _myProperty2; }
            set { Set(ref _myProperty2, value); }
        }

        public int MyProperty3
        {
            get { return _myProperty3; }
            set { Set(ref _myProperty3, value); }
        }

        public int MyProperty4
        {
            get { return _myProperty4; }
            set { Set(ref _myProperty4, value); }
        } 
        #endregion

        public void DoAction()
        {
            Increase1();
            Increase2();
            Increase3();
            Increase4();
        }public async Task DoActionAsync()
        {
            await Task.Run(()=> Increase1());
            await Task.Run(()=> Increase2());
            await Task.Run(()=> Increase3());
            await Task.Run(()=> Increase4());
        }

        public void StartAction()
        {
            var watch = Stopwatch.StartNew();

            DoAction();

            watch.Stop();

            MessageBox.Show("Action finished in " + watch.ElapsedMilliseconds.ToString());
        }
        public async void StartActionAsync()
        {
            var watch = Stopwatch.StartNew();

            await DoActionAsync();

            watch.Stop();

            MessageBox.Show("Action finished in " + watch.ElapsedMilliseconds.ToString());
        }

        public void Restart()
        {
            MyProperty1 = MyProperty2 = MyProperty3 = MyProperty4 = 0;
        }

        #region Actions to do
        public void Increase1()
        {
            while (MyProperty1 < 100)
            {
                Thread.Sleep(100);
                MyProperty1 += 5;
            }
        }
        public void Increase2()
        {
            while (MyProperty2 < 100)
            {
                Thread.Sleep(100);
                MyProperty2 += 5;
            }
        }
        public void Increase3()
        {
            while (MyProperty3 < 100)
            {
                Thread.Sleep(100);
                MyProperty3 += 5;
            }
        }
        public void Increase4()
        {
            while (MyProperty4 < 100)
            {
                Thread.Sleep(100);
                MyProperty4 += 5;
            }
        } 
        #endregion


    }
}