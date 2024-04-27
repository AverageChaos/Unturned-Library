using SDG.Unturned;
using System;
using System.Xml.Serialization;

namespace UnturnedSerializables.Guids
{
    public class SerializableAssetGuid : SerializableGuid
    {
        [XmlAttribute("Name")] public string Name => Assets.find(Guid)?.FriendlyName;

        public SerializableAssetGuid() : base() { }
        public SerializableAssetGuid(string guidString) : base(guidString) { }
        public SerializableAssetGuid(Guid guid) : base(guid) { }
    }
}
