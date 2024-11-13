# Chaos's Unturned Library
### Features
- Attributes:
	- Repeating - Used to mark a method to be repeated, requires implementation on the plugin:
	```csharp
	private static readonly List<RepeatingAttribute> RepeatingMethods = new List<RepeatingAttribute>();
 
	protected override void Load()
	{
	    DateTime utcNow = DateTime.UtcNow;
	    foreach (Type type in Assembly.GetTypes())
	    {
		foreach (MethodInfo mi in type.GetMethods())
		{
		    RepeatingAttribute ra = mi.GetCustomAttribute<RepeatingAttribute>();
		    if (ra != null)
		    {
		        ra.Initalize(mi, utcNow);
		        RepeatingMethods.Add(ra);
		    }
		}
	    }
	}

	public void Update()
	{
		DateTime utcNow = DateTime.UtcNow;
		foreach (RepeatingAttribute repeatingMethod in RepeatingMethods)
			repeatingMethod.Update(utcNow);
	}
	```
- Serializables:
	- SerializableDictionary - An XML serializable dictionary.
	- AssetGuid - A Guid that is automatically marked with an asset's name.
