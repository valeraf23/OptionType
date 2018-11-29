using System;

namespace OptionType.Interfaces
{
    public interface IMapped<T, TResult>
    {
        IFilteredMapped<T, TResult> When(Func<T, bool> predicate);
        IFilteredMapped<T, TResult> WhenValue();
        IFilteredNoneMapped<T, TResult> WhenNone();
        TResult Map();
    }
}