# Exceptor v.1.2.2

## Map
* [Exceptor v.1.2.2](#exceptor-v121)
* [Map](#map)
* [Installation](#installation)
* [Features](#features)
	* [Exceptions](#exceptions)
		* [ThrowException](#throwexception)
		* [ThrowIfNull](#throwifnull)
		* [ThrowIfTrue](#throwiftrue)
		* [ThrowIfFalse](#throwiffalse)
		* [ThrowIfNotFind](#throwifnotfind)
	* [Debugs](#debugs)
		* [ThrowDebug](#throwdebug)
		* [ThrowDebugIfFalse](#throwdebugiffalse)
		* [ThrowDebugIfTrue](#throwdebugiftrue)
		* [DebugMods](#debugmods)
	* [Other features](#other-features)
		* [IsNull](#isnull)
		* [IsNumericType](#isnumerictype)

## Installation

Download **Code** folder in your project.

## Features

### Exceptions

#### ThrowException

Throw `exception`.

```csharp
Exceptor.ThrowException(Exception exception);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private GameObject _spawnedObject;

  private void Start() 
  {
    if (TryFindSpawnedObject(out GameObject gameObj)) 
    {
      _spawnedObject = gameObj;
    }
    else
    {
      Exceptor.ThrowException(new NullReferenceException("Object not be found!"));
    }
  }

  private bool TryFindSpawnedObject(out GameObject gameObj) 
  {
    // code...
  }
}
```


#### ThrowIfNull

Throw `exception` if `verifiable` null.

```csharp
Exceptor.ThrowIfNull(object verifiable, Exception exception);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private GameObject _gameObject;

  private void Start() 
  {
    Exceptor.ThrowIfNull(_gameObject, new NullReferenceException("GameObject is null"));
  }

  private void SetGameObject(GameObject gameObj) 
  {
    Exceptor.ThrowIfNull(gameObj, new ArgumentNullException("gameObject", "GameObject is null"));
  }
}
```

#### ThrowIfTrue

Throw `exception` if result of `condition` *true*.

```csharp
Exceptor.ThrowIfTrue(bool condition, Exception exception);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private int _enemiesCount;

  private void Start() 
  {
    Exceptor.ThrowIfTrue(_enemiesCount <= 0, new IndexOutOfRangeException("Enemies count can't be less or equal 0!"));
  }

  private void SetEnemiesCount(int count) 
  {
    Exceptor.ThrowIfTrue(сount <= 0, new ArgumentOutOfRangeException("count", "Count can't be less or equal 0!"));
  }
}
```

#### ThrowIfFalse

Throw `exception` if result of `condition` *false*.

```csharp
Exceptor.ThrowIfFalse(bool condition, Exception exception);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private int _enemiesCount;

  private void Start() 
  {
    Exceptor.ThrowIfFalse(_enemiesCount > 10, new IndexOutOfRangeException("Enemies count can't be more than 10!"));
  }

  private void SetEnemiesCount(int count) 
  {
    Exceptor.ThrowIfFalse(сount > 10, new ArgumentOutOfRangeException("count", "Count can't be more than 10!"));
  }
}
```

#### ThrowIfNotFind

Throw `exception` if `typeForFind` not be found in list `whereFind`.

```csharp
Exceptor.ThrowIfNotFind<T>(T typeForFind, List<T> whereFind, Exception exception) where T : Object;
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private IAttackable _attackable;
  private List<IAttackable> _spawnedAttackables;

  private void Start() 
  {
    Exceptor.ThrowIfNotFind<T>(_attackable, _spawnedAttackables, new NullReferenceException("Attackable not be found in list spawned attackables!"));
  }
}
```

### Debugs

#### DebugMods
| Mode  | Description  |
| ------------ | ------------ |
| `DebugMode.Log`  | Write **log** in console.  |
| `DebugMode.Warning`  |  Write **warning log** in console. |
| `DebugMode.Error`  | Write** error log** in console.  |


#### ThrowDebug

Throw debug `message` with `debug mode`.

```csharp
Exceptor.ThrowDebug(string message, DebugMode mode = DebugMode.Log);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private Sound _sound;

  private void Start() 
  {
    if(_sound == null)
      Exceptor.ThrowDebug("Sound wasn't work!", DebugMode.Warning);
  }
}
```

#### ThrowDebugIfFalse

Throw debug if result of `condition` *false*. If *false* write `message` with `debug mode`.

```csharp
Exceptor.ThrowDebugIfFalse(bool condition, string message, DebugMode mode = DebugMode.Log);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private int _count;

  private void Start() 
  {
    Exceptor.ThrowDebugIfFalse(_count > 0, "Count less or equal 0!", DebugMode.Log);
  }
}
```

#### ThrowDebugIfTrue

Throw debug if result of `condition` *true*. If false write `message` with `debug mode`.

```csharp
Exceptor.ThrowDebugIfTrue(bool condition, string message, DebugMode mode = DebugMode.Log);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private int _count;

  private void Start() 
  {
    Exceptor.ThrowDebugIfTrue(_count <= 0, "Count less or equal 0!", DebugMode.Error);
  }
}
```

### Other features

#### IsNull

`Verifiable` is null?

```csharp
object.IsNull();
Exceptor.IsNull(this object verifiable);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private GameObject _spawnedObject;

  private void Start() 
  {
    if (_spawnedObject.IsNull()) 
    {
      Exceptor.ThrowException(new NullReferenceException("SpanedObject is null"));
    }
    
    if (Exceptor.IsNull(_spawnedObject)) 
    {
      Exceptor.ThrowException(new NullReferenceException("SpanedObject is null"));
    }
  }
}
```

#### IsNumericType

`Object` is a number?

```csharp
object.IsNumericType();
Exceptor.IsNumericType(this object obj);
```

Example:
```csharp
using System;
using UnityEngine;

public class Test : MonoBehaviour {
  private GameObject _spawnedObject;

  private void Start() 
  {
    if (_spawnedObject.IsNumericType()) 
    {
      // code...
    }
    else
    {
      // code...
    }
    
    if (Exceptor.IsNumericType(_spawnedObject)) 
    {
      // code...
    }
    else
    {
      // code...
    }
  }
}
```
