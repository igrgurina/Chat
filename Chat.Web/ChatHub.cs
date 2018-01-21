using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Chat.Web
{
    public class ChatHub : Hub
    {
        private IChatRepository _repository;

        public ChatHub(IChatRepository repository)
        {
            _repository = repository;
        }

        public async Task Send(string userId, string message)
        {
            // Suppose you want to store chat messages on the server before sending them
            await _repository.AddAsync(userId, message);

            var username = await _repository.GetUsernameAsync(userId);

            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(username, message);
        }
    }

    public interface IChatRepository
    {
        Task<string> GetUsernameAsync(string userId);

        Task AddAsync(string userId, string message);
        // other methods not shown.
    }

}