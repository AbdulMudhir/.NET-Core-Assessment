﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _NET_Core_Assessment.Models.PostModels
{
    public class TeacherClassPostModel
    {
        [Required]
        public int TeacherId { get; set; }
        [Required]
        public int ClassId { get; set; }
    }
}
