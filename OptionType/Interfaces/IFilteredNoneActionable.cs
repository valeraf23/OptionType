using System;

namespace OptionType.Interfaces
{
    public interface IFilteredNoneActionable<T>
    {
        IActionable<T> Do(Action action);
    }
}