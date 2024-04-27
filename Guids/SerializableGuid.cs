using System;
using System.Xml.Serialization;

namespace UnturnedSerializables.Guids
{
    public class SerializableGuid
    {
        public Guid Guid { get; private set; }

        [XmlAttribute("Guid")]
        public string GuidString
        {
            get => Guid.ToString();
            set => Guid = Guid.TryParse(value, out Guid guid) ? guid : default;
        }

        public SerializableGuid() { }
        public SerializableGuid(string guidString) => GuidString = guidString;
        public SerializableGuid(Guid guid) => Guid = guid;

        public static implicit operator Guid(SerializableGuid rValue) => rValue.Guid;
        public static implicit operator SerializableGuid(Guid rValue) => new SerializableGuid(rValue);
        public static implicit operator string(SerializableGuid rValue) => rValue.GuidString;
        public static implicit operator SerializableGuid(string rValue) => new SerializableGuid(rValue);

        public override bool Equals(object obj) => (obj is Guid guid && guid == Guid) || (obj is SerializableGuid sGuid && sGuid.Guid == Guid) || (obj is string guidStr && guidStr == GuidString);

        public override int GetHashCode() => Guid.GetHashCode();
    }
}