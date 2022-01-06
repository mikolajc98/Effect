namespace EffectCore.Extensions
{
    public static class EffectExtensions
    {
        public static Effect Merge(this Effect e, Effect other)
        {
            if (other.Success)
                return e;

            return Effect.Failure($"{e.Message}{Effect._defaultMergeSeparator}{other.Message}");
        }
    }
}
