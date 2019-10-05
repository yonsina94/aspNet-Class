using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Database.Models.Base;
using WebApi.Views.Base;

namespace WebApi.Controllers.Base
{
    public abstract class BaseController<TService,TView,TModel> : ControllerBase where TView:BaseView<TModel> where TModel:class,IBaseModel
    {
        public BaseController()
        {

        }
    }
}