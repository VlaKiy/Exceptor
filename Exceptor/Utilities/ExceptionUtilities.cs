using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Exceptor.Utilities
{
    /// <summary>
    /// All utilities for throwing exceptions.
    /// </summary>
    public static class ExceptionUtilities
    {
        /// <summary>
        /// Throw exception.
        /// </summary>
        /// <param name="exception"></param>
        public static void ThrowException(Exception exception)
        {
            exception.ThrowIfNull("exception", "Exception is null");

            throw exception;
        }

        /// <summary>
        /// Throw ArgumentNullException if object null.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void ThrowIfNull(this object obj, string paramName = null, string message = null)
        {
            bool isNumber = obj.IsNumber();
            isNumber.ThrowIfValid("Can't verify number on null.");

            bool isBoolean = obj.IsBoolean();
            isBoolean.ThrowIfValid("Can't verify boolean on null.");

            if (obj == null)
                ThrowException(new ArgumentNullException(paramName, message));
        }

        /// <summary>
        /// Throw ArgumentNullException if element of object array is null.
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="message"></param>
        public static void ThrowIfNull(this object[] objects, string message = null)
        {
            if (objects == null)
                ThrowException(new ArgumentNullException("objects", "Objects is null!"));

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].ThrowIfNull(null, message);
            }
        }

        /// <summary>
        /// Throw ArgumentOutOfRangeException if value is not in range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void ThrowIfOutOfRange<T>(this T value, T min, T max, string paramName = null, string message = null) where T : IComparable
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                ThrowException(new ArgumentOutOfRangeException(paramName, message));
        }

        /// <summary>
        /// Throw ArgumentException if condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        public static void ThrowIfValid(this bool condition, string message = null, string paramName = null)
        {
            if (condition)
                ThrowException(new ArgumentException(message, paramName));
        }

        /// <summary>
        /// Throw ArgumentException if condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        public static void ThrowIfInvalid(this bool condition, string message = null, string paramName = null)
        {
            if (!condition)
                ThrowException(new ArgumentException(message, paramName));
        }

        /// <summary>
        /// Throw exception if typeForFind not be found in list whereFind. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeForFind"></param>
        /// <param name="whereFind"></param>
        /// <param name="message"></param>
        /// <param name="paramName"></param>
        public static void ThrowIfNotFound<T>(this T typeForFind, List<T> whereFind, string message = null, string paramName = null) where T : Object
        {
            typeForFind.ThrowIfNull("typeForFind", "Type for find is null");
            whereFind.ThrowIfNull("whereFind", "Where find list is null");

            if (message == null)
                message = "Object not found in list!";

            bool isContain = whereFind.Contains(typeForFind);

            isContain.ThrowIfInvalid(message, paramName);
        }
    }
}