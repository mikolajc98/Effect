using System.Collections.Generic;
using System.Linq;

namespace EffectCore
{
    public class Effect
    {
        private const string _successfulDefaultMessage = "Success";
        public const string _defaultMergeSeparator = "\r\n";

        public bool Fail { get; }
        public bool Success => !Fail;
        public string Message { get; }

        internal Effect(bool isFail, string message)
        {
            Fail = isFail;
            Message = message;
        }

        public static Effect Successful(string message)
        {
            return new Effect(false, message);
        }
        public static Effect Successful()
        {
            return new Effect(false, _successfulDefaultMessage);
        }

        public static Effect Failure(string message)
        {
            return new Effect(true, message);
        }

        public static Effect Merge(IEnumerable<Effect> effects)
        {
            if (effects.All(x => x.Success))
                return Successful();

            return Failure(string.Join(_defaultMergeSeparator, effects.Where(x => x.Fail).Select(y => y.Message)));
        }

        public static bool operator ==(Effect left, Effect right)
        {
            return left.Fail == right.Fail;
        }

        public static bool operator !=(Effect left, Effect right)
        {
            return !left.Fail == right.Fail;
        }
        public Effect<T> ToEffect<T>(T content)
        {
            return Fail ? Effect<T>.Failure(Message, content) : Effect<T>.Successful(Message, content);
        }        

        public override bool Equals(object obj)
        {
            return this == (Effect)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
