using System.Runtime.Serialization;

namespace Vending_Machine
{
    [Serializable]
    public class WrongCoinException : Exception
    {
        public WrongCoinException()
        {
        }

        public WrongCoinException(string? message) : base(message)
        {
        }

        public WrongCoinException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongCoinException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}