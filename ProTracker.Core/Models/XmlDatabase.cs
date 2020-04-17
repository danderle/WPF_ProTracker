using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace ProTracker.Core
{
    /// <summary>
    /// A static class to handle reading and writing to the xml database
    /// </summary>
    public static class XmlDatabase
    {
        #region Private Fields

        /// <summary>
        /// The path to the projects database xml file
        /// </summary>
        private static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.xml");

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new project with the given name and description
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public static bool CreateProject(string name, string description)
        {
            XElement element = XElement.Load(databasePath);
            bool projectExists = ProjectExists(element, name);
            if (!projectExists)
            {
                element.Add(
                    new XElement("Project",
                    new XElement("Name", name),
                    new XElement("Description", description),
                    new XElement("StartDate", DateTime.Now.ToString("dd/MM/yyyy")),
                    new XElement("LastEdit", DateTime.Now.ToString("dd/MM/yyyy")),
                    new XElement("Status", "Open"),
                    new XElement("TotalHours", 0),
                    new XElement("TotalDays", 1)
                    ));
                element.Save(databasePath);
            }
            return projectExists;
        }

        public static List<ProjectItemControlViewModel> GetProjectList()
        {
            var projectList = new List<ProjectItemControlViewModel>();
            XElement projects = XElement.Load(databasePath);
            foreach(var project in projects.Elements())
            {
                var general = project.Element("General");
                var item = new ProjectItemControlViewModel
                {
                    Name = general.Element("Name").Value,
                    Description = general.Element("Description").Value,
                    Icon = general.Element("Icon").Value,
                    IconRGBbackground = general.Element("RGB").Value,
                    Selected = false
                };
                projectList.Add(item);
            }
            return projectList;
        }
        #endregion


        #region Private Methods

        /// <summary>
        /// Checks if a given project name already exists
        /// </summary>
        /// <param name="element">the loaded xml file</param>
        /// <param name="name">The project name to verify if it exists</param>
        /// <returns></returns>
        private static bool ProjectExists(XElement element, string name)
        {
            var projects = element.Elements();
            foreach (var project in projects)
            {
                string val = project.Element("Name").Value;
                if (val == name)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
