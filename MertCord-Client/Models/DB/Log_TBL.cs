using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MertCord_Client.Models.DB
{
    public class Log_TBL : Base_TBL
    {
        public string? MethodName { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public string? ClassName { get; set; }
    }
}
