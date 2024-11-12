using System;
using System.Reflection;

namespace ChaosLib.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class RepeatingAttribute : Attribute
    {
        public float SecondsBeforeStart;
        public float SecondsUntilRepeated;

        private MethodInfo MethodInfo;
        private DateTime NextUpdate;

        public RepeatingAttribute(float secondsBeforeStart, float secondsUntilRepeated)
        {
            if (secondsBeforeStart < 0)
                throw new Exception("Starting time can't be less than 0");

            if (secondsUntilRepeated <= 0.001f)
                throw new Exception("Repeat rate has to be more than 0.001)");

            SecondsBeforeStart = secondsBeforeStart;
            SecondsUntilRepeated = secondsUntilRepeated;
        }

        public void Initalize(MethodInfo methodInfo, DateTime nextUpdate)
        {
            MethodInfo = methodInfo;
            NextUpdate = nextUpdate;
        }

        public void Update(DateTime utcNow)
        {
            if (NextUpdate > utcNow)
                return;

            MethodInfo.Invoke(null, null);
            NextUpdate = utcNow.AddSeconds(SecondsUntilRepeated);
        }
    }
}