using MsOnline.Models;
using MsOnline.Services.Data;
using MsOnline.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MsOnline.Services.Business
{
    //Stanley Backlund & Jacob Hushaw
    //26 January 2020
    //CST-247
    //This is my own code
    public class UserBusinessService
    {
        private UserDataService uds;
        public int Authenticate(User user)
        {
            msLogger.GetInstance().Info("Entering UserBusinessService.Authenticate");

            uds = new UserDataService();
            msLogger.GetInstance().Info("Exiting UserBusinessService.Authenticate");
            return uds.findByUser(user);      

        }

        public User findUserInfo(int id)
        {
            msLogger.GetInstance().Info("Entering UserBusinessService.findUserInfo");
            uds = new UserDataService();
            User returnedUser =  uds.returnUser(id);
            msLogger.GetInstance().Info("Exiting UserBusinessService.findUserInfo");
            return returnedUser;
        }


        public bool Register(User user)
        {
            msLogger.GetInstance().Info("Entering UserBusinessService.Register");
            uds = new UserDataService();
            msLogger.GetInstance().Info("Exiting UserBusinessService.Register");
            if (uds.createUser(user))
                return true;
            return false;
        }
    }
}