using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Database.Models.Base;

namespace WebApi.Database.Models
{
    public class Phone:BaseModel
    {
        public string Number { get; set; }
        public PhoneType PhoneType { get; set; }
        public Guid PersonID { get; set; }

        public Person Person { get; set; }
    }

    public enum PhoneType
    {
        Personal = 1,
        Home = 2,
        Office = 3,
        Any = 4,
    }
}
