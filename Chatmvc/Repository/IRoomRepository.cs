using Chatmvc.Models;
using System.Collections.Generic;

namespace Chatmvc.Repository
{
    public interface IRoomRepository
    {
        void add(Room user);

        List<Room> get();

        List<Room> getById(string nickName);
    }
}