using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CECRunningChart.Common;

namespace CECRunningChart.Web.Models.User
{
    public class UserModel
    {
        #region Public Properties

        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(100, ErrorMessage = "First name can not have more than 100 characters")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [MaxLength(100, ErrorMessage = "Last name can not have more than 100 characters")]
        public string LastName { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage="Username is required.")]
        [MaxLength(20, ErrorMessage = "First name can not have more than 20 characters")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [MaxLength(20, ErrorMessage = "Password can not have more than 20 characters")]
        public string Password { get; set; }

        [DisplayName("NIC Number")]
        [MaxLength(10, ErrorMessage = "NIC can not have more than 10 characters")]
        public string NICNumber { get; set; }

        [DisplayName("Role")]
        public UserRole Role { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        [DisplayName("Is Active User")]
        public bool IsActiveUser { get; set; }

        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }

        #endregion

        #region Public methods

        public IEnumerable<SelectListItem> GetUserRoleOptions()
        {
            List<SelectListItem> options = new List<SelectListItem>(3)
            {
                new SelectListItem() { Selected = (Role == UserRole.Admin), Text = StringEnum.GetEnumStringValue(UserRole.Admin), 
                    Value = ((int)UserRole.Admin).ToString()},
                new SelectListItem() { Selected = (Role == UserRole.RunningChartInspector), Text = StringEnum.GetEnumStringValue(UserRole.RunningChartInspector), 
                    Value = ((int)UserRole.RunningChartInspector).ToString() },
                new SelectListItem() { Selected = (Role == UserRole.RunningChartOperator), Text = StringEnum.GetEnumStringValue(UserRole.RunningChartOperator), 
                    Value = ((int)UserRole.RunningChartOperator).ToString() }
            };

            return options;
        }

        #endregion
    }
}