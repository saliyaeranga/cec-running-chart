using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Project
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [DisplayName("Project Name")]
        [Required(ErrorMessage = "Project Name Required")]
        public string ProjectName { get; set; }

        [DisplayName("Project Manager")]
        [Required(ErrorMessage = "Project Manager Required")]
        public string ProjectManager { get; set; }

        [DisplayName("Project Description")]
        public string ProjectDescription { get; set; }

        [DisplayName("Deactivate Project")]
        public bool IsActiveProject { get; set; }
    }
}