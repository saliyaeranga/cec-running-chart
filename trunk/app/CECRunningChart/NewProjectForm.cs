using System;
using System.Windows.Forms;
using CECRunningChart.Core;
using CECRunningChart.Services.ProjectService;

namespace CECRunningChart
{
    public partial class NewProjectForm : Form
    {
        #region Constructor

        public NewProjectForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            Project newProject = new Project()
            {
                ProjectName = txtProjectName.Text,
                ProjectManager = txtProjectManager.Text,
                ProjectDescription = txtProjectDescription.Text,
                IsActiveProject = !chkDeactivate.Checked
            };
            
            IProjectService projectService = new ProjectService();
            bool isProjectAdded = projectService.AddNewProject(newProject);

            if (isProjectAdded)
            {
                ClearForm();
                MessageBox.Show("New project added successfully.", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        #endregion

        #region Private Members

        private void ClearForm()
        {
            txtProjectName.Text = string.Empty;
            txtProjectManager.Text = string.Empty;
            txtProjectDescription.Text = string.Empty;
            chkDeactivate.Checked = false;
            projectErrorProvider.Clear();
            txtProjectName.Focus();
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(txtProjectName.Text))
            {
                isValid = false;
                projectErrorProvider.SetError(txtProjectName, "Project Name is Required");
            }
            if (string.IsNullOrWhiteSpace(txtProjectManager.Text))
            {
                isValid = false;
                projectErrorProvider.SetError(txtProjectManager, "Project Manager is Required");
            }
            if (string.IsNullOrWhiteSpace(txtProjectDescription.Text))
            {
                isValid = false;
                projectErrorProvider.SetError(txtProjectDescription, "Project Description is Required");
            }

            return isValid;
        }

        #endregion
    }
}
