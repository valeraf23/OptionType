using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class ValueNotMatchedOption<T> : IFiltered<T>, IFilteredNoneActionable<T>
    {
        public ValueNotMatchedOption(T value)
        {
            Value = value;
        }

        private T Value { get; }

        public IActionable<T> Do(Action<T> action)
        {
            return new ActionOnValueNotResolved<T>(Value);
        }

        public IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping)
        {
            return new MappingOnValueNotResolved<T, TResult>(Value);
        }

        public IActionable<T> Do(Action action)
        {
            return new ActionOnValueNotResolved<T>(Value);
        }
    }
}