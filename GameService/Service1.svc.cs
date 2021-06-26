using MsOnline.Models;
using MsOnline.Services.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameService
{
    
    public class Service1 : IService1
    {
        public GameObject ShowGames(string uid)
        {
            GamesDAO GDS = new GamesDAO();
            return GDS.getGame(uid);

        }

        public Score ShowScore(string uid)
        {
            ScoresDAO sds = new ScoresDAO();
            return sds.getScore(uid);
        }

        public List<Score> ShowScores()
        {
            ScoresDAO sds = new ScoresDAO();
            return sds.getScores();
        }

        public string test()
        {
            return "test test test";
        }
    }
}
