﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontUserApplication.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }
        public string UserContact { get; set; }

        public string UserPassword { get; set; }

        public string UserConfirmPassword { get; set; }
        public string UserCity { get; set; }

    }
}