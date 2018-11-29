using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class ValueMatchedForMapping<T, TResult> : IFilteredMapped<T, TResult>
    {
        private readonly T _value;

        public ValueMatchedForMapping(T value)
        {
            _value = value;
        }

        public IMapped<T, TResult> MapTo(Func<T, TResult> mapping)
        {
            return new MappingResolved<T, TResult>(mapping(_value));
        }
    }
}