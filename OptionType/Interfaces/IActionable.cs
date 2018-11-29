using System;

namespace OptionType.Interfaces
{
    public interface IActionable<T>
    {
        IFilteredActionable<T> When(Func<T, bool> predicate);
        IFilteredActionable<T> WhenValue();
        IFilteredNoneActionable<T> WhenNone();
        void Execute();
    }
}