using BotFrameworkDI.Services;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotFrameworkDI.Dialogs
{
    public class ProfileDialog : IDialog<string>
    {
        private IProfileService profileService;

        public ProfileDialog(IProfileService profileService)
        {
            this.profileService = profileService;
        }
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hello from Profile");
            context.Done("Profile");
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            context.Done("Profile");
        }
    }
}