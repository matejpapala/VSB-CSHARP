using System;
using System.ComponentModel.Design;

namespace cviceni7;

internal class KeyNotFoundException<KeyType> : Exception
{
    public KeyType Key {get;}
    public KeyNotFoundException(KeyType key, string Message) : base (Message){
        Key = key;
    }

}
