using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class MappingOnValueNotResolved<T, TResult> : IMapped<T, TResult>
    {
        public MappingOnValueNotResolved(T value)
        {
            Value = value;
        }

        private T Value { get; }

        public IFilteredMapped<T, TResult> When(Func<T, bool> predicate)
        {
            return predicate(Value)
                ? (IFilteredMapped<T, TResult>) new ValueMatchedForMapping<T, TResult>(Value)
                : new SomeNotMatchedForMapping<T, TResult>(Value);
        }

        public IFilteredMapped<T, TResult> WhenValue()
        {
            return new ValueMatchedForMapping<T, TResult>(Value);
        }

        public IFilteredNoneMapped<T, TResult> WhenNone()
        {
            return new SomeNotMatchedAsNoneForMapping<T, TResult>(Value);
        }

        public TResult Map()
        {
            throw new InvalidOperationException();
        }
    }
}