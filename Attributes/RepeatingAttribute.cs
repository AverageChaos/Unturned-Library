using System;
using System.Reflection;

namespace ChaosLib.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class RepeatingAttribute : Attribute
    {
        private readonly float _secondsBeforeStart;
        private readonly float _secondsUntilRepeated;
        private MethodInfo _methodInfo;
        private DateTime _nextUpdate;

        public RepeatingAttribute(float secondsBeforeStart, float secondsUntilRepeated)
        {
            if (secondsBeforeStart < 0)
                throw new Exception("Starting time can't be less than 0");

            if (secondsUntilRepeated <= 0.001f)
                throw new Exception("Repeat rate has to be more than 0.001)");

            _secondsBeforeStart = secondsBeforeStart;
            _secondsUntilRepeated = secondsUntilRepeated;
        }

        public void Initalize(MethodInfo methodInfo, DateTime utcNow)
        {
            _methodInfo = methodInfo;
            _nextUpdate = utcNow.AddSeconds(_secondsBeforeStart);
        }

        public void Update(DateTime utcNow)
        {
            if (_nextUpdate > utcNow)
                return;

            _methodInfo.Invoke(null, null);
            _nextUpdate = utcNow.AddSeconds(_secondsUntilRepeated);
        }
    }
}