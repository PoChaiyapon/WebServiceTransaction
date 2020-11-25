﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;

namespace WebServiceSQL2_Server
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //set config
        [WebMethod]
        public void setConfig(string _dbserv, string _dbname, string _dbuser, string _dbpass)
        {
            DB.SetConfig(_dbserv, _dbname, _dbuser, _dbpass);
        }

        //Check connection
        [WebMethod]
        public bool Check_Connection()
        {
            return DB.Check_SqlConnect();
        }

        //Return DataSet
        [WebMethod]
        public DataSet execSQL(string sql)
        {
            return DB.execSQL(sql);
        }
    }
}
