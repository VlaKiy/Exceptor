# Exceptor v2.1.0

## Map
* [Exceptor v2.1.0](#exceptor-v210)
* [Map](#map)
* [Installation](#installation)
* [Using](#using)
* [Features](#features)
	* [ExceptionUtilities](#exceptionutilities)
		* [ThrowException](#throwexception)
		* [ThrowIfNull](#throwifnull)
		* [ThrowIfNull (Array)](#throwifnull-array)
		* [ThrowIfOutOfRange](#throwifoutofrange)
		* [ThrowIfValid](#throwifvalid)
		* [ThrowIfValid (Array)](#throwifvalid-array)
		* [ThrowIfInvalid](#throwifinvalid)
		* [ThrowIfInvalid (Array)](#throwifinvalid-array)
		* [ThrowIfNotFound](#throwifnotfound)
	* [DebugUtilities](#debugutilities)
		* [DebugMods](#debugmods)
		* [DebugMessage](#debugmessage)
		* [DebugIfValid](#debugifvalid)
		* [DebugIfInvalid](#debugifinvalid)
	* [DefiningUtilities](#definingutilities)
		* [IsNumber](#isnumber)
		* [IsBoolean](#isboolean)

## Advantages

- **Fast** throwing exceptions.
- Write **less** code.
- **Easy** to use

## Installation

Download **Exceptor** folder in your project.

## Using

Use `Exceptor.Utilities` namespace in your project:
```csharp
using Exceptor.Utilities;
```

Basically, features are used like this:
```csharp
private GameObject _gameObject;

_gameObject.ThrowIfNull("gameObject", "GameObject is null");
```
Or like this:
```csharp
private GameObject _gameObject;

ExceptorUtilities.ThrowIfNull(_gameObject, "gameObject", "GameObject is null");
```

## Features

### ExceptionUtilities

#### ThrowException

Throw `exception`.

```csharp
ExceptionUtilities.ThrowException(Exception exception);
```

**Example:**
```csharp
_gameObject.ThrowException(new ArgumentNullException("Object not be found!"));
```

------------


#### ThrowIfNull

Throw `ArgumentNullException` if `object` null.

```csharp
ExceptionUtilities.ThrowIfNull(this object obj, string paramName = null, string message = null)
```

**Example:**
```csharp
_gameObject.ThrowIfNull("gameObject", "GameObject is null!");
```

------------


#### ThrowIfNull (Array)

Throw `ArgumentNullException` if one of the `objects` array is **null**.

```csharp
ExceptionUtilities.ThrowIfNull(params object[] objects)
```

**Example:**
```csharp
private void DoSomething(GameObject first, GameObject second, Transform third) 
{
	ThrowIfNull(first, second, third);
}
```

------------


#### ThrowIfOutOfRange

Throw `ArgumentOutOfRangeException` if `value` is not in `range`.

```csharp
ExceptionUtilities.ThrowIfOutOfRange<T>(
	this T value, 
	T min, T max, 
	string paramName = null,
	string message = null
) where T : IComparable
```

**Example:**
```csharp
_count.ThrowIfOutOfRange(0, int.MaxValue, "count", "Count can't be less than 0!");
```

------------


#### ThrowIfValid

Throw `ArgumentException` if `condition` is `true`.

```csharp
ExceptionUtilities.ThrowIfValid(
	this bool condition, 
	string message = null, 
	string paramName = null
)
```

**Example:**
```csharp
bool _hasObject = true;

_hasObject.ThrowIfValid("_hasObject", "You can't have object!");
```

------------


#### ThrowIfValid (Array)

Throw `ArgumentException` if one of the `conditions` is **true**.

```csharp
ExceptionUtilities.ThrowIfValid(params bool[] conditions)
```

**Example:**
```csharp
private void DoSomething(bool first, bool second, bool third) 
{
	ThrowIfValid(first, second, third);
}
```

------------


#### ThrowIfInvalid

Throw `ArgumentException` if `condition` is `false`.

```csharp
ExceptionUtilities.ThrowIfInvalid(
	this bool condition, 
	string message = null, 
	string paramName = null
)
```

**Example:**
```csharp
bool _hasObject = false;

_hasObject.ThrowIfInvalid("_hasObject", "You should have object!");
```

------------


#### ThrowIfInvalid (Array)

Throw `ArgumentException` if one of the `conditions` is **false**.

```csharp
ExceptionUtilities.ThrowIfInvalid(params bool[] conditions)
```

**Example:**
```csharp
private void DoSomething(bool first, bool second, bool third) 
{
	ThrowIfInvalid(first, second, third);
}
```

------------


#### ThrowIfNotFound

Throw `ArgumentException` if `typeForFind` not be found in list `whereFind`. 

```csharp
ExceptionUtilities.ThrowIfNotFound<T>(
	this T typeForFind, 
	List<T> whereFind, 
	string message = null, 
	string paramName = null
) where T : Object
```

**Example:**
```csharp
_obj.ThrowIfNotFound(_objects, "Obj in list of objects not be found!", "_obj");
```

------------


### DebugUtilities

#### DebugMods
| Mode  | Description  |
| ------------ | ------------ |
| `DebugMode.Log`  | Write **log** in console.  |
| `DebugMode.Warning`  |  Write **warning log** in console. |
| `DebugMode.Error`  | Write **error log** in console.  |


------------


#### DebugMessage

Messaging `debug` with `DebugMode`.

```csharp
DebugUtilities.DebugMessage(
	string message, 
	DebugMode mode = DebugMode.Log
)
```

**Example:**
```csharp
DebugUtilities.DebugMessage("Hello, world", DebugMode.Log);
DebugUtilities.DebugMessage("Hello, world", DebugMode.Warning);
DebugUtilities.DebugMessage("Hello, world", DebugMode.Error);
```

------------


#### DebugIfValid

Messaging `debug` with `DebugMode` if `condition` is `true`.

```csharp
DebugUtilities.DebugIfValid(
	this bool condition, 
	string message, 
	DebugMode debugMode = DebugMode.Log
)
```

**Example:**
```csharp
bool _isStayed = true;

_isStayed.DebugIfValid("Enemy is stayed!", DebugMode.Log);
```

------------


#### DebugIfInvalid

Messaging `debug` with `DebugMode` if `condition` is `false`.

```csharp
DebugUtilities.DebugIfInvalid(
	this bool condition, 
	string message, 
	DebugMode debugMode = DebugMode.Log
)
```

**Example:**
```csharp
bool _isStayed = false;

_isStayed.DebugIfInvalid("Enemy is not stayed!", DebugMode.Error);
```

------------


### DefiningUtilities

#### IsNumber

`Object` is a **number**?

```csharp
DefiningUtilities.IsNumber(this object obj);
```

**Example:**
```csharp
GameObject _gameObject = new GameObject();
int _count = 50;

_gameObject.IsNumber(); // return FALSE.
_count.IsNumber(); // return TRUE;
```

If `object` is **null** - return `false`.

------------


#### IsBoolean

`Object` is a **boolean**?

```csharp
DefiningUtilities.IsBoolean(this object obj)
```

**Example:**
```csharp
GameObject _gameObject = new GameObject();
bool _isStayed = true;

_gameObject.IsBoolean(); // return FALSE.
_isStayed.IsBoolean(); // return TRUE;
```
If `object` is **null** - return `false`.
