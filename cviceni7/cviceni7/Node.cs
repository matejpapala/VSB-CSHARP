using System;

namespace cviceni7;

internal class Node<KeyType, ValueType> : IKeyValuePair<KeyType, ValueType>
{
    public required KeyType Key {get; set;}
    public required ValueType Value {get; set;}

    public Node<KeyType, ValueType> Left{get;set;}
    public Node<KeyType, ValueType> Right{get;set;}
}
