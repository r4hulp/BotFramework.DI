using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotFrameworkDI.Factories;
using BotFrameworkDI.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotFrameworkDI.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private IDialogFactory dialogFactory;

        public RootDialog(IDialogFactory dialogFactory)
        {
            this.dialogFactory = dialogFactory;
        }
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            if(activity.Text.Equals("profile", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Call(this.dialogFactory.Create<ProfileDialog>(), this.ResumeAfterProfileDialog);

            } else if(activity.Text.Equals("settings", StringComparison.InvariantCultureIgnoreCase))
            {
                Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
                paramDictionary.Add("settings", "Settings Param Value");
                context.Call(this.dialogFactory.Create<SettingsDialog>(paramDictionary), this.ResumeAfterProfileDialog);

            }
            else
            {
                // return our reply to the user
                await context.PostAsync($"You sent {activity.Text} which was {activity.Text.Length} characters");

                context.Wait(MessageReceivedAsync);

            }

        }

        private async Task ResumeAfterProfileDialog(IDialogContext context, IAwaitable<object> result)
        {
            var msg = await result;
            
            await context.PostAsync($"ResumeAfter method of {msg}");
        }
    }
}