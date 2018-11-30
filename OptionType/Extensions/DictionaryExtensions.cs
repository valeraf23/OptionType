using System.Collections.Generic;

namespace OptionType.Extensions
{
    public static class DictionaryExtensions
    {
        public static Option<TValue> TryGetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, TKey key) =>
            dictionary.TryGetValue(key, out var value)
                ? Option<TValue>.For(value)
                : Option<TValue>.None();
    }
}
