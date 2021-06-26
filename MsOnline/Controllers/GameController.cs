using MsOnline.Models;
using MsOnline.Services.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MsOnline.Controllers
{
    public class GameController : Controller
    {
        private static Game minesweeper;
        // GET: Difficulty
        [LoginAuthorization]
        public ActionResult SelectDifficulty()
        {
            //Load difficulty page
            //Take difficulty & convert to grid size int
            //return gameboard with grid
            return View("difficulty");
        }
        //POST: Play
        [LoginAuthorization]
        [HttpPost]
        public ActionResult Play(int size)
        {
            if (Session["user"] != null)
            {
                //Take size
                int gameboardSize = size;
                //generate grid based on size
                User currentUser = Session["user"] as User;
                int user_id = currentUser.id;
                string username = currentUser.username;

                minesweeper = new Game(size, username, user_id);
                //return view with grid
                return View("game", minesweeper);
            } else
            {
                return View("difficulty");
            }
        }
        //POST: Play
        [LoginAuthorization]
        [HttpPost]
        public ActionResult Playgame(string cell)
        {
            List<string> cellwh =cell.Split(',').ToList<string>();
            //h,w
            int h = int.Parse(cellwh.ElementAt(0));
            int w = int.Parse(cellwh.ElementAt(1));

            Cell played = minesweeper.game.getGridOfCells()[w,h];

            //play game
            if (played.getVisited() == false)
            {
                bool result = minesweeper.cell_Click(played);
                if (result)
                {
                    return PartialView("__Game", minesweeper);
                }
                else
                {
                    minesweeper.game.EndGrid(minesweeper.bsize);
                    return PartialView("__Game", minesweeper);
                }
            } else
            {
                return PartialView("__Game", minesweeper);
            }
        }
        [LoginAuthorization]
        [HttpPost]
        public ActionResult FlagCell(string cell)
        {
            List<string> cellwh = cell.Split(',').ToList<string>();
            //h,w
            int h = int.Parse(cellwh.ElementAt(0));
            int w = int.Parse(cellwh.ElementAt(1));

            Cell played = minesweeper.game.getGridOfCells()[w, h];

            //play game
            if (played.getVisited() == false)
            {
                bool result = minesweeper.Flag_Click(played);
                if (result == false)
                {
                    return PartialView("__Game", minesweeper);
                }
                else
                {
                    minesweeper.game.EndGrid(minesweeper.bsize);
                    return PartialView("__Game", minesweeper);
                }
            } else
            {
                return PartialView("__Game", minesweeper);
            }
        }

        //saves json version of the gane
        [HttpPost]
        public ActionResult OnSave()
        {
            if (Session["user"] != null)
            {
                GamesDAO gdao = new GamesDAO();
                User currentUser = Session["user"] as User;

                int userid = currentUser.id;
                GameObject gameobject = new GameObject(1, JsonConvert.SerializeObject(minesweeper), userid);

                bool success = gdao.saveGame(gameobject);
                if (success)
                {
                    Response.Write("<script>alert('successfully saved the game')</script>");
                }
                else
                {
                    Response.Write("<script>alert('successfully saved the game')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('you must loggin first to save your games')</script>");
            }
            return View("game", minesweeper);
            
        }
        //renders previously saved game
        [HttpPost]
        public ActionResult OnLoad()
        {
            if (Session["user"] != null)
            {
                GamesDAO gdao = new GamesDAO();
            User currentUser = Session["user"] as User;
            int userid = currentUser.id;
            GameObject gameobject = gdao.loadGame(userid);

            minesweeper = JsonConvert.DeserializeObject<Game>( gameobject.JSONstring);

            }
            else
            {
                Response.Write("<script>alert('you must loggin first to load your games')</script>");
            }
            return View("game", minesweeper);
            
}

    }
}