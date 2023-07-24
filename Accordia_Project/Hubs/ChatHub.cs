using DataAccessLayer;
using DataAccessLayer.NoticeBoardDAL;
using EntityLayer.clsNoticeBoard;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accordia_Project.BusinessLogicLayer.Hubs
{
    public class ChatHub:Hub
    {

        #region connect_Disconnect_Checking_SignalR
        public override async Task OnConnectedAsync()
        {
            var userName = Context.User.Identity.Name;

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userName = Context.User.Identity.Name;
            await base.OnDisconnectedAsync(exception);
        }
        #endregion


        private readonly privateMessageDAL _privateMessageDAL = new privateMessageDAL();

        //_______________ 1. private Message _____________
        #region Private_Message
        //___________ Insert _________________
        public async Task SendMessage(clsPrivateMessage msg)
        {
            await Clients.All.SendAsync("ReceiveMessage", msg);
        }

        //___________ get _________________
        //public async Task getPrivateMessage(int receverId, int senderId)
        //{
        //    _privateMessageDAL.selectAllPrivateMessage(senderId, receverId,null);
        //    await Clients.All.SendAsync("getAllMessage");
        //}

        //___________ get All private Messages _________________
        //public async Task<List<clsPrivateMessage>> GetPrivateMessages(int receiverId, int senderId)
        //{
        //    List<clsPrivateMessage> messages = _privateMessageDAL.selectAllPrivateMessage(senderId, receiverId, null);
        //    return messages;
        //}
        #endregion

        //___________ 2. group Message _____________
        #region Send_GroupMessage

        #endregion

        //___________ 3. file + Message _____________
        #region File
        public async Task sendFileMessage(int receverId, int senderId)
        {
            //s.InsertPrivateMessage();
            await Clients.All.SendAsync("ReceiveOne");
            
        }
        #endregion


        
    }
}
