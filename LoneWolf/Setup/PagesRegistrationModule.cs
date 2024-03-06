using System.Linq;
using System.Reflection;
using Autofac;
using PolyhydraGames.Core.Forms.Setup;
using PolyhydraGames.Extensions;

namespace LoneWolf.Setup
{
    public class PagesRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        { 
            builder.RegisterTypes(ThisAssembly.CreatableTypes().EndingWith("Page").ToArray());
            builder.RegisterTypes(typeof(FormsIOCBootstrapper).GetTypeInfo().
                Assembly.CreatableTypes().EndingWith("Page").ToArray()); 
        }
    }
}