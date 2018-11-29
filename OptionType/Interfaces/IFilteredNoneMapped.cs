using System;

namespace OptionType.Interfaces
{
    public interface IFilteredNoneMapped<T, TResult>
    {
        IMapped<T, TResult> MapTo(Func<TResult> mapping);
    }
}