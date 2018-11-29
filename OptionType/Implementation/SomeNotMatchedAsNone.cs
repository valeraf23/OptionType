using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class SomeNotMatchedAsNone<T> : IFilteredNone<T>
    {
        public SomeNotMatchedAsNone(T value)
        {
            Value = value;
        }

        private T Value { get; }

        public IActionable<T> Do(Action action)
        {
            return new ActionOnValueNotResolved<T>(Value);
        }

        public IMapped<T, TResult> MapTo<TResult>(Func<TResult> mapping)
        {
            return new MappingOnValueNotResolved<T, TResult>(Value);
        }
    }
}