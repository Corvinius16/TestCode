using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public struct MyGuid : IComparable, IComparable<MyGuid>, IEquatable<MyGuid>
{
    public string Value;

    private MyGuid(string value)
    {
        Value = value;
    }

    public static implicit operator MyGuid(Guid guid)
    {
        return new MyGuid(guid.ToString());
    }

    public static implicit operator Guid(MyGuid serializableGuid)
    {
        return new Guid(serializableGuid.Value);
    }
    public static bool operator ==(MyGuid guid1,MyGuid guid2)
    {
        return guid1.Equals(guid2);
    }

    public static bool  operator !=(MyGuid guid1, MyGuid guid2)
    {
        return !(guid1 == guid2);
    }

    public int CompareTo(object value)
    {
        if (value == null)
            return 1;
        if (!(value is MyGuid))
            throw new ArgumentException("Must be SerializableGuid");
        MyGuid guid = (MyGuid)value;
        return guid.Value == Value ? 0 : 1;
    }

    public int CompareTo(MyGuid other)
    {
        return other.Value == Value ? 0 : 1;
    }

    public bool Equals(MyGuid other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return (Value != null ? Value.GetHashCode() : 0);
    }

    public override string ToString()
    {
        return (Value != null ? new Guid(Value).ToString() : string.Empty);
    }
}