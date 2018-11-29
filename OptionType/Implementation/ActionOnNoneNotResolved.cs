using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class ActionOnNoneNotResolved<T> : IActionable<T>
    {
        public IFilteredActionable<T> When(Func<T, bool> predicate)
        {
            return new NoneNotMatchedAsValueOption<T>();
        }

        public IFilteredActionable<T> WhenValue()
        {
            return new NoneNotMatchedAsValueOption<T>();
        }

        public IFilteredNoneActionable<T> WhenNone()
        {
            return new NoneMatchedAsNoneOption<T>();
        }

        public void Execute()
        {
        }
    }
}