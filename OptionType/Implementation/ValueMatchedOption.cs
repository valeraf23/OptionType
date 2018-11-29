using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class ValueMatchedOption<T> : IFiltered<T>
    {
        public ValueMatchedOption(T value)
        {
            Value = value;
        }

        private T Value { get; }

        public IActionable<T> Do(Action<T> action)
        {
            return new ActionResolved<T>(() => action(Value));
        }

        public IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping)
        {
            return new MappingResolved<T, TResult>(mapping(Value));
        }
    }
}