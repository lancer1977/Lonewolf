using System.Linq;
using System.Reflection;
using Autofac;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.Extensions;

namespace LoneWolf.Setup
{
    public class ServicesAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAssembly = typeof(ServicesAutofacModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(ThisAssembly, dataAssembly).AssignableTo<IStart>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterTypes(ThisAssembly.CreatableTypes().EndingWith("Service").ToArray()).AsImplementedInterfaces().SingleInstance();
        }

    }
}