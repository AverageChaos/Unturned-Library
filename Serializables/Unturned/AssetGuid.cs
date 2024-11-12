using SDG.Unturned;
using System.Xml;
using System.Xml.Serialization;

namespace ChaosUnturnedLib.Serializables.Unturned
{
    public struct AssetGuid
    {
        [XmlAttribute("AssetName")]
        public readonly string AssetName
        { 
            get => Assets.find(Guid)?.FriendlyName ?? "";
            set => _ = value;
        }

        [XmlAttribute("Guid")]
        public Guid Guid;

        public AssetGuid(string guidString) => Guid = Guid.TryParse(guidString, out Guid guid) ? guid : Guid.Empty;
        public AssetGuid(Guid guid) => Guid = guid;

        public static implicit operator Guid(AssetGuid rValue) => rValue.Guid;
        public static implicit operator AssetGuid(Guid rValue) => new(rValue);
        public static implicit operator string(AssetGuid rValue) => rValue.Guid.ToString();
        public static implicit operator AssetGuid(string rValue) => new(rValue);

        public override readonly bool Equals(object obj) => obj is Guid guid && guid == Guid || obj is AssetGuid aGuid && aGuid.Guid == Guid || obj is string guidStr && Guid.Parse(guidStr) == Guid;

        public override readonly int GetHashCode() => Guid.GetHashCode();
    }
}