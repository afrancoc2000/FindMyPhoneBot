using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FindMyPhonebot.Application.Services;
using FindMyPhoneBot.Bot.Dialogs;
using FindMyPhoneBot.Infrastructure.Clients;
using log4net.Config;
using Microsoft.Bot.Builder.Dialogs;

namespace FindMyPhoneBot.Bot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterBotDependencies();

            XmlConfigurator.Configure();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterBotDependencies()
        {
            Conversation.UpdateContainer(builder =>
            {
                builder.RegisterType<RootDialog>().As<IDialog<object>>().InstancePerDependency();
                builder.RegisterType<ConversationService>().As<IConversationService>();
                builder.RegisterType<LuisClient>().As<ILuisClient>()
                    .WithParameter("uri", ConfigurationManager.AppSettings["LuisClientEndPoint"])
                    .WithParameter("apiKey", ConfigurationManager.AppSettings["LuisClientKey"]);
                builder.RegisterType<PhoneCallClient>().As<IPhoneCallClient>();
                builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            });


            DependencyResolver.SetResolver(new AutofacDependencyResolver(Conversation.Container));
        }

    }
}
