using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.Commands;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //public string SomeText
        //{
        //    get { return (string)GetValue(SomeTextProperty); }
        //    set { SetValue(SomeTextProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SomeText.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SomeTextProperty =
        //    DependencyProperty.Register("SomeText", typeof(string), typeof(MainWindow));

        private string someText;

        public string SomeText
        {
            get { return someText; }
            set { someText = value; OnPropertyChanged(); }
        }


        public MainWindow()
        {
            InitializeComponent();
            SomeText = "Salam";
            this.DataContext = this;

            //MessageCommand = new MessageCommand(() =>
            //{
            //    MessageBox.Show("This is your message");
            //});




            //RelayCommand


            //MessageCommand = new RelayCommand((obj) =>
            //{
            //    MessageBox.Show($"This is text {SomeText}");
            //});

            MessageCommand = new RelayCommand((obj) =>
            {
                MessageBox.Show($"This is text {SomeText}");
            }, (param) =>
            {
                return SomeText.Length > 10;
            });

            SendCommand = new RelayCommand((obj) =>
            {
                var color = obj as Brush;
                MessageBox.Show($"This is text {SomeText} color {color}");
            }, (param) =>
            {
                return true;
            });
        }

        // public MessageCommand MessageCommand { get; set; }
        public RelayCommand MessageCommand { get; set; }
        public RelayCommand SendCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private void Help_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            try
            {
                if (SomeText.Length < 10)
                {
                    e.CanExecute = false;
                }
                else
                {
                    e.CanExecute=true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Process.Start("calc.exe");
        }
    }
}
