using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class Project
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElementAttribute("ProjectLocation")]
        public string ProjectManager { get; set; }

        [XmlElementAttribute("ProjectManager")]
        public string ProjectLocation { get; set; }

        [XmlElementAttribute("ProjectDescription")]
        public string ProjectDescription { get; set; }

        [XmlElementAttribute("IsActiveProject")]
        public bool IsActiveProject { get; set; }
    }
}
