using SDG.Unturned;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace ChaosLib.Serializables.Unturned
{
    /// <summary>
    /// A <see cref="System.Guid"/> that is marked with an <see cref="Asset">Asset's</see> name.
    /// </summary>
    public struct AssetGuid
    {
        [XmlAttribute("AssetName")]
        public string AssetName
        {
            get => Assets.find(Guid)?.FriendlyName;
            set => _ = value;
        }

        [XmlAttribute("Guid")]
        public Guid Guid;

        public AssetGuid(string guidString) => Guid = Guid.TryParse(guidString, out Guid guid) ? guid : Guid.Empty;
        public AssetGuid(Guid guid) => Guid = guid;

        public static implicit operator Guid(AssetGuid rValue) => rValue.Guid;
        public static implicit operator AssetGuid(Guid rValue) => new AssetGuid(rValue);
        public static implicit operator string(AssetGuid rValue) => rValue.Guid.ToString();
        public static implicit operator AssetGuid(string rValue) => new AssetGuid(rValue);

        public override bool Equals(object obj) => (obj is Guid guid && guid == Guid) || (obj is AssetGuid aGuid && aGuid.Guid == Guid) || (obj is string guidStr && Guid.Parse(guidStr) == Guid);
        
        public override int GetHashCode() => Guid.GetHashCode();
    }
}