using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalExamPractice.Models
{

    public class MissionQuestionsMission
    {
        [Key]
        public int MissionID { get; set; }
        public string MissionName { get; set; }
        public string MissionPresidentName { get; set; }
        public string MissionAddress { get; set; }
        public string MissionLanguage { get; set; }
        public string MissionClimate { get; set; }
        public string MissionDominantReligion { get; set; }
        public string MissionFlagorSymbol { get; set; }

        public int? MissionQuestionID { get; set; }
        public int? UserID { get; set; }
        public string MissionQuestionQuestion { get; set; }
        public string MissionAnswer { get; set; }


    }
}