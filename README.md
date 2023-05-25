# Exceptor

## Installation

Download Exceptor.cs in your project.

## Features
### ThrowIfNull

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

### ThrowIfTrue

Throw `exception` if result of `condition` true.

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

### ThrowIfFalse

Throw `exception` if result of `condition` false.

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

### ThrowException

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

### IsNull

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

### IsNumericType

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
