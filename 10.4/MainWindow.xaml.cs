using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Configuration;

namespace _10._4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<statuses> Current;
        List<statuses> ActiveNotes;
        List<statuses> CompleteNotes;
        private List<string> SelectedItems { get; set; } = new List<string>();
        public MainWindow()
        {
            
        InitializeComponent();
            Current = new List<statuses>() { new statuses("dsdlkd", Status.Active) };
            Update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Сompleted_tasks.SelectedItems == null) return;
            foreach (var item in Сompleted_tasks.SelectedItems)
            {
                Current.Remove((statuses)item);
            }
            Update();
        }

        private void Current_tasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Current_tasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Current_tasks.SelectedItem == null) return;
            var a = Current.FindIndex(u => u == Current_tasks.SelectedItem);
            Current[a].status = Status.completed;
            Update();
        }
        public void Update()
        {
            ActiveNotes = Current.Where(u => u.status == Status.Active).ToList();
            CompleteNotes = Current.Where(u => u.status == Status.completed).ToList();
            Current_tasks.ItemsSource = ActiveNotes;
            Сompleted_tasks.ItemsSource = CompleteNotes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Current_TextBox.Text == "" || Current_TextBox.Text == null) return;
            Current.Add(new statuses(Current_TextBox.Text, Status.Active));
            Update();
        }
    }
}
