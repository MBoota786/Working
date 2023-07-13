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
                AddParamToSQLCmd(comm, "@receverId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.receiverId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@message", SqlDbType.NVarChar, 4, ParameterDirection.Input, (object)obj.message ?? DBNull.Value);

                Id = ExecuteInsertCommandReturnId(comm, "spIsertPrivateMessage", "EvolveMain");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }

        //____________ Select all private Message _____________
        public List<clsPrivateMessage> selectAllPrivateMessage(int senderId , int receverId , string dbName)
        
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllPrivateMessage");
                comand.Parameters.AddWithValue("@senderId", senderId);
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
                    obj.message = returnData["message"] is DBNull ? (string)string.Empty : (string)returnData["message"];
                    obj.timestamp = returnData["timestamp"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["timestamp"];

                    //obj.isReaded = returnData["isReaded"] is DBNull ? (bool)false : (bool)returnData["isReaded"];
                    //obj.isSender = returnData["isSender"] is DBNull ? (bool)false : (bool)returnData["isSender"];
                    //obj.isReceiver  = returnData["isReceiver"] is DBNull ? (bool)false : (bool)returnData["isReceiver"];
                    
                    obj.isReaded = returnData["isReaded"] is DBNull || returnData["isReaded"] == null ? false : (bool)returnData["isReaded"];
                    obj.isSender = returnData["isSender"] is DBNull || returnData["isSender"] == null ? false : (bool)returnData["isSender"];
                    obj.isReceiver = returnData["isRecever"] is DBNull || returnData["isRecever"] == null ? false : (bool)returnData["isRecever"];

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
