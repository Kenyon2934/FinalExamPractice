using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalExamPractice.Models;
using FinalExamPractice.DAL;

namespace FinalExamPractice.Controllers
{
    public class MissionsController : Controller
    {
        private MissionContext db = new MissionContext(); 
        // GET: Missions
        public ActionResult Index()
        {

            IEnumerable<Mission> sqlAllMissions = db.Database.SqlQuery<Mission>("Select " +
                "M.MissionID, M.MissionName, M.MissionPresidentName, M.MissionAddress, M.MissionLanguage, " +
                "M.MissionClimate, M.MissionDominantReligion, M.MissionFlagorSymbol from Mission M");
/*
            IEnumerable<MissionQuestionsMission> sqlAllMissions2 = db.Database.SqlQuery<MissionQuestionsMission>("Select " +
                "M.MissionID, M.MissionName, M.MissionPresidentName, M.MissionAddress, M.MissionLanguage, " +
                "M.MissionClimate, M.MissionDominantReligion, M.MissionFlagorSymbol, MQ.MissionQuestionID, " +
                "MQ.UserID, MQ.MissionQuestionQuestion, MQ.MissionAnswer from Mission M inner join " +
                "MissionQuestion MQ on M.MissionID = MQ.MissionID ");
            */
            return View(sqlAllMissions);
        }

        public ActionResult SingleMission(int? type)
        {

           if (type != null)
           {
            IEnumerable<MissionQuestionsMission> sqlSelectedMissionWithQuestions =
                db.Database.SqlQuery<MissionQuestionsMission>("Select " +
                "M.MissionID, M.MissionName, M.MissionPresidentName, M.MissionAddress, M.MissionLanguage, " +
                "M.MissionClimate, M.MissionDominantReligion, M.MissionFlagorSymbol, MQ.MissionQuestionID, " +
                "MQ.UserID, MQ.MissionQuestionQuestion, MQ.MissionAnswer from Mission M full outer join " +
                "MissionQuestion MQ on M.MissionID = MQ.MissionID " +
                "WHERE M.MissionID ='" + type + "'");

            return View(sqlSelectedMissionWithQuestions);
           }
           else
           {
               return RedirectToAction("Index");
           }

        }

        [HttpPost]
        public ActionResult NewMissionQuestion(int type, FormCollection NewQuestion)
        {

            MissionQuestion NewQuestionData = new MissionQuestion();

            NewQuestionData.MissionQuestionQuestion = NewQuestion["NewQuestion"].ToString();
            NewQuestionData.MissionID = type;

            db.MissionQuestions.Add(NewQuestionData);
            db.SaveChanges();

            return RedirectToAction("SingleMission", new { type = type });
        }

        [HttpPost]
        public ActionResult NewMissionAnswer(int type, int QID, FormCollection fNewAnswer)
        {



            MissionQuestion NewAnswerData = db.MissionQuestions.Find(QID);
            string sAnswer = fNewAnswer["NewAnswer"].ToString() ;
            NewAnswerData.MissionAnswer = sAnswer;

            db.SaveChanges();

            return RedirectToAction("SingleMission", new { type = type });
        }


    }
}