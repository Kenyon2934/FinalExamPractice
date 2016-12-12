using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FinalExamPractice.Models;
using FinalExamPractice.DAL;

namespace FinalExamPractice.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext() : base("MissionContext")
        {

        }
        public DbSet<MissionQuestion> MissionQuestions { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }

        public DbSet<MissionQuestionsMission> MissionQuestionsMissions { get; set; }


    }
}