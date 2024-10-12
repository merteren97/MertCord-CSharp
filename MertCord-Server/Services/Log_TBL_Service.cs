using MertCord_Server.Context;
using MertCord_Server.Models;
using MertCord_Server.Models.DB;
using System.Reflection;

namespace MertCord_Server.Services
{
    public class Log_TBL_Service : SingletonManager<Log_TBL_Service>
    {
        public void Create(MethodBase methodBase, string description, string state, string className)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    context.Log_TBLs.Add(new Log_TBL()
                    {
                        MethodName = methodBase.Name,
                        Description = description,
                        State = state,
                        ClassName = className
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), GetType().Name);
            }
        }
    }
}