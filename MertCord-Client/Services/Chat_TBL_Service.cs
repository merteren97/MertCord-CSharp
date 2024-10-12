using MertCord_Client.Models;
using MertCord_Client.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MertCord_Client.Services
{
    public class Chat_TBL_Service : SingletonManager<Chat_TBL_Service>
    {
        public void Delete(int id)
        {
            try
            {
                using (Context.DataContext context = new Context.DataContext())
                {
                    context.Chat_TBLs.Where(x => x.Id == id).ExecuteDelete();
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), this.GetType().Name);
            }
        }
        public Chat_TBL Get(int id)
        {
            try
            {
                using (Context.DataContext context = new Context.DataContext())
                {
                    return context.Chat_TBLs.Where(x => x.Id == id).FirstOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), this.GetType().Name);
                return new Chat_TBL();
            }
        }
        public Chat_TBL GetByName(string name)
        {
            try
            {
                using (Context.DataContext context = new Context.DataContext())
                {
                    return context.Chat_TBLs.Where(x => x.UserName == name).FirstOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), this.GetType().Name);
                return new Chat_TBL();
            }
        }
        public List<Chat_TBL> GetAll()
        {
            try
            {
                using (Context.DataContext context = new Context.DataContext())
                {
                    DateTime today = DateTime.Now.Date;
                    return context.Chat_TBLs.Where(x => x.CreateDate >= today).ToList();
                }
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), this.GetType().Name);
                return new List<Chat_TBL>();
            }
        }
        public void Insert(Chat_TBL item)
        {
            try
            {
                using (Context.DataContext context = new Context.DataContext())
                {
                    context.Chat_TBLs.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), this.GetType().Name);
            }
        }
        public void Update(Chat_TBL item)
        {
            try
            {
                using (Context.DataContext context = new Context.DataContext())
                {
                    context.Chat_TBLs.Update(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), this.GetType().Name);
            }
        }
    }
}
