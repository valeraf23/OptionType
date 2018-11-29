using System;

namespace OptionType.Interfaces
{
    public interface IFilteredActionable<T>
    {
        IActionable<T> Do(Action<T> action);
    }
}