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
        privateMessageDAL privateMsg = new privateMessageDAL();
        clsResult r = new clsResult();

        public chatPrivateMessageController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        //_____________________ Select All Messages ____________________________
        [HttpGet]
        public async Task<clsResult> selectAllPrivateMessages(string dbName)
        {
            try
            {
                var list = privateMsg.SelectAllPrivateMessage(null);

                r.Data = new List<object>();
                r.Data.AddRange(list);

                r.isSuccess = true;
            }
            catch (Exception ex)
            {
                r.isSuccess = false;
                r.error = ex.Message;
            }
            return r;
        }

        //_____________________ Select Private of U,S Messages ____________________________
        [Route("selectAllPrivateMessagesBySendRece")]
        [HttpGet]
        public async Task<clsResult> selectAllPrivateMessagesBySendRece(int senderId , int receverId , string dbName)
        {
            try
            {
                var list = privateMsg.SelectAllPrivateMessageBySenderRecever(senderId,receverId,null);

                r.Data = new List<object>();
                r.Data.AddRange(list);

                r.isSuccess = true;
            }
            catch (Exception ex)
            {
                r.isSuccess = false;
                r.error = ex.Message;
            }
            return r;
        }


        //_____________________ PrivateMessageList __________________________
        [Route("PrivateMessageList")]
        [HttpPost]
        public async Task<clsResult> insertMessage([FromBody] clsPrivateMessage msg)
        {
            try
            {
                var id = privateMsg.InsertPrivateMessage(msg);
                r.id = id;
                msg.id = id;
                await _hubContext.Clients.All.SendAsync("ReceiveMessage",msg);

                var list = privateMsg.SelectPrivateMessageById(r.id,null);
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

    }
}
