using System;

namespace cviceni7;

internal class TreeMap<KeyType, ValueType> where KeyType : IComparable<KeyType>
{
    private Node<KeyType, ValueType> root;
    public ValueType this[KeyType key] {
        get{
            return Get(key, root);
        }
        set{
            if(root is null) {
                root = new Node<KeyType, ValueType> {Key = key, Value = value};
            }
            Set(key, value, root);
        }
    }
    private ValueType Get(KeyType key, Node<KeyType, ValueType> current) {
        if(current == null) {
            throw new KeyNotFoundException<KeyType>(key, "Chybova hlaska");
        }
        if(current.Key.CompareTo(key) == 0) {
            return current.Value;
        }
        if(key.CompareTo(current.Key) < 0) {
            return Get(key, current.Left);
        }
        return Get(key, current.Right);
    }

    private void Set(KeyType key, ValueType value, Node<KeyType, ValueType> current)
    {
        if(key.CompareTo(current.Key) < 0) {
            if(current.Left is not null) {
                Set(key, value, current.Left);
            }
            current.Left = new Node<KeyType, ValueType>() {Key = key, Value = value};   
        } else if(key.CompareTo(current.Key) > 0) {
            if(current.Right is not null) {
                Set(key, value, current.Right);
            }
            current.Right = new Node<KeyType, ValueType>() {Key = key, Value = value};
        } else {
            current.Value = value;
        }
    }
}
