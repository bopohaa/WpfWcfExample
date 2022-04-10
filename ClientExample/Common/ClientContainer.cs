using System;
using System.ServiceModel;
using ClientExample.ServerSample;

namespace ClientExample.Common
{
    public class ClientContainer<T> : IDisposable
        where T : class
    {
        private readonly Func<T> _clientFactory;
        private T _client;

        public ClientContainer(Func<T> client_factory)
        {
            _clientFactory = client_factory;
        }

        public T GetClient()
        {
            lock (this)
            {
                if (_client is null || IsCommunicationObjectFaled(_client))
                    CreateClient();
                return _client;
            }
        }

        public void Dispose()
        {
            DestroyClient();
        }

        private void DestroyClient()
        {
            if (_client is null)
                return;
            try
            {
                (_client as IDisposable)?.Dispose();
            }
            catch { }
            _client = null;
        }
        private void CreateClient()
        {
            DestroyClient();
            _client = _clientFactory();
        }

        private static bool IsCommunicationObjectFaled(T client)
        {
            var typed = client as ICommunicationObject;
            return typed != null && (typed.State == CommunicationState.Faulted || typed.State == CommunicationState.Closed);
        }
    }


}
