using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChaosUnturnedLib.Serializables
{
    [XmlRoot("Dictionary")]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable where TKey : notnull
    {
        public XmlSchema? GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
                return;

            var keySerializer = new XmlSerializer(typeof(TKey));
            var valueSerializer = new XmlSerializer(typeof(TValue));

            reader.ReadStartElement();

            while (reader.IsStartElement("Item"))
            {
                reader.ReadStartElement("Item");

                try
                {
                    TKey key = (TKey)keySerializer.Deserialize(reader);
                    TValue value = (TValue)valueSerializer.Deserialize(reader);

                    Add(key, value);
                }
                catch (Exception)
                {
                }

                reader.ReadEndElement();
            }

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            var keySerializer = new XmlSerializer(typeof(TKey));
            var valueSerializer = new XmlSerializer(typeof(TValue));

            foreach (var kvp in this)
            {
                writer.WriteStartElement("Item");
                keySerializer.Serialize(writer, kvp.Key);
                valueSerializer.Serialize(writer, kvp.Value);
                writer.WriteEndElement();
            }
        }
    }
}