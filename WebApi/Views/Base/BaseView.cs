using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Database.Models.Base;

namespace WebApi.Views.Base
{
    public abstract class BaseView<Tmodel> where Tmodel:class,IBaseModel
    {
        public BaseView()
        {

        }

        public BaseView(Tmodel model)
        {
            ID = model.ID;
        }

        public Guid ID { get; set; }

        public Tmodel ToModel()
        {
            var model = MakeModel();
            return model;
        }
        public abstract Tmodel MakeModel();
    }
}
