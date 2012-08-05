using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CECRunningChart.Core;
using CECRunningChart.Services.ProjectService;
using CECRunningChart.Web.Common;
using CECRunningChart.Web.Helpers;
using CECRunningChart.Web.Models.Project;

namespace CECRunningChart.Web.Controllers
{
    [Authorize]
    [CECAuthorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        #region Private Members

        private readonly IProjectService projectService;

        #endregion

        #region Constructor

        public ProjectController()
        {
            projectService = new ProjectService();
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var projects = projectService.GetAllActiveProjects();
                List<ProjectModel> model = ModelMapper.GetProjectModelList(projects);
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
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
                return View(projectModel);

            try
            {
                var project = ModelMapper.GetProject(projectModel);
                projectService.AddNewProject(project);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var project = projectService.GetProject(id);
                ProjectModel projectModel = ModelMapper.GetProjectModel(project);
                return View(projectModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
                return View(projectModel);

            try
            {
                Project project = ModelMapper.GetProject(projectModel);
                projectService.UpdateProject(project);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var project = projectService.GetProject(id);
                ProjectModel projectModel = ModelMapper.GetProjectModel(project);
                projectModel.IsActiveProject = project.IsActiveProject;
                return View(projectModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var project = projectService.GetProject(id);
                ProjectModel projectModel = ModelMapper.GetProjectModel(project);
                projectModel.IsActiveProject = project.IsActiveProject;
                return View(projectModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                projectService.DeleteProject(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
