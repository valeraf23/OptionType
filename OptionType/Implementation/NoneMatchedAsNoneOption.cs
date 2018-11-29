using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class NoneMatchedAsNoneOption<T> : IFilteredNone<T>, IFilteredNoneActionable<T>
    {
        public IActionable<T> Do(Action action)
        {
            return new ActionResolved<T>(action);
        }

        public IMapped<T, TResult> MapTo<TResult>(Func<TResult> mapping)
        {
            return new MappingResolved<T, TResult>(mapping());
        }
    }
}