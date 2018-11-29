using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class MappingOnNoneNotResolved<T, TResult> : IMapped<T, TResult>
    {
        public IFilteredMapped<T, TResult> When(Func<T, bool> predicate)
        {
            return new NoneNotMatchedForMapping<T, TResult>();
        }

        public IFilteredMapped<T, TResult> WhenValue()
        {
            return new NoneNotMatchedForMapping<T, TResult>();
        }

        public IFilteredNoneMapped<T, TResult> WhenNone()
        {
            return new NoneMatchedForMapping<T, TResult>();
        }

        public TResult Map()
        {
            throw new InvalidOperationException();
        }
    }
}