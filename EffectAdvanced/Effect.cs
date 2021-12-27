namespace EffectCore
{
    public class Effect
    {
        private const string _successfulDefaultMessage = "Success";        

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
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
