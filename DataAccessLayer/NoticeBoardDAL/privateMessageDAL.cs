using EntityLayer.clsNoticeBoard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NoticeBoardDAL
{
    public class privateMessageDAL: SQLDataAccess
    {
        //____________ Insert Private Message _____________
        public int InsertPrivateMessage(clsPrivateMessage obj)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@senderId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.senderId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@receiverId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.receiverId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@messageText", SqlDbType.NVarChar,1000, ParameterDirection.Input, (object)obj.messageText ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationReviewId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationReviewId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isReceiver", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.isReceiver ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@isSender", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.isSender ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reminder", SqlDbType.DateTime, 4, ParameterDirection.Input, (object)obj.reminder ?? DBNull.Value);

                Id = ExecuteInsertCommandReturnId(comm, "spInsertPrivateMessage", "EvolveMain");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }


        //____________ Select all Message _____________
        public List<clsPrivateMessage> SelectAllPrivateMessage(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllPrivateMessage");
                List<clsPrivateMessage> activeList = new List<clsPrivateMessage>();
                TExecuteReaderCmd<clsPrivateMessage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPrivateMessage>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsPrivateMessage>();
        }


        //____________ Select all private Message _____________
        public List<clsPrivateMessage> SelectAllPrivateMessageBySenderRecever(int senderId , int receverId , string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectPrivateMessage");
                comand.Parameters.AddWithValue("@currentUserId", senderId);
                comand.Parameters.AddWithValue("@receiverId", receverId);
                List<clsPrivateMessage> activeList = new List<clsPrivateMessage>();
                TExecuteReaderCmd<clsPrivateMessage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPrivateMessage>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsPrivateMessage>();
        }


        //____________ Select private Message _____________
        public List<clsPrivateMessage> SelectPrivateMessageById(int messageId , string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectPrivateMessageById");
                comand.Parameters.AddWithValue("@messageId", messageId);
                List<clsPrivateMessage> activeList = new List<clsPrivateMessage>();
                TExecuteReaderCmd<clsPrivateMessage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPrivateMessage>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsPrivateMessage>();
        }


        //____________ deleteMessage for All Message _____________
        public bool DeleteMessageForEveryOne(int messageId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@messageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)messageId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteMessageForEveryOne", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        //____________ deleteMessage for sender Message _____________
        public bool DeleteMessageForSender(int messageId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@messageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)messageId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteMessageForSender", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }


        //____________ attach old message for update _____________



        //____________ select signle message for Attachments _____________
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsPrivateMessage> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsPrivateMessage obj = new clsPrivateMessage();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.senderId = returnData["senderId"] is DBNull ? (int)0 : (int)returnData["senderId"];
                    obj.receiverId = returnData["receiverId"] is DBNull ? (int)0 : (int)returnData["receiverId"];
                    obj.messageText = returnData["messageText"] is DBNull ? (string)string.Empty : (string)returnData["messageText"];
                    obj.appId = returnData["appId"] is DBNull || returnData["appId"] == null ? (int)0 : (int)returnData["appId"];
                    obj.applicationReviewId = returnData["applicationReviewId"] is DBNull || returnData["applicationReviewId"] == null ? (int)0 : (int)returnData["applicationReviewId"];
                    obj.isReceiver = returnData["isReceiver"] is DBNull || returnData["isReceiver"] == null ? false : (bool)returnData["isReceiver"];
                    obj.isSender = returnData["isSender"] is DBNull || returnData["isSender"] == null ? false : (bool)returnData["isSender"];
                    obj.reminder = returnData["reminder"] is DBNull || returnData["reminder"] == null ? (DateTime?)null : ((DateTime?)returnData["reminder"]);
                    obj.isDelete = returnData["IsDeleted"] is DBNull || returnData["IsDeleted"] == null ? (int)0 : ((int)returnData["IsDeleted"]);
                    obj.timeStamp = returnData["timestamp"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["timestamp"];

                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
