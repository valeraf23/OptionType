using System;
using System.Collections.Generic;
using System.Linq;
using OptionType.Implementation;
using OptionType.Interfaces;

namespace OptionType
{
    public sealed class Option<T> : IOption<T>, IEquatable<Option<T>>
    {
        private Option(IEnumerable<T> content) => Content = content;

        private IEnumerable<T> Content { get; }

        public IFiltered<T> When(Func<T, bool> predicate) => Content
            .Select(item => OnCondition(item, predicate))
            .DefaultIfEmpty(new NoneNotMatchedAsValueOption<T>())
            .Single();

        public IFiltered<T> WhenValue() => Content
            .Select<T, IFiltered<T>>(item => new ValueMatchedOption<T>(item))
            .DefaultIfEmpty(new NoneNotMatchedAsValueOption<T>())
            .Single();

        public IFilteredNone<T> WhenNone() => Content
            .Select<T, IFilteredNone<T>>(item => new SomeNotMatchedAsNone<T>(item))
            .DefaultIfEmpty(new NoneMatchedAsNoneOption<T>())
            .Single();

        public static Option<T> For(T value) => new Option<T>(new[] {value});

        public static Option<T> None() => new Option<T>(new T[0]);

        private static IFiltered<T> OnCondition(T value, Func<T, bool> predicate)
        {
            return predicate(value)
                ? new ValueMatchedOption<T>(value)
                : (IFiltered<T>) new ValueNotMatchedOption<T>(value);
        }

        public static implicit operator T(Option<T> some) =>
            some.Content.Single();

        public static implicit operator Option<T>(T value) => For(value);

        public override string ToString() => WhenValue().MapTo(v => v.ToString()).WhenNone().MapTo(() => "None").Map();

        public Option<TResult> Map<TResult>(Func<T, TResult> map) =>
            map(Content.Single());

        public Option<TResult> MapOptional<TResult>(Func<T, Option<TResult>> map) =>
            map(Content.Single());

        public bool Equals(Option<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Content.Single(), other.Content.Single());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Option<T> option && Equals(option);
        }

        public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(Content.Single());

        public static bool operator ==(Option<T> a, Option<T> b) =>
            (a is null && b is null) ||
            (!(a is null) && a.Equals(b));

        public static bool operator !=(Option<T> a, Option<T> b) => !(a == b);
    }
}