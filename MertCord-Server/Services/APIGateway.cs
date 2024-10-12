using MertCord_Server.Models.DB;

namespace MertCord_Server.Services
{
    public class APIGateway : SingletonManager<APIGateway>
    {
        #region Chat_TBL Service

        public void ChatDelete(int id) => Chat_TBL_Service.Instance().Delete(id);
        public Chat_TBL ChatGet(int id) => Chat_TBL_Service.Instance().Get(id);
        public Chat_TBL ChatGetByName(string name) => Chat_TBL_Service.Instance().GetByName(name);
        public List<Chat_TBL> ChatGetAll() => Chat_TBL_Service.Instance().GetAll(); // Günlük mesajlar getirilir.
        public void ChatInsert(Chat_TBL item) => Chat_TBL_Service.Instance().Insert(item);
        public void ChatUpdate(Chat_TBL item) => Chat_TBL_Service.Instance().Update(item);

        #endregion
    }
}