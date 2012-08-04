using System;
using System.Xml.Serialization;

namespace CECRunningChart.Core
{
    public class User
    {
        #region Public Members

        [XmlElementAttribute("Id")]
        public int Id { get; set; }

        [XmlElementAttribute("FirstName")]
        public string FirstName { get; set; }

        [XmlElementAttribute("LastName")]
        public string LastName { get; set; }

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

        #endregion
    }
}
