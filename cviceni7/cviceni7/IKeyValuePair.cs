using System;

namespace cviceni7;

public interface IKeyValuePair<KeyType, ValueType>
{
    KeyType Key {get;}
    ValueType Value {get;}

}
