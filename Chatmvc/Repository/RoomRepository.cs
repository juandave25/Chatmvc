using Chatmvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace Chatmvc.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public void add(Room room)
        {
            using (var context = new Context())
            {
                context.Room.Add(room);
                context.SaveChanges();
            }
        }

        public List<Room> get()
        {
            List<Room> rooms = new List<Room>();
            using (var context = new Context())
            {
                rooms = context.Room.ToList();
            }
            return rooms;
        }

        public List<Room> getById(string name)
        {
            List<Room> rooms = new List<Room>();
            using (var context = new Context())
            {
                rooms = context.Room.Where(c => c.Name == name && c.Enabled == true).ToList();
            }
            return rooms;
        }
    }
}