using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public static class Exceptor
{
    /// <summary>
    /// Throw exception if verifiable null.
    /// </summary>
    /// <param name="verifiable"></param>
    /// <param name="exception"></param>
    public static void ThrowIfNull(object verifiable, Exception exception)
    {
        if (verifiable.IsNull())
            ThrowException(exception);
    }

    /// <summary>
    /// Throw exception if result of condition false.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    public static void ThrowIfFalse(bool condition, Exception exception)
    {
        if (!condition)
            ThrowException(exception);
    }

    /// <summary>
    /// Throw debug with mode.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="mode"></param>
    public static void ThrowDebug(string message, DebugMode mode = DebugMode.Log)
    {
        ThrowDebugWithMode(message, mode);
    }

    /// <summary>
    /// Throw debug with mode if result of condition False.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="message"></param>
    /// <param name="mode"></param>
    public static bool ThrowDebugIfFalse(bool condition, string message, DebugMode mode = DebugMode.Log)
    {
        if (!condition)
        {
            ThrowDebug(message, mode);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Throw exception if result of condition true.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="exception"></param>
    public static void ThrowIfTrue(bool condition, Exception exception)
    {
        if (condition)
            ThrowException(exception);
    }

    /// <summary>
    /// Throw debug with mode if result of condition true.
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="message"></param>
    /// <param name="mode"></param>
    public static bool ThrowDebugIfTrue(bool condition, string message, DebugMode mode = DebugMode.Log)
    {
        if (condition)
        {
            ThrowDebug(message, mode);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Throw exception if typeForFind not be found in list whereFind. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="typeForFind"></param>
    /// <param name="whereFind"></param>
    /// <param name="exception"></param>
    public static void ThrowIfNotFind<T>(T typeForFind, List<T> whereFind, Exception exception) where T : Object
    {
        ThrowIfNull(typeForFind, new ArgumentNullException("typeForFind", "Type for find is null"));
        ThrowIfNull(whereFind, new ArgumentNullException("whereFind", "Types where find is null"));

        if (!whereFind.Contains(typeForFind))
            ThrowException(exception);
    }

    /// <summary>
    /// Object is a null?
    /// </summary>
    /// <param name="verifiable"></param>
    /// <returns>bool</returns>
    /// <exception cref="ArgumentException"></exception>
    public static bool IsNull(this object verifiable)
    {
        if (verifiable.IsNumericType())
            throw new InvalidOperationException("Can't check on null numeric type! Please don't use numeric type!");

        return verifiable == null;
    }

    /// <summary>
    /// Object is a number?
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>bool</returns>
    public static bool IsNumericType(this object obj)
    {
        if (obj.GetType() == null)
        {
            return false;
        }

        TypeCode typeCode = Type.GetTypeCode(obj.GetType());

        switch (typeCode)
        {
            case TypeCode.Byte:
            case TypeCode.SByte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.Decimal:
            case TypeCode.Double:
            case TypeCode.Single:
                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// Throw exception.
    /// </summary>
    /// <param name="exception"></param>
    public static void ThrowException(Exception exception)
    {
        ThrowExceptionIfExceptionNull(exception);

        throw exception;
    }

    private static void ThrowExceptionIfExceptionNull(Exception exception)
    {
        if (exception == null)
        {
            ThrowException(new ArgumentNullException("Exception is null"));
        }
    }

    private static void ThrowDebugWithMode(string message, DebugMode mode = DebugMode.Log)
    {
        ThrowIfNull(message, new ArgumentNullException("Message is empty! Please write message."));

        switch (mode)
        {
            case DebugMode.Log:
                Debug.Log(message);
                break;
            case DebugMode.Warning:
                Debug.LogWarning(message);
                break;
            case DebugMode.Error:
                Debug.LogError(message);
                break;
            default:
                break;
        }
    }
}
