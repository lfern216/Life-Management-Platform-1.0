﻿using LifeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace LifeManagement.Controllers
{
    public class QuestionnarieController : Controller
    {
        private SeniorDBEntities db = new SeniorDBEntities();
        
        // GET: Questionnarie
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult collect_questionnarie(QuestionarieViewModel data)
        {

            string name = User.Identity.Name;
            
            var user = db.Users.Where(atr => atr.username.ToLower() == name.ToLower()).FirstOrDefault();

            if (user != null)
            {
                int id = user.Id;

                var sprint0 = new Sprint();
                var g1 = new Goal();
                var g2 = new Goal();
                var g3 = new Goal();


                sprint0.DateFrom = DateTime.Now;
                sprint0.SprintGoal = data.vision;
                sprint0.UserId = id;
                db.Sprints.Add(sprint0);
                db.SaveChanges();

                g1.SprintId = sprint0.Id;
                g1.Description = data.goal_1;
                g1.CategoryId = 1;
                db.Goals.Add(g1);
                db.SaveChanges();


                g2.SprintId = sprint0.Id;
                g2.Description = data.goal_2;
                g2.CategoryId = 2;
                db.Goals.Add(g2);
                db.SaveChanges();

                g3.SprintId = sprint0.Id;
                g3.Description = data.goal_3;
                g3.CategoryId = 3;
                db.Goals.Add(g3);
                db.SaveChanges();

                user.Vision = data.vision;
                user.Statement1 = data.activity_1;
                user.Statement2 = data.activity_2;
                user.Statement3 = data.activity_3;
                user.LifeSuccess = data.determine_success;
                db.SaveChanges();

                TempData["model"] = data;
                TempData.Keep("model");
                return new HttpStatusCodeResult(200); 

            } 
            

            TempData["model"] = data;
            TempData.Keep("model");
            return new HttpStatusCodeResult(200); 
        }

       
        public ActionResult SetupSprint()
        {
            QuestionarieViewModel pulpa = new QuestionarieViewModel();

            
            if (TempData["model"] != null)
            {
                TempData.Keep("model");
                pulpa = (QuestionarieViewModel) TempData["model"];
                return View(pulpa);
            }
            return View(pulpa);
        }


        public ActionResult CollectPassion()
        {
            return View();
        }
    }
}