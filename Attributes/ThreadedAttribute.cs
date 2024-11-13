using System;

namespace ChaosLib.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class ThreadedAttribute : Attribute
    {
    }
}