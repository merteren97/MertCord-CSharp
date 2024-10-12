using MertCord_Client.Models;
using System.Reflection;

namespace MertCord_Client.Services
{
    public class Username_Service : SingletonManager<Username_Service>
    {
        public string LoadUsername()
        {
            try
            {
                if (!Directory.Exists(Paths.ProjectPath))
                {
                    Directory.CreateDirectory(Paths.ProjectPath);
                }
                if (File.Exists(Paths.UsernameTextPath))
                {
                    return File.ReadAllText(Paths.UsernameTextPath);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), GetType().Name);
                return null;
            }
        }
        public void SaveUsername(string username)
        {
            try
            {
                if (!Directory.Exists(Paths.ProjectPath))
                {
                    Directory.CreateDirectory(Paths.ProjectPath);
                }
                File.WriteAllText(Paths.UsernameTextPath, username);
            }
            catch (Exception ex)
            {
                Log_TBL_Service.Instance().Create(MethodBase.GetCurrentMethod()!, ex.Message, Enums.State.Error.ToString(), GetType().Name);
            }
        }
    }
}