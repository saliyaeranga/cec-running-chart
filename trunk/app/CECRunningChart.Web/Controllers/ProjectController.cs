using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CECRunningChart.Services.ProjectService;
using CECRunningChart.Web.Models.Project;
using CECRunningChart.Core;
using CECRunningChart.Web.Common;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    [CECAuthorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        #region Private Members

        private IProjectService projectService;

        #endregion

        #region Constructor

        public ProjectController()
        {
            projectService = new ProjectService();
        }

        #endregion

        #region Public Methods

        //
        // GET: /Project/
        [HttpGet]
        public ActionResult Index()
        {
            List<Core.Project> projects = projectService.GetAllActiveProjects();
            var projectsList = from p in projects
                               select new ProjectModel
                               {
                                   Id = p.Id,
                                   ProjectName = p.ProjectName,
                                   ProjectDescription = p.ProjectDescription,
                                   ProjectManager = p.ProjectManager,
                                   IsActiveProject = !p.IsActiveProject
                               };
            List<ProjectModel> model = projectsList.ToList<ProjectModel>();
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return View(projectModel);
            }
            Project project = new Project()
            {
                Id = projectModel.Id,
                ProjectName = projectModel.ProjectName,
                ProjectDescription = projectModel.ProjectDescription,
                ProjectManager = projectModel.ProjectManager,
                IsActiveProject = !projectModel.IsActiveProject
            };
            IProjectService projectService = new ProjectService();
            projectService.AddNewProject(project);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            IProjectService projectService = new ProjectService();
            Core.Project project = projectService.GetProject(id);
            ProjectModel projectModel = new ProjectModel()
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
                ProjectManager = project.ProjectManager,
                IsActiveProject = !project.IsActiveProject
            };

            return View(projectModel);
        }

        [HttpPost]
        public ActionResult Edit(ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return View(projectModel);
            }
            Project project = new Project()
            {
                Id = projectModel.Id,
                ProjectName = projectModel.ProjectName,
                ProjectDescription = projectModel.ProjectDescription,
                ProjectManager = projectModel.ProjectManager,
                IsActiveProject = !projectModel.IsActiveProject
            };
            IProjectService projectService = new ProjectService();
            projectService.UpdateProject(project);

            return RedirectToAction("Index");
        }

        #endregion
    }
}
