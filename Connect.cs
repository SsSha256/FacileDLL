using FacileDLL.Prototypes;
using System;
using System.Threading.Tasks;
using WebSocketSharp;

namespace FacileDLL
{
    /// <summary>
    /// Устанавливает соединение с сервером по протоколу ws
    /// </summary>
    public class Connect : IConnect
    {
        private WebSocket ws;
        private string ReqMsg = null;
        private byte[] BytesMsg = null;

        private readonly string Uri = null;

        /// <summary>
        /// Создаёт экземпляр класса
        /// </summary>
        /// <param name="ip">IP адрес сервера</param>
        public Connect(string ip)
        {
            Uri = ip;
        }

        void IConnect.Connection(string Port)
        {
            ws = new WebSocket("ws://" + Uri + ":" + Port);
        }

        private void OnMessage(object s, MessageEventArgs e)
        {
            if (e.IsText)
            {
                ReqMsg = e.Data;
            }
            else if (e.IsBinary)
            {
                BytesMsg = e.RawData;
            }
        }

        async Task<string> IConnect.SendAsync(string message)
        {
            (ReqMsg, BytesMsg) = (null, null);
            ws.OnMessage += OnMessage;
            ws.OnOpen += (s, e) => ws.Send(message);
            ws.Connect();
            _ = await ((IConnect)this).WaitAsync();
            return ReqMsg;
        }

        async Task<string> IConnect.SendAsync(byte[] message)
        {
            (ReqMsg, BytesMsg) = (null, null);
            ws.OnMessage += OnMessage;
            ws.OnOpen += (s, e) => ws.Send(message);
            ws.Connect();
            _ = await ((IConnect)this).WaitAsync();
            return ReqMsg;
        }

        async Task<byte[]> IConnect.GetBytes(string message)
        {
            (ReqMsg, BytesMsg) = (null, null);
            ws.OnMessage += OnMessage;
            ws.OnOpen += (s, e) => ws.Send(message);
            ws.Connect();
            _ = await ((IConnect)this).WaitAsync();
            return BytesMsg;
        }

        async Task<byte[]> IConnect.GetBytes(byte[] message)
        {
            (ReqMsg, BytesMsg) = (null, null);
            ws.OnMessage += OnMessage;
            ws.OnOpen += (s, e) => ws.Send(message);
            ws.Connect();
            _ = await ((IConnect)this).WaitAsync();
            return BytesMsg;
        }

        async Task<bool> IConnect.WaitAsync()
        {
            bool s = false;
            while (!s)
            {
                if (ReqMsg != null || BytesMsg != null)
                {
                    ws.Close();
                    return true;
                }
                await Task.Delay(500);
            }
            return false;
        }
    }
}
