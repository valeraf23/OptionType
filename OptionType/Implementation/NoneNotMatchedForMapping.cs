using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class NoneNotMatchedForMapping<T, TResult> : IFilteredNoneMapped<T, TResult>, IFilteredMapped<T, TResult>
    {
        public IMapped<T, TResult> MapTo(Func<T, TResult> mapping)
        {
            return new MappingOnNoneNotResolved<T, TResult>();
        }

        public IMapped<T, TResult> MapTo(Func<TResult> mapping)
        {
            return new MappingOnNoneNotResolved<T, TResult>();
        }
    }
}