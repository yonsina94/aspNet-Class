using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Database.Models.Base;

namespace WebApi.Database.Models
{
    public class Person:BaseModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
        public string Email { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
