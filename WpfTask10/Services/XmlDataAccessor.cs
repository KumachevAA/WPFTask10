using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WpfTask10.Models;

namespace WpfTask10.Services
{
    public class XmlDataAccessor : IDataAccessor<List<UserModel>>
    {
        public string Path { get; set; } = ".\\Phonebook.xml";

        public List<UserModel> Load()
        {
            if (!File.Exists(Path))
                return new List<UserModel>();

            using FileStream stream = File.OpenRead(Path);
            XmlSerializer serializer = new(typeof(List<UserModel>));
            object data = serializer.Deserialize(stream);

            if (data is List<UserModel> list)
            {
                return list;
            }
            else
            {
                return new List<UserModel>();
            }
        }

        public void Save(List<UserModel> data)
        {
            using FileStream stream = File.Create(Path);
            XmlSerializer serializer = new(typeof(List<UserModel>));
            serializer.Serialize(stream, data);
            stream.Flush();
        }
    }
}
