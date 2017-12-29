using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotFrameworkDI.Factories
{
    public interface IDialogFactory
    {
        T Create<T>();

        T Create<T, U>(U parameter);

        T Create<T>(IDictionary<string, object> parameters);
    }
}