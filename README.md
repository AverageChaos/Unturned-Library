# Chaos's Unturned Library
### Features
- Attributes:
	- Repeating - Used to mark a method to be repeated, requires implementation on the plugin:
	```csharp
	public void Update()
	{
		DateTime utcNow = DateTime.UtcNow;
		foreach (RepeatingAttribute repeatingMethod in RepeatingAttribute.RepeatingMethods[Assembly])
		    repeatingMethod.Update(utcNow);
	}
	```
- Serializables:
	- SerializableDictionary - An XML serializable dictionary.
	- AssetGuid - A Guid that is automatically marked with an asset's name.
