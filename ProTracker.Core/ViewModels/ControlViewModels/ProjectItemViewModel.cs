using System;
using System.Windows.Input;

namespace ProTracker.Core
{
    /// <summary>
    /// A view model for each project item in overview project list
    /// </summary>
    public class ProjectItemViewModel : BaseViewModel
    {
        #region Public Field

        /// <summary>
        /// The project object which will get serialized to xml
        /// </summary>
        public Project XmlProject;

        #endregion

        #region Public properties

        /// <summary>
        /// The general data view model
        /// </summary>
        public GeneralDataItemViewModel GeneralData { get; set; }

        /// <summary>
        /// The main data view model
        /// </summary>
        public MainDataItemViewModel MainData { get; set; } = new MainDataItemViewModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectItemViewModel()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="selectedCommand"></param>
        public ProjectItemViewModel(Project loadedProject, ICommand selectedCommand)
        {
            XmlProject = loadedProject;
            GeneralData = new GeneralDataItemViewModel(XmlProject, selectedCommand);
            MainData = new MainDataItemViewModel(XmlProject);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves the view model data into the main object which will get serialized to xml database
        /// </summary>
        public void PrepareToSerialize()
        {
            XmlProject.SetGeneralData(GeneralData);
            XmlProject.SetMainData(MainData);
        }

        #endregion
    }
}
