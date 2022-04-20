using System.Runtime.Serialization;

namespace Vending_Machine
{
    [Serializable]
    public class NoMoneyToReturnException : Exception
    {
        public NoMoneyToReturnException()
        {
        }

        public NoMoneyToReturnException(string? message) : base(message)
        {
        }

        public NoMoneyToReturnException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoMoneyToReturnException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}