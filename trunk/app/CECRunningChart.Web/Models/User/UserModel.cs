using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CECRunningChart.Common;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CECRunningChart.Web.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage="Username is required.")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("NIC Number")]
        public string NICNumber { get; set; }

        [DisplayName("Role")]
        public UserRole Role { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        [DisplayName("Is Active User")]
        public bool IsActiveUser { get; set; }

        [DisplayName("Date Added")]
        public DateTime DateAdded { get; set; }

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
    }
}