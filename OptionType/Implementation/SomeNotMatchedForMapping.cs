using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class SomeNotMatchedForMapping<T, TResult> : IFilteredMapped<T, TResult>
    {
        private readonly T _value;

        public SomeNotMatchedForMapping(T value)
        {
            _value = value;
        }

        public IMapped<T, TResult> MapTo(Func<T, TResult> mapping)
        {
            return new MappingOnValueNotResolved<T, TResult>(_value);
        }
    }
}