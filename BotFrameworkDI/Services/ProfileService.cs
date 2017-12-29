using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using BotFrameworkDI.Models;

namespace BotFrameworkDI.Services
{
    public class UserProfileService : IProfileService
    {
        private HttpClient client;

        public UserProfileService(HttpClient client)
        {
            this.client = client;
        }
        public Profile GetProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public void SaveProfile()
        {
            throw new NotImplementedException();
        }
    }
}