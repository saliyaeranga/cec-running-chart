using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CECRunningChart.Services.ProjectService;

namespace CECRunningChart
{
    public partial class EditProjectForm : Form
    {
        public EditProjectForm()
        {
            InitializeComponent();
        }

        private void EditProjectForm_Load(object sender, EventArgs e)
        {
            LoadProjects();
        }

        private void LoadProjects()
        {
            IProjectService projectService = new ProjectService();
            List<Core.Project> activeProjects = projectService.GetAllActiveProjects();
            activeProjects.Insert(0, new Core.Project() { Id = 0, ProjectName = "- Select Project -" });
            comProjects.DataSource = activeProjects;
            comProjects.DisplayMember = "ProjectName";
            comProjects.ValueMember = "Id";
        }
    }
}
