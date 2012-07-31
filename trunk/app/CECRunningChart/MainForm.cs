using System;
using System.Windows.Forms;

namespace CECRunningChart
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProjectForm newProject = new NewProjectForm();
            newProject.MdiParent = this;
            newProject.Show();
        }

        private void editProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProjectForm editProject = new EditProjectForm();
            editProject.MdiParent = this;
            editProject.Show();
        }

        private void addVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewVehicleForm newVehicle = new NewVehicleForm();
            newVehicle.MdiParent = this;
            newVehicle.Show();
        }

        private void editVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditVehicleForm editVehicle = new EditVehicleForm();
            editVehicle.MdiParent = this;
            editVehicle.Show();
        }

        private void addPumpStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPumpStationForm newPumpStation = new NewPumpStationForm();
            newPumpStation.MdiParent = this;
            newPumpStation.Show();
        }

        private void editPumpStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPumpStationForm editPumpStation = new EditPumpStationForm();
            editPumpStation.MdiParent = this;
            editPumpStation.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUserForm newUser = new NewUserForm();
            newUser.MdiParent = this;
            newUser.Show();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUserForm editUser = new EditUserForm();
            editUser.MdiParent = this;
            editUser.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
