using System;
using System.Threading.Tasks;
using FindMyPhonebot.Application.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace FindMyPhoneBot.Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        IConversationService conversationService;

        public RootDialog(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            var answer = await conversationService.GetApplicationAnswer(activity.Text);

            // return our reply to the user
            await context.PostAsync(answer);

            context.Wait(MessageReceivedAsync);
        }
    }
}