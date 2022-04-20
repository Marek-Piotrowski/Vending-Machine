using System.Runtime.Serialization;

namespace Vending_Machine
{
    [Serializable]
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException()
        {
        }

        public NotEnoughMoneyException(string? message) : base(message)
        {
        }

        public NotEnoughMoneyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotEnoughMoneyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}