using System.IO;
using System.Xml.Serialization;

namespace Weeky.Model
{
    class AppStateFile
    {
        private readonly string _filename;

        private AppStateFile(string filename)
        {
            _filename = filename;
        }

        public AppState Load()
        {
            if (!File.Exists(_filename))
            {
                Save(new AppState());
            }
            using(var stream = new FileStream(_filename, FileMode.Open, FileAccess.Read))
            {
                var serializer = CreateSerializer();
                return (AppState) serializer.Deserialize(stream);
            }
        }

        public void Save(AppState state)
        {
            using (var stream = new FileStream(_filename, FileMode.Create, FileAccess.Write))
            {
                var serializer = CreateSerializer();
                serializer.Serialize(stream, state);
            }
        }

        private static XmlSerializer CreateSerializer()
        {
            return new XmlSerializer(typeof(AppState));
        }

        public static AppStateFile Create(string filename)
        {
           return new AppStateFile(filename);
        }
    }
}
