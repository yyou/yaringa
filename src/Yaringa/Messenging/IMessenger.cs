using System;
using System.Collections.Generic;
using System.Text;

namespace Yaringa.Messenging
{
    /// <summary>
    /// Simplified messaging function based on the solution on 
    /// https://thomasbandt.com/a-nicer-messaging-interface-for-xamarinforms 
    /// </summary>
    public interface IMessenger {
        void Send<TMessage>(TMessage message)
            where TMessage : IMessage;

        void Subscribe<TMessage>(Action<object, TMessage> callback)
            where TMessage : IMessage;

        void Unsubscribe<TMessage>()
            where TMessage : IMessage;
    }
}
