using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class NoneMatchedForMapping<T, TResult> : IFilteredNoneMapped<T, TResult>
    {
        public IMapped<T, TResult> MapTo(Func<TResult> mapping)
        {
            return new MappingResolved<T, TResult>(mapping());
        }
    }
}