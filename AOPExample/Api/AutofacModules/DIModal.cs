using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Services;
using Autofac;

namespace Api.AutofacModules
{
    public class DIModal: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UserService)).Named<IUserService>(typeof(UserService).Name);
        }
    }
}
