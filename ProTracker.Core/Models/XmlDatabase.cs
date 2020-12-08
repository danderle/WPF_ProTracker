using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ProTracker.Core
{
    /// <summary>
    /// A static class to handle reading and writing to the xml database
    /// </summary>
    public static class XmlDatabase
    {
        #region Private Fields

        private static string applicationDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProTracker");

        /// <summary>
        /// The path to the projects database xml file
        /// </summary>
        private static string databasePath = Path.Combine(applicationDataDirectory, "Database.xml");

        #endregion

        /// <summary>
        /// Default static constructor
        /// </summary>
        static XmlDatabase()
        {
            if(!Directory.Exists(applicationDataDirectory))
            {
                Directory.CreateDirectory(applicationDataDirectory);
            }
            if (!File.Exists(databasePath))
            {
                using (var writer = XmlWriter.Create(databasePath))
                {
                    writer.WriteStartDocument();
                }
                var emptyList = new List<Project>();
                XmlDatabase.Serialize(emptyList);
            }
        }

        #region Public Methods

        /// <summary>
        /// Serialize the <see cref="Project"/> object to the database xml file
        /// </summary>
        /// <param name="project"></param>
        static public void Serialize(List<Project> projects)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var xmlSettings = new XmlWriterSettings
            {
                ConformanceLevel = ConformanceLevel.Auto,
                Indent = true,
            };
            XmlSerializer serializer = new XmlSerializer(typeof(List<Project>));
            using (TextWriter writer = new StreamWriter(databasePath))
            using (XmlWriter xmlWriter = XmlWriter.Create(writer, xmlSettings))
            {
                serializer.Serialize(xmlWriter, projects, ns);
            }
        }

        /// <summary>
        /// Desearilizes the database into a list of <see cref="Project"/> objects
        /// </summary>
        /// <returns></returns>
        public static List<Project> GetProjectList()
        {
            
            List<Project> projects;
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Project>));
            using (TextReader reader = new StreamReader(databasePath))
            {
                object obj = deserializer.Deserialize(reader);
                projects = (List<Project>)obj;
            }
            
            return projects;
        }

        /// <summary>
        /// Checks if a given project name already exists
        /// </summary>
        /// <param name="element">the loaded xml file</param>
        /// <param name="name">The project name to verify if it exists</param>
        /// <returns></returns>
        public static bool ProjectExists(List<Project> projects, string name)
        {
            foreach (var project in projects)
            {
                string val = project.GeneralData.Name;
                if (val == name)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
