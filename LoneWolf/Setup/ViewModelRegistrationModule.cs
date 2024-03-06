using System.Linq;
using System.Reflection;
using Autofac;
using LoneWolf.Views;
using LoneWolf.Views.Welcome;
using PolyhydraGames.Core.Forms.Interfaces;
using PolyhydraGames.Core.Forms.Setup;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.Extensions;

namespace LoneWolf.Setup
{
    public sealed class ViewModelRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(ThisAssembly.CreatableTypes().EndingWith("ViewModel").ToArray()).AsImplementedInterfaces().AsSelf();
            builder.RegisterTypes(typeof(FormsIOCBootstrapper).GetTypeInfo().Assembly.CreatableTypes().EndingWith("ViewModel").ToArray());
            builder.RegisterType<MenuViewModel>().AsSelf().As<IMainMenu>().SingleInstance();
//            builder.RegisterType<WelcomeViewModel>().AsSelf().As<IFirstPageViewModel>().SingleInstance();
        }

    }
}