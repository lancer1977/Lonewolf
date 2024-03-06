using Autofac;
using LoneWolf.Setup;

namespace LoneWolf.Droid
{
    public class DroidCraftBootstrapper : CoreBootstrapper
    {
        public static void Run()
        {
            var item = new DroidCraftBootstrapper();

            item.Setup();

        }
        protected override void BuildDeviceServices(ContainerBuilder builder)
        {
            builder.RegisterModule<PolyhydraGames.Core.Droid.DeviceModule>(); 
        }
    }
}