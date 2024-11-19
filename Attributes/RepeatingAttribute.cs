using System;
using System.Collections.Generic;
using System.Reflection;

namespace ChaosLib.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class RepeatingAttribute : Attribute
    {
        public static readonly Dictionary<Assembly, List<RepeatingAttribute>> RepeatingMethods = new Dictionary<Assembly, List<RepeatingAttribute>>();

        private readonly float _secondsBeforeStart;
        private readonly float _secondsUntilRepeated;
        private MethodInfo _methodInfo;
        private DateTime _nextUpdate;

        static RepeatingAttribute()
        {
            DateTime utcNow = DateTime.UtcNow;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                List<RepeatingAttribute> list = new List<RepeatingAttribute>();
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (MethodInfo mi in type.GetMethods())
                    {
                        RepeatingAttribute ra = mi.GetCustomAttribute<RepeatingAttribute>();
                        if (ra == null)
                            continue;

                        ra.Initalize(mi, utcNow);
                        list.Add(ra);
                    }
                }

                RepeatingMethods.Add(assembly, list);
            }
        }

        public RepeatingAttribute(float secondsBeforeStart, float secondsUntilRepeated)
        {
            if (secondsBeforeStart < 0)
                throw new Exception("Starting time can't be less than 0");

            if (secondsUntilRepeated < 0)
                throw new Exception("Repeat rate has to be greater than 0");

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