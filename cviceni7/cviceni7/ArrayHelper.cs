using System;

namespace cviceni7;

public class Car {
    public void Start() {}
}

internal class ArrayHelper<Item>
{
    public static void Swap(Item[] arr, int idx1, int idx2) {
        Item tmp = arr[idx1];
        arr[idx1] = arr[idx2];
        arr[idx2] = tmp;
    }

    public static Item[] Concat(Item[] arr1, Item[] arr2) {
        Item[] result = new Item[arr1.Length + arr2.Length];
        arr1.CopyTo(result, 0);
        arr2.CopyTo(result, arr1.Length);
        return result;
    }
}


internal class ArrayHelper2
{
    public static void Swap<Item>(Item[] arr, int idx1, int idx2) {
        Item tmp = arr[idx1];
        arr[idx1] = arr[idx2];
        arr[idx2] = tmp;
    }

    public static Item[] Concat<Item>(Item[] arr1, Item[] arr2) {
        Item[] result = new Item[arr1.Length + arr2.Length];
        arr1.CopyTo(result, 0);
        arr2.CopyTo(result, arr1.Length);
        return result;
    }
}