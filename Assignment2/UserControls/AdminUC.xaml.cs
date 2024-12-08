using Assignment2.Models;
using Assignment2.ViewModels;
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
using System.Windows.Shapes;

namespace Assignment2.UserControls
{
    /// <summary>
    /// Interaction logic for AdminUC.xaml
    /// </summary>
    public partial class AdminUC : UserControl
    {
        public AdminUC()
        {
            InitializeComponent();
            ViewModel.InitializeRoomProperties(tbRoomNumber, tbRoomType, tbRoomCapacity, tbRoomPrice);
            this.DataContext = ViewModel;
        }
        RoomViewModel ViewModel = new RoomViewModel();
        private void RoomItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Room selectedRoom = (Room)button.DataContext;
            int RoomId = selectedRoom.RoomID;
            ViewModel.RoomID = RoomId;
            ViewModel.SelectRoom(RoomId);
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddRoom();
        }

        private void RefreshRooms_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Reload();
        }

        private void EditRoom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.EditRoom();
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteRoom();
        }
    }
}
