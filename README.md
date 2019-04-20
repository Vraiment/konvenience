[![Build Status](https://travis-ci.com/Vraiment/konvenience.svg?branch=master)](https://travis-ci.com/Vraiment/konvenience)

Konvenience
-------------

*Konvenience* is a small library aimed to implement a small subset of Kotlin's standard "scope functions".

## How to use it

Just add the namespace to your project:

```
using Konvenience;
```
## How to use them?

All of these are extension methods, so they even work with `null` values! Just remember, for all these functions the second argument cannot be null.

### `T Also<T>(this T, Action<T>)`

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

### `TResult Let<T, TResult>(this T, Func<T, TResult> function)`

Executes the given function with the input object and returns its result.

Example use case:

```
// Transform a value that shouldn't be null and get a default in case of null
var result = myObject?.let(transform) ?? DEFAULT_VALUE;
```

### `T Take(Reference|Value)(If|Unless)<T>(this T, Predicate<T>)`

These are a group of extension methods that are slightly different but all basically return the input object if the predicate returns true (for `TakeReferenceIf` and `TakeValueIf`) or false (for `TakeReferenceUnless` or `TakeValueUnless`) for that object otherwise returns `null`.

Given how `class` and `struct` handle `null` differently, there are two versions of these extension methods: for references (`TakeReferenceIf`, `TakeReferenceUnless`) and for values (`TakeValueIf`, `TakeReferenceUnless`).

Example use case:

```
// Get a default value if the input object is not valid
var validString = myString.takeIf(s => s.Length > 10) ?? DEFAULT_STRING;
```
