namespace MertCord_Server.Models.DB
{
    public class Base_TBL
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}