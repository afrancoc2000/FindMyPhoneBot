using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMyPhonebot.Application.Services;
using FindMyPhoneBot.Domain.Common;
using FindMyPhoneBot.Infrastructure.Clients;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace FindMyPhoneBot.Test.ApplicationTests.Services
{
    [TestClass]
    public class ConversationServiceTest
    {

        private ILuisClient luisClient;
        private IPhoneCallClient phoneCallClient;
        private ConversationService conversationService;

        [TestInitialize]
        public void Initialize()
        {
            this.luisClient = Substitute.For<ILuisClient>();
            this.phoneCallClient = Substitute.For<IPhoneCallClient>();
            this.conversationService = new ConversationService(luisClient, phoneCallClient);
        }

        [TestMethod]
        public async void GetApplicationAnswerSaludarTest()
        {
            luisClient.GetUserIntent(Arg.Any<string>())
                .Returns(x => Task.FromResult(new IntentionResult { Intention = Intention.Saludar, Telefono = null }));

            var result = await conversationService.GetApplicationAnswer("hola");
            Assert.AreEqual(Message.HelloMessage, result);

        }

    }
}
