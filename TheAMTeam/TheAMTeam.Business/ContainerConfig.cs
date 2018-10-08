using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheAMTeam.Business.Components;
using TheAMTeam.Business.Components.Interface.Components;
using TheAMTeam.DataAccessLayer.Context;
using TheAMTeam.DataAccessLayer.Repositories;
using TheAMTeam.DataAccessLayer.Repositories.Interfaces.Repositories;
using AppContext = TheAMTeam.DataAccessLayer.Context.AppContext;

namespace TheAMTeam.Business
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PlayerComponent>().As<IPlayerComponent>();
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>();
            builder.RegisterType<AppContext>().As<IAppContext>();

            return builder.Build();
        }
    }
}