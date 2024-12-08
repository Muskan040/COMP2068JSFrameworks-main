/*
 * Name: Karanveer Singh
 * Course: PROG32356 .Net Technologies using C#
 * Date Created: 9th April, 2024
 */
using Assignment2.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Private/Public Members

        private readonly CrudOperationsInHotelDataSet crud = new CrudOperationsInHotelDataSet();
        public ObservableCollection<Room> RoomList { get; set; } = new ObservableCollection<Room>();
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Windows.Source = new Uri("/UserControls/HomeUC.xaml", UriKind.Relative);
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.Source = new Uri("/UserControls/HomeUC.xaml", UriKind.Relative);
        }

        private void RoomBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.Source = new Uri("/UserControls/RoomUC.xaml", UriKind.Relative);
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.Source = new Uri("/UserControls/AdminUC.xaml", UriKind.Relative);
        }
    }
}
