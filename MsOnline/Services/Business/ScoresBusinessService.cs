using MsOnline.Models;
using MsOnline.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsOnline.Services.Business
{
    
    public class ScoresBusinessService
    {
        private ScoresDAO sda = new ScoresDAO();
        //gets individual scores
        public List<Score> getScores(int id)
        {
            return sda.getUserScores(id);

        }
        //gets all users scores
        internal List<Score> getAllScores()
        {
            return sda.getScores();
        }
    }
}