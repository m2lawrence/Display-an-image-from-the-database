﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SaveImageToDB
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["mikesConString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
            SqlCommand cmd = new SqlCommand("spGetImageById", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter paramId = new SqlParameter()
            {
            ParameterName = "@Id",
            Value = Request.QueryString["Id"]
            };
            cmd.Parameters.Add(paramId);

            con.Open();
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            string strBase64 = Convert.ToBase64String(bytes);
            Image1.ImageUrl = "data:Image/png;base64," + strBase64;
            }
        }
    }
}