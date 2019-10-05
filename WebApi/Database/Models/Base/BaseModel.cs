using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Database.Models.Base
{
    public interface IBaseModel
    {
        [Key]
        Guid ID { get; set; }
        DateTime CreateAt { get; set; }
        DateTime UpdateAt { get; set; }
    }
    public abstract class BaseModel : IBaseModel
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
