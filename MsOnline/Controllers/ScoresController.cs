using MsOnline.Models;
using MsOnline.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MsOnline.Controllers
{
    public class ScoresController : Controller
    {
        ScoresBusinessService sbs= new ScoresBusinessService();
        // GET: Individual scores
        [LoginAuthorization]
        public ActionResult getScores()
        {
                User currentUser = Session["user"] as User;
                int userid = currentUser.id;
                List<Score> returned = sbs.getScores(userid);
                return View("scores", returned);
        }
        //Gets all scores for home page
        public ActionResult getAllScores()
        {
            
            List<Score> returned = sbs.getAllScores();
            return View("Highscores", returned);
        }

    }
}