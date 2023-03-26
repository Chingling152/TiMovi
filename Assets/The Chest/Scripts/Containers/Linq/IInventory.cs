using System;
using TheChest.Containers.Generics;

namespace TheChest.Containers.Linq
{
    public static class IInventoryExtensions
    {
        public static T[] SearchItemsByName<T>(this IInventory<T> slot, string name, int amount = 10)
        {
            throw new NotImplementedException();
        }

        public static int FirstIndexOf<T>(this IInventory<T> slot,T item)
        {
            throw new NotImplementedException();
        }

        public static T[] Where<T>(this IInventory<T> slot, Predicate<Func<bool,T>> predicate, int amount = -1)
        {
            throw new NotImplementedException();
        }
    }
}
