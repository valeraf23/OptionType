using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class ActionOnValueNotResolved<T> : IActionable<T>
    {
        public ActionOnValueNotResolved(T value)
        {
            Value = value;
        }

        private T Value { get; }

        public IFilteredActionable<T> When(Func<T, bool> predicate)
        {
            return predicate(Value)
                ? (IFilteredActionable<T>) new ValueMatchedOption<T>(Value)
                : new ValueNotMatchedOption<T>(Value);
        }

        public IFilteredActionable<T> WhenValue()
        {
            return new ValueMatchedOption<T>(Value);
        }

        public IFilteredNoneActionable<T> WhenNone()
        {
            return new ValueNotMatchedOption<T>(Value);
        }

        public void Execute()
        {
        }
    }
}