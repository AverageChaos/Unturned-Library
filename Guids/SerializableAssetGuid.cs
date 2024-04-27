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

        public static implicit operator Guid(SerializableAssetGuid rValue) => rValue.Guid;
        public static implicit operator SerializableAssetGuid(Guid rValue) => new SerializableAssetGuid(rValue);
        public static implicit operator string(SerializableAssetGuid rValue) => rValue.GuidString;
        public static implicit operator SerializableAssetGuid(string rValue) => new SerializableAssetGuid(rValue);

        public override bool Equals(object obj) => (obj is Guid guid && guid == Guid) || (obj is SerializableGuid sGuid && sGuid.Guid == Guid) || (obj is string guidStr && guidStr == GuidString);

        public override int GetHashCode() => Guid.GetHashCode();
    }
}
