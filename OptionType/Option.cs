using System;
using System.Collections.Generic;
using System.Linq;
using OptionType.Implementation;
using OptionType.Interfaces;

namespace OptionType
{
    public class Option<T> : IOption<T>
    {
        private Option(IEnumerable<T> content)
        {
            Content = content;
        }

        private IEnumerable<T> Content { get; }

        public IFiltered<T> When(Func<T, bool> predicate)
        {
            return Content
                .Select(item => OnCondition(item, predicate))
                .DefaultIfEmpty(new NoneNotMatchedAsValueOption<T>())
                .Single();
        }

        public IFiltered<T> WhenValue()
        {
            return Content
                .Select<T, IFiltered<T>>(item => new ValueMatchedOption<T>(item))
                .DefaultIfEmpty(new NoneNotMatchedAsValueOption<T>())
                .Single();
        }

        public IFilteredNone<T> WhenNone()
        {
            return Content
                .Select<T, IFilteredNone<T>>(item => new SomeNotMatchedAsNone<T>(item))
                .DefaultIfEmpty(new NoneMatchedAsNoneOption<T>())
                .Single();
        }

        public static IOption<T> For(T value)
        {
            return new Option<T>(new[] {value});
        }

        public static IOption<T> None()
        {
            return new Option<T>(new T[0]);
        }

        private static IFiltered<T> OnCondition(T value, Func<T, bool> predicate)
        {
            return predicate(value)
                ? new ValueMatchedOption<T>(value)
                : (IFiltered<T>) new ValueNotMatchedOption<T>(value);
        }

        public override string ToString()
        {
            return WhenValue().MapTo(v => v.ToString()).WhenNone().MapTo(() => "None").Map();
        }
    }
}