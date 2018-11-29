using System;
using OptionType.Interfaces;

namespace OptionType.Implementation
{
    internal class NoneNotMatchedAsValueOption<T> : IFiltered<T>
    {
        public IActionable<T> Do(Action<T> action)
        {
            return new ActionOnNoneNotResolved<T>();
        }

        public IMapped<T, TResult> MapTo<TResult>(Func<T, TResult> mapping)
        {
            return new MappingOnNoneNotResolved<T, TResult>();
        }
    }
}