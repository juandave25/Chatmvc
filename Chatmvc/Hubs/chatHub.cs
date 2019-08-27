using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using Chatmvc.Models;
using System.Linq;
using System.Threading.Tasks;
using Chatmvc.Repository;

namespace Chatmvc.Hubs
{
    public class chatHub : Hub , IChatHub
    {
        private IUserRepository UserRepository;
        private IRoomRepository roomRepository;

        public chatHub(IUserRepository _UserRepository, IRoomRepository _roomRepository)
        {
            UserRepository = _UserRepository;
            roomRepository = _roomRepository;
        }

        public void NotifyToAllClients()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<chatHub>();

            // the update client method will update the connected client about any recent changes in the server data
            context.Clients.All.updatedClients();
        }

        public void JoinToRoom(string RoomName)
        {
            Groups.Add(Context.ConnectionId, RoomName);
            Room room = new Room()
            {
                Id = Context.ConnectionId,
                Name = RoomName,
                Enabled = true
            };

            if (!getRoomById(room.Name))
            {
                Clients.All.alertify(room.Name);
            }
            else
            {
                AddNewRoom(room);
                List<Room> rooms = GetRooms();
                Clients.All.updateRooms(rooms.Count(), rooms.Select(u => u.Name));
                NotifyToAllClients();
            }

        }


        public void Connect(string userName)
        {
            User user = new User()
            {
                nickname = userName,
                id = Context.ConnectionId,
                enabled = true
            };

            if (!getNickNameById(user.nickname))
            {
                Clients.All.alertify(user.nickname);
            }
            else
            {
                AddNewUser(user);
                List<User> users = GetUsers();
                Clients.All.updateUsers(users.Count(), users.Select(u => u.nickname));
                if (GetRooms().Count == 0)
                {
                    JoinToRoom("Grupo 1");
                }
                List<Room> rooms = GetRooms();
                Clients.All.updateRooms(rooms.Count(), rooms.Select(u => u.Name));

            }
        }

        public void Send(string message)
        {
            List<User> users = GetUsers();
            var sender = users.First(u => u.id.Equals(Context.ConnectionId));
            Clients.All.broadcastMessage(sender.nickname, message);
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            List<User> users = GetUsers();
            var disconnectedUser = users.FirstOrDefault(c => c.id.Equals(Context.ConnectionId));
            users.Remove(disconnectedUser);
            NotifyToAllClients();
            return base.OnDisconnected(stopCalled);
        }


        #region Database Methods
        //users
        private void AddNewUser(User user)
        {
                UserRepository.add(user);
                NotifyToAllClients();
        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users = UserRepository.get();
            return users;
        }

        private bool getNickNameById(string nickname)
        {
            if (UserRepository.getById(nickname).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //rooms
        private void AddNewRoom(Room room)
        {
            roomRepository.add(room);
            NotifyToAllClients();
        }

        private List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();
            rooms = roomRepository.get();
            return rooms;
        }

        private bool getRoomById(string name)
        {
            if (roomRepository.getById(name).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion

    }
}