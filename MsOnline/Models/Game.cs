using MsOnline.Services.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Timers;
using System.Web;
using MsOnline.Models;

namespace MsOnline.Models
{
    [DataContract]
    public class Game
    {
        

        [DataMember]
        public MS game { get; set; }
        [DataMember]
        public int bsize { get; set; }
        [DataMember]
        public int flags { get; set; }
        [DataMember]
        public int bombsFlagged { get; set; }
        [DataMember]
        public string playerName { get; set; }
        [DataMember]
        public bool youLost { get; set; }
        [DataMember]
        public string condition { get; set; }
        [DataMember]
        public Stopwatch timer { get; set; }
        [DataMember]
        public int clicks { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public int user_id { get; set; }


        public Game(int size, string username, int user_id) 
        {
            youLost = false;
            playerName = "";
            bombsFlagged = 0;
            //generate game board
            game = new MS(size);
            bsize = size;
            //number of bombs==number of flags
            flags = game.getBombs();
            condition = null;
            timer = new Stopwatch();
            this.user_id = user_id;
            this.username = username;
            clicks = 0;
        }

        //when someone clicks a images
        public bool cell_Click(Cell c)
        {
            if (!timer.IsRunning)
            {
                timer.Start();
            }
            if (c.getVisited() == false && c.isflagged() == false)
            {
                clicks++;
                //clicked a bomb
                if (game.playGame(c) == false)
                {
                    //game lost
                    condition = "You have lost the game";
                    timer.Stop();
                    youLost = true;
                    return false;
                }
            }

            if (winCheck() || flagWinCheck() && youLost != true)
            {
                //game won
                timer.Stop();
                return true;

            }
            return true; 
        }
        //right click 
        public bool Flag_Click(Cell c)
        {
            //
            
            if (!timer.IsRunning)
            {
                timer.Start();
            }
            if (c.getVisited() == false)
                {
                clicks++;
                if (c.isflagged() == true)
                    {
                        c.unFlag();
                        flags++;
                        bombsFlagged++;
                    }
                    else if (flags != 0 && c.isflagged() == false)
                    {
                        c.flagCell();
                        flags--;
                    }
                    else if (flags == 0)
                    {
                        //out of flags
                    }
                    else
                    {

                    }
                }

            //update flag count
            if (winCheck() || flagWinCheck() && youLost != true)
            {
                timer.Stop();
                return true;
            }
            else return false;
            
        }
 
        

        private bool winCheck()
        {

            //checks if all non-live cells have been visited
            for (int i = 0; i < game.getGridSize(); i++)
            {
                for (int j = 0; j < game.getGridSize(); j++)
                {
                    if (!game.getGridOfCells()[j, i].getCLive() && !game.getGridOfCells()[j, i].getVisited())
                    {
                        return false;
                    }
                }
            }
            condition = "You have won the game. youre score was: time: " + timer.Elapsed + " clicks used: " + clicks;


            Score score = new Score(1, timer.Elapsed.ToString(),clicks, username, user_id);
            ScoresDAO sdao = new ScoresDAO();
            sdao.saveScore(score);
            return true;
        }

        private bool flagWinCheck()
        {
            //checks if all live cells have been flagged
            for (int i = 0; i < game.getGridSize(); i++)
            {
                for (int j = 0; j < game.getGridSize(); j++)
                {
                    if (game.getGridOfCells()[j, i].getCLive() && !game.getGridOfCells()[j, i].isflagged())
                    {
                        return false;
                    }
                }
            }
            Score score = new Score(1, timer.Elapsed.ToString(), clicks, username, user_id);
            ScoresDAO sdao = new ScoresDAO();
            sdao.saveScore(score);
            condition = "You have won the game. youre score was: time: " + timer.Elapsed + " clicks used: " + clicks;
            return true;
        }
    
    }
}
