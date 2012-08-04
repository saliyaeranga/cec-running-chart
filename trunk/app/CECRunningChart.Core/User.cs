using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    [DataContract]
    public class User
    {
        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("UserName")]
        public string UserName { get; set; }

        [XmlElementAttribute("Password")]
        public string Password { get; set; }

        [XmlElementAttribute("NICNumber")]
        public string NICNumber { get; set; }

        [XmlElementAttribute("RoleId")]
        public int RoleId { get; set; }

        [XmlElementAttribute("RoleName")]
        public string RoleName { get; set; }

        [XmlElementAttribute("IsActiveUser")]
        public bool IsActiveUser { get; set; }

        [XmlElementAttribute("DateAdded")]
        public DateTime DateAdded { get; set; }
    }
}
