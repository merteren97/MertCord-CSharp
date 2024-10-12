using MertCord_Client.Models.DB;
using System.Security.Policy;

namespace MertCord_Client.Services
{
    public class APIGateway : SingletonManager<APIGateway>
    {
        #region TCP Service

        public async Task TCPConnect() => TCP_Service.Instance().ConnectToServerAsync();
        public async Task TCPSendMessage(string userName, string message) => TCP_Service.Instance().SendMessageToServerAsync(userName, message);

        #endregion

        #region Chat_TBL Service

        public void ChatDelete(int id) => Chat_TBL_Service.Instance().Delete(id);
        public Chat_TBL ChatGet(int id) => Chat_TBL_Service.Instance().Get(id);
        public Chat_TBL ChatGetByName(string name) => Chat_TBL_Service.Instance().GetByName(name);
        public List<Chat_TBL> ChatGetAll() => Chat_TBL_Service.Instance().GetAll(); // Günlük mesajlar getirilir.
        public void ChatInsert(Chat_TBL item) => Chat_TBL_Service.Instance().Insert(item);
        public void ChatUpdate(Chat_TBL item) => Chat_TBL_Service.Instance().Update(item);

        #endregion

        #region Username Service

        public string Username_Get() => Username_Service.Instance().LoadUsername();
        public void Username_Set(string name) => Username_Service.Instance().SaveUsername(name);

        #endregion
    }
}