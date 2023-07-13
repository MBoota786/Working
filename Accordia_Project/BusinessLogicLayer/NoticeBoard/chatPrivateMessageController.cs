using Accordia_Project.BusinessLogicLayer.Hubs;
using DataAccessLayer.NoticeBoardDAL;
using EntityLayer;
using EntityLayer.clsNoticeBoard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accordia_Project.BusinessLogicLayer.NoticeBoard
{
    
    [Route("api/[controller]")]
    public class chatPrivateMessageController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        privateMessageDAL s = new privateMessageDAL();
        clsResult r = new clsResult();

        public chatPrivateMessageController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        //_____________________ PrivateMessageList __________________________
        [Route("PrivateMessageList")]
        [HttpPost]
        public async Task<clsResult> insertMessage([FromBody] clsPrivateMessage msg)
        {
            try
            {
                List<clsPrivateMessage> list = s.selectAllPrivateMessage(msg.senderId, msg.receiverId, null);
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", list);
                r.Data = new List<object>();
                r.Data.AddRange(list);
                r.message = General.messageModel.insertMessage;
                r.isSuccess = true;
            }
            catch (Exception ex)
            {
                r.isSuccess = false;
                r.error = ex.Message;
            }
            return r;
        }

        //[HttpPost]
        //public async Task<IActionResult> SendMessage(string userId, string message,string ConnectionId)
        //{
        //    try
        //    {
        //        // Save the private chat message in the database
        //        var senderId = HttpContext.User.Identity.Name;
        //        var privateMessage = new clsPrivateMessage
        //        {
        //            SenderId = senderId,
        //            ReceiverId = userId,
        //            Message = message,
        //            Timestamp = DateTime.Now
        //        };

        //        //_dbContext.PrivateChat.Add(privateMessage);
        //        //await _dbContext.SaveChangesAsync();

        //        var messageId = privateMessage.Id;
        //        var timeStamp = privateMessage.Timestamp.ToString("M/d/yyyy h:m:s tt");
        //        var receiverId = privateMessage.ReceiverId;

        //        await _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", senderId, receiverId, messageId, message, timeStamp, false);
        //        await _hubContext.Clients.Client(ConnectionId).SendAsync("ReceiveMessage", senderId, receiverId, messageId, message, timeStamp, true);

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //_____________________________________ User ____________________________________
        #region user
        //[HttpPost]
        //public async Task<IActionResult> SendMessage(string userId, string message)
        //{
        //    try
        //    {
        //        // Save the private chat message in the database
        //        var senderId = HttpContext.User.Identity.Name;
        //        var privateMessage = new PrivateMessage
        //        {
        //            SenderId = senderId,
        //            ReceiverId = userId,
        //            Message = message,
        //            Timestamp = DateTime.Now
        //        };

        //        _dbContext.PrivateChat.Add(privateMessage);
        //        await _dbContext.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeletePrivateChatMessage(int messageId)
        //{
        //    try
        //    {
        //        var userId = HttpContext.User.Identity.Name;
        //        var message = _dbContext.PrivateChat.FirstOrDefault(pm => pm.Id == messageId && pm.SenderId == userId);

        //        if (message != null)
        //        {
        //            _dbContext.PrivateChat.Remove(message);
        //            await _dbContext.SaveChangesAsync();
        //            await Clients.All.SendAsync("MessageDeleted", userId, messageId);
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> SendImage(string userId, byte[] imageBytes)
        //{
        //    try
        //    {
        //        // Save the image in the database
        //        var senderId = HttpContext.User.Identity.Name;
        //        var image = new Image
        //        {
        //            SenderId = senderId,
        //            ReceiverId = userId,
        //            ImageBytes = imageBytes,
        //            Timestamp = DateTime.Now
        //        };

        //        _dbContext.Image.Add(image);
        //        await _dbContext.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> MarkPrivateMessageAsRead(string userId)
        //{
        //    try
        //    {
        //        var senderId = HttpContext.User.Identity.Name;
        //        var messages = _dbContext.PrivateMessage
        //            .Where(pm => pm.SenderId == senderId && pm.ReceiverId == userId && !pm.IsReaded)
        //            .ToList();

        //        foreach (var message in messages)
        //        {
        //            message.IsReaded = true;
        //        }

        //        await _dbContext.SaveChangesAsync();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        #endregion


        //_____________________________________ Group ____________________________________
        #region 
        //[HttpPost]
        //public async Task<IActionResult> SendGroupMessage(int groupId, string message)
        //{
        //    try
        //    {
        //        // Save the group chat message in the database
        //        var senderId = HttpContext.User.Identity.Name;
        //        var groupMessage = new GroupMessage
        //        {
        //            GroupId = groupId,
        //            SenderId = senderId,
        //            Message = message,
        //            Timestamp = DateTime.Now
        //        };

        //        _dbContext.GroupMessage.Add(groupMessage);
        //        await _dbContext.SaveChangesAsync();

        //        // Get the group members
        //        var groupMembers = _dbContext.GroupUser
        //            .Where(gu => gu.GroupId == groupId && gu.UserId != senderId)
        //            .Select(gu => gu.UserId)
        //            .ToList();

        //        var groupMessageId = groupMessage.Id;

        //        if (groupMembers.Count > 0)
        //        {
        //            // Send the message to all group members
        //            foreach (var memberId in groupMembers)
        //            {
        //                await Clients.Users(memberId).SendAsync("ReceiveGroupMessage", groupId, senderId, groupMessageId, message, groupMessage.Timestamp, false);
        //            }
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteGroupMessages(int groupId, int messageId)
        //{
        //    try
        //    {
        //        var userId = HttpContext.User.Identity.Name;
        //        var message = _dbContext.GroupMessage.FirstOrDefault(gm => gm.Id == messageId && gm.GroupId == groupId && gm.SenderId == userId);
        //        if (message != null)
        //        {
        //            _dbContext.GroupMessage.Remove(message);
        //            await _dbContext.SaveChangesAsync();
        //            await Clients.All.SendAsync("GroupMessageDeleted", groupId, messageId);
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> MarkGroupMessageAsRead(int groupId)
        //{
        //    try
        //    {
        //        var userId = HttpContext.User.Identity.Name;
        //        var groupUsers = _dbContext.GroupUser
        //            .Where(gu => gu.GroupId == groupId && gu.UserId == userId)
        //            .ToList();

        //        if (groupUsers.Count > 0)
        //        {
        //            var groupMessageIds = _dbContext.GroupMessage
        //                .Where(gm => gm.GroupId == groupId && !gm.IsReaded)
        //                .Select(gm => gm.Id)
        //                .ToList();

        //            var groupMessages = _dbContext.GroupMessage
        //                .Where(gm => groupMessageIds.Contains(gm.Id))
        //                .ToList();

        //            foreach (var message in groupMessages)
        //            {
        //                message.IsReaded = true;
        //            }

        //            await _dbContext.SaveChangesAsync();

        //            // Get the connection IDs of the group members
        //            List<string> connectionIds = GetGroupConnectionIds(groupId);

        //            if (connectionIds != null && connectionIds.Count > 0)
        //            {
        //                // Send a signal to all group members' clients to update the read status of the messages
        //                await Clients.Clients(connectionIds).SendAsync("MarkAsRead");
        //            }
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
        #endregion

        //_____________________________________  ____________________________________
        //private List<string> GetGroupConnectionIds(int groupId)
        //{
        //    var connectionIds = _dbContext.GroupUser
        //        .Where(gu => gu.GroupId == groupId)
        //        .Select(gu => gu.User.ConnectionId)
        //        .ToList();
        //    return connectionIds;
        //}

    }
}
