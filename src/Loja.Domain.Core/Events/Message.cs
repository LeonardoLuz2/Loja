using MediatR;

namespace Loja.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; private set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
