﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CECRunningChart.Common;

namespace CECRunningChart.Web.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NICNumber { get; set; }
        public UserRole Role { get; set; }
        public bool IsActiveUser { get; set; }
    }
}