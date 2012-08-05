using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.Project
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [DisplayName("Project Name")]
        [Required(ErrorMessage = "Project Name required")]
        [MaxLength(200, ErrorMessage = "Project name can not have more than 200 characters")]
        public string ProjectName { get; set; }

        [DisplayName("Project Manager")]
        [Required(ErrorMessage = "Project manager required")]
        [MaxLength(100, ErrorMessage = "Project manager can not have more than 100 characters")]
        public string ProjectManager { get; set; }

        [DisplayName("Project Location")]
        [Required(ErrorMessage = "Project Location required")]
        [MaxLength(500, ErrorMessage = "Location can not have more than 500 characters")]
        public string ProjectLocation { get; set; }

        [DisplayName("Project Description")]
        public string ProjectDescription { get; set; }

        [DisplayName("Deactivate Project")]
        public bool IsActiveProject { get; set; }
    }
}