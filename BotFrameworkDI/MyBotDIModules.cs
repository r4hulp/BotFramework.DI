using Autofac;
using BotFrameworkDI.Dialogs;
using BotFrameworkDI.Factories;
using BotFrameworkDI.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.ApplicationServices;

namespace BotFrameworkDI
{
    public class MyBotDIModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DialogFactory>()
                .Keyed<IDialogFactory>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<RootDialog>()
                .As<IDialog<object>>()
                .InstancePerDependency();

            builder.RegisterType<ProfileDialog>().InstancePerDependency();
            builder.RegisterType<SettingsDialog>().InstancePerDependency();

            builder.RegisterType<UserProfileService>()
                .Keyed<IProfileService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<HttpClient>()
                .Keyed<HttpClient>(FiberModule.Key_DoNotSerialize)
                .AsSelf()
                .InstancePerDependency();
        }
    }
}