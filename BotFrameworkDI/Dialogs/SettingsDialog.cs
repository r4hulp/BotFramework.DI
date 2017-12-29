using BotFrameworkDI.Services;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BotFrameworkDI.Dialogs
{
    public class SettingsDialog : IDialog<string>
    {
        private string settings;
        private IProfileService profileService;

        public SettingsDialog(string settings, IProfileService profileService)
        {
            this.settings = settings;
            this.profileService = profileService;
        }
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hello from Settings");
            context.Done("Settings");
        }
    }
}