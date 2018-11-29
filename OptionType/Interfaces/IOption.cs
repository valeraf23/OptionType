using System;

namespace OptionType.Interfaces
{
    public interface IOption<T>
    {
        IFiltered<T> When(Func<T, bool> predicate);
        IFiltered<T> WhenValue();
        IFilteredNone<T> WhenNone();
    }
}