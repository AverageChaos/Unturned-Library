# Chaos's Unturned Library
### Features
- Attributes:
	- Repeating - Used to mark a method to be repeated, requires implementation on the plugin:
	```csharp
	static Main()
	{
	    RepeatingAttribute.InitializeAttributes(Assembly);
	}

	public void Update()
	{
		DateTime utcNow = DateTime.UtcNow;
		foreach (RepeatingAttribute repeatingMethod in RepeatingAttribute.RepeatingMethods[Assembly])
		    repeatingMethod.Update(utcNow);
	}
	```
- DataTypes:
  - PlayerID - Struct that contains a player's SteamID and CharacterID, can be automatically converted to either.
- Extensions:
	- BarricadeExt
 		- CreateBarricade - Creates a new Barricade from an asset's guide.
	- BarricadeManagerExt
 		- DestroyBarricade - Destroys the Barricade at a transform, and invokes an action before destroying the Barricade that allows the event to be canceled.
	- DictionaryExt
 		- GetOrAdd - Gets the value of a key or adds the specified default
		- GetOrAddDefault - Gets the value of a key or adds the default(value)
		- GetOrAddNew - Gets the value of a key or adds new value()
	- PlayerInventoryExt
 		- EInventoryPage - Enum containing names and indexes for all inventory pages
	- PlayerSavedataExt
 		- ReadBlock - Same as PlayerSavedata.ReadBlock(), but takes a full path instead of PlayerID
		- WriteBlock - Same as PlayerSavedata.WriteBlock(), but takes a full path instead of PlayerID
- Serializables:
	- SerializableDictionary - An XML serializable dictionary.
	- AssetGuid - A Guid that is automatically marked with an asset's name.
