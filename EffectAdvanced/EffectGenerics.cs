namespace EffectCore
{
    public class Effect<T>
    {
        private const string _successfulDefaultMessage = "Success";
        private const string _failureDefaultMessage = "Failure";

        public bool Fail { get; }
        public bool Success => !Fail;
        public string Message { get; }
        public T Content { get; }

        private Effect(bool fail, string message, T content)            
        {
            Fail = fail;
            Message = message;
            Content = content;
        }

        public static Effect<T> Successful(string message, T content)
        {
            return new Effect<T>(false, message, content);
        }

        public static Effect<T> Successful(T content)
        {
            return new Effect<T>(false, _successfulDefaultMessage, content);
        }
        public static Effect<T> Failure(string message, T content)
        {
            return new Effect<T>(true, message, content);
        }
        public static Effect<T> Failure(T content)
        {
            return new Effect<T>(true,_failureDefaultMessage, content);
        }

        public static bool operator ==(Effect<T> left, Effect<T> right)
        {
            return left.Fail == right.Fail;
        }

        public static bool operator !=(Effect<T> left, Effect<T> right)
        {
            return !left.Fail == right.Fail;
        }
        
        public static implicit operator Effect(Effect<T> effect)
        {
            return effect.Fail ? Effect.Failure(effect.Message) : Effect.Successful(effect.Message);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Effect GetEffect()
        {
            return Fail ? Effect.Failure(Message) : Effect.Successful(Message);
        }
    }
}
