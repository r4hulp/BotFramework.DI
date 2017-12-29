using BotFrameworkDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFrameworkDI.Services
{
    public interface IProfileService
    {
        Profile GetProfile(int userId);

        void SaveProfile();
    }
}