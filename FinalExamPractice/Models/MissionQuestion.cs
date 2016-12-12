﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalExamPractice.Models
{
    [Table("MissionQuestion")]
        public class MissionQuestion
        {
        [Key]
        public int MissionQuestionID { get; set; }
        public int MissionID { get; set; }
        public int UserID { get; set; }
        public string MissionQuestionQuestion { get; set; }
        public string MissionAnswer { get; set; }
        
        }
}