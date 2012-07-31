using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace CECRunningChart.Core
{
    [DataContract]
    public class Project
    {
        public Project()
        {

        }

        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElementAttribute("ProjectManager")]
        public string ProjectManager { get; set; }

        [XmlElementAttribute("ProjectDescription")]
        public string ProjectDescription { get; set; }

        public string Location { get; set; }

        [XmlElementAttribute("IsActiveProject")]
        public bool IsActiveProject { get; set; }
    }
}
