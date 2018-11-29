using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class SomeNotMatchedAsNoneForMapping<T, TResult> : IFilteredNoneMapped<T, TResult>
    {
        public SomeNotMatchedAsNoneForMapping(T value)
        {
            Value = value;
        }

        private T Value { get; }

        public IMapped<T, TResult> MapTo(Func<TResult> mapping)
        {
            return new MappingOnValueNotResolved<T, TResult>(Value);
        }
    }
}