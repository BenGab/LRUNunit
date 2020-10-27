using System;

namespace UnitTestsLRUKelementArray
{
    public static class ReferenceGuard
    {
        public static T GuardNotNull<T>(this T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException(nameof(T));
            }

            return value;
        }

        public static void NotNull<T>(this T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(T));
            }
        }
    }
}
