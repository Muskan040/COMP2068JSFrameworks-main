/*
 * Name: Karanveer Singh
 * Course: PROG32356 .Net Technologies using C#
 * Date Created: 9th April, 2024
 */
using Assignment2.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Assignment2.ViewModels
{

    public partial class RoomViewModel
    {

        private readonly CrudOperationsInHotelDataSet crud = new CrudOperationsInHotelDataSet();
        public int RoomID { get; set; }

        private TextBox _roomNumber;

        public TextBox RoomNumber
        {
            get { return _roomNumber; }
            set { _roomNumber = value; }
        }

        private TextBox _roomType;

        public TextBox RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }

        private TextBox _capacity;

        public TextBox Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        private TextBox _price;

        public TextBox Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public ObservableCollection<Room> RoomsList { get; set; } = new ObservableCollection<Room>();

        public void LoadData()
        {
            if (RoomsList != null)
            {
                RoomsList.Clear();
                crud.GetAllRooms(RoomsList);
            }
        }

        public void InitializeRoomProperties(TextBox roomNumber, TextBox roomType, TextBox capacity, TextBox price)
        {
            _roomNumber = roomNumber;
            _roomType = roomType;
            _capacity = capacity;
            _price = price;
        }

        public void ClearRoomProperties()
        {
            _roomNumber.Text = string.Empty;
            _roomType.Text = string.Empty;
            _capacity.Text = string.Empty; 
            _price.Text = string.Empty;
        }

        public void SelectRoom(int id)
        {
            RoomID = id;

            var query = from room in RoomsList
                        where room.RoomID == RoomID
                        select room;

            foreach (var room in query)
            {
                _roomNumber.Text = room.RoomNumber;
                _roomType.Text = room.RoomType;
                _capacity.Text = room.Capacity.ToString();
                _price.Text = room.Price.ToString();
            }
        }
        public RoomViewModel()
        {
            LoadData();
            _roomNumber = new TextBox();
            _roomType = new TextBox();
            _capacity = new TextBox();
            _price = new TextBox();
        }


        public void AddRoom()
        {
            var roomNumber = _roomNumber.Text;
            var roomType = _roomType.Text;
            var capacity = _capacity.Text;
            var price = _price.Text;

            crud.InsertRoom(roomNumber, roomType, capacity, price);
            Reload();
        }
        public void EditRoom()
        {
            var roomNumber = _roomNumber.Text;
            var roomType = _roomType.Text;
            var capacity = _capacity.Text;
            var price = _price.Text;

            crud.EditRoom(RoomID, roomNumber, roomType, capacity, price);
            Reload();
        }

        public void DeleteRoom()
        {
            crud.DeleteRoom(RoomID);
            Reload();
        }

        public void Reload()
        {
            ClearRoomProperties();
            LoadData();
        }
    }
}
