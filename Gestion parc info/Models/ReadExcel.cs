﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ReadExcel.Class;

namespace ReadExcel.Models
{
    public class ReadExcel
    {
        
        
        public HttpPostedFileBase file { get; set; }
    }
}