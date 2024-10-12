namespace MertCord_Client.Models
{
    public class Paths
    {
        public static readonly string ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string ProjectName = "MertCordCSharp";
        public static readonly string ProjectPath = Path.Combine(ApplicationData, ProjectName);
        public static readonly string UsernameTextPath = Path.Combine(ProjectPath, "username.txt");
    }
}
