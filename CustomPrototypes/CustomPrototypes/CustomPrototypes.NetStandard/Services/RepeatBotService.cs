using System;
using System.Threading.Tasks;

namespace CustomPrototypes.NetStandard.Services
{
    public class RepeatBotService
    {
        private Action<string> _onReceiveMessage;
        
        internal void AttachOnReceiveMessage(Action<string> onMessageReceived)
        {
            this._onReceiveMessage = onMessageReceived;
        }

        internal void SendToBot(string text)
        {
            Task.Delay(500).ContinueWith(t => this._onReceiveMessage?.Invoke(text));
        }
    }
}
