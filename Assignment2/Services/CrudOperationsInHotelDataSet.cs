/*
 * Name: Karanveer Singh
 * Course: PROG32356 .Net Technologies using C#
 * Date Created: 9th April, 2024
 */
using Assignment2.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment2
{
    public class CrudOperationsInHotelDataSet
    {
        private HotelDataSetTableAdapters.RoomsTableAdapter _adapter;
        private HotelDataSet.RoomsDataTable _tbRooms;
        public CrudOperationsInHotelDataSet()
        {
            _adapter = new HotelDataSetTableAdapters.RoomsTableAdapter();
            _tbRooms = new HotelDataSet.RoomsDataTable();
        }
        public void GetAllRooms(ObservableCollection<Room> rooms)
        {
            try
            {
                _tbRooms = _adapter.GetRoomData();

                if (_tbRooms != null)
                {
                    foreach (var row in _tbRooms)
                    {
                        var room = new Room
                        {
                            RoomID = row.RoomID,
                            RoomNumber = row.RoomNumber,
                            Capacity = row.Capacity,
                            Price = row.Price,
                            RoomType = row.RoomType
                        };
                        rooms.Add(room);
                    }
                }
            }
            catch (Exception ex)
            {
                Task.FromException(ex);
                throw;
            }
        }

        public void InsertRoom(string roomNumber, string roomType, string capacity, string price)
        {
            if (IsAnyTextBoxEmpty(roomNumber, roomType, capacity, price))
            {
                MessageBox.Show("Make sure to fill all inputs fields!"); return;
            }
            try
            {
                _adapter.Insert(roomNumber, roomType, int.Parse(capacity), decimal.Parse(price));
                MessageBox.Show($"Room of type {roomType} has been added successfully!");
            }
            catch (Exception ex)
            {
                Task.FromException(ex);
                throw;
            }
        }

        public void EditRoom(int id, string roomNumber, string roomType, string capacity, string price)
        {
            if (IsAnyTextBoxEmpty(roomNumber, roomType, capacity, price))
            {
                MessageBox.Show("Make sure to fill all inputs fields!"); return;
            }
            try
            {
                var row = _tbRooms.FindByRoomID(id);
                if (row != null)
                {
                    row.RoomNumber = roomNumber;
                    row.RoomType = roomType;
                    row.Capacity = int.Parse(capacity);
                    row.Price = decimal.Parse(price);
                    _adapter.Update(_tbRooms);
                    MessageBox.Show($"Room of type {roomType} has been updated successfully!");
                }
            }
            catch (Exception ex)
            {
                Task.FromException(ex);
                throw;
            }
        }
        public void DeleteRoom(int id)
        {
            if (id <= 0)
            {
                MessageBox.Show("Select a room to delete!");
                return;
            }
            try
            {
                var row = _tbRooms.FindByRoomID(id);
                if (row != null)
                {
                    if (!IsAnyTextBoxEmpty(row.RoomNumber, row.RoomType, row.Capacity.ToString(), row.Price.ToString()))
                    {
                        _adapter.Delete(id, row.Capacity, row.Price);
                        MessageBox.Show($"Room of type {row.RoomType} has been updated successfully!");

                    }
                }
            }
            catch (Exception ex)
            {
                Task.FromException(ex);
                throw;
            }
        }
        public static bool IsAnyTextBoxEmpty(string roomNumber, string roomType, string capacity, string price)
        {
            var flag = false;
            if (roomNumber == "") flag = true;
            if (roomType == "") flag = true;
            if (capacity == "") flag = true;
            if (price == "") flag = true;
            return flag;
        }
    }
}
