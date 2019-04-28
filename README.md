[![Build Status](https://travis-ci.com/Vraiment/konvenience.svg?branch=master)](https://travis-ci.com/Vraiment/konvenience)

Konvenience
-------------

This is a small library of extension convenience extension methods inspired on the ones present in the [Kotlin standard library](https://kotlinlang.org/api/latest/jvm/stdlib/kotlin/index.html).

## How to use it

Add the namespace to your project:

```
using Konvenience;
```

That's it, now you can use the available extension methods.

## Available extension methods

### Common

These methods are available to all objects.

#### `T Also<T>(this T, Action<T>)`

Executes the given action with the input object and returns the object itself.

Example use case:

```
// Initialize complex objects
val myObject = new MyClass().Also(o =>
{
    o.Setup();
    o.Configure();
});
```

#### `TResult Let<T, TResult>(this T, Func<T, TResult> function)`

Executes the given function with the input object and returns its result.

Example use case:

```
// Transform a value that shouldn't be null and get a default in case of null
var result = myObject?.let(transform) ?? DEFAULT_VALUE;
```

#### `T Take(Reference|Value)(If|Unless)<T>(this T, Predicate<T>)`

Set of methods that return the input object depending on the result of the input predicate, or null otherwise.

Given how `class` and `struct` handle `null` differently, there are two versions of these extension methods: for references (`TakeReferenceIf`, `TakeReferenceUnless`) and for values (`TakeValueIf`, `TakeReferenceUnless`).

Example use case:

```
// Get a default value if the input object is not valid
var validString = myString.takeIf(s => s.Length > 10) ?? DEFAULT_STRING;
```

#### `T As<T>(this object obj)`

Executes a "*safe cast*" (using the `as` operator) in the input object, this is useful to chain other extension methods. This method is only available to references (objects of type `class`).

Example use case:

```
var result = input.As<OtherClass>().Let(o => o.Property);
```

### Enumerables

These are several methods to perform operations on `IEnumerable` objects.

#### `void ForEach(...)`

Executes the input `Action<T>` in the input `IEnumerable`.

Example use case:

```
void SomeFunction(int number) { ... }

// Somewhere else
myNumbers.ForEach(SomeFunction);
```

There are variants that accept an `Action<T, int>` object where the second argument is the index and variants for dictionaries that accept `Action<TKey, TValue>` objects.

#### `T Get(...)` and `T GetOrElse(...)`

Given C# enumerable interfaces doesn't have a "get" operator, these can be used so chaining calls is easier:

```
var value = myNumbers
    .Where(i => i < 10)
    .TakeIf(numbers => numbers.Length > 10)
    ?.GetOrElse(0, NOT_FOUND)
    ?? RESPONSE_TOO_LONG;
```

#### `bool IsEmpty(...)` and `bool IsNotEmpty(...)`

Return if the enumerable is (not) empty:

```
if (myNumbers.isNotEmpty()) {
    return myNumbers[0];
}
```
