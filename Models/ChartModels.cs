using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chart.Mvc.ComplexChart;

using System.Data;
using System.Data.Entity;

using System.Net;

using System.Web.Mvc;
using SeniorProject;
using SeniorProject.DAL;
using SeniorProject.Models;


namespace SeniorProject.Models
{
    public static class ChartModels
    {
        public static LoseContext db = new LoseContext();
        //static String testthis = "Tomuary";
        
        //Gather information for calculations
        //static String UserName = Session["Username"].ToString();

        static double Weight = (from u in db.User
                      where u.Name == "Test"
                      select u.Weight).FirstOrDefault();

        public static IEnumerable<string> Labels
        {
            get
            {
                return new[]
                           {
                               "November",
                               "December",
                               "January",
                               "February",
                               "March",
                               "April"
                           };
            }
        }

        public static IEnumerable<ComplexDataset> Datasets
        {
            get
            {
                return new List<ComplexDataset>
                           {
                               new ComplexDataset
                                   {
                                       Data = { 250, 240, 220, 210, 200, 190 },
                                       Label = "Weight Goal",
                                       FillColor = "rgba(220,220,220,0.2)",
                                       StrokeColor = "rgba(220,220,220,1)",
                                       PointColor = "rgba(220,220,220,1)",
                                       PointStrokeColor = "#fff",
                                       PointHighlightFill = "#fff",
                                       PointHighlightStroke = "rgba(220,220,220,1)",
                                   },
                               new ComplexDataset
                                   {
                                       Data = new List<double> { 255, 240, 225, 215, 204, 196 },
                                       Label = "Actual Weight",
                                       FillColor = "rgba(151,187,205,0.2)",
                                       StrokeColor = "rgba(151,187,205,1)",
                                       PointColor = "rgba(151,187,205,1)",
                                       PointStrokeColor = "#fff",
                                       PointHighlightFill = "#fff",
                                       PointHighlightStroke = "rgba(151,187,205,1)",
                                   }
                           };
            }
        }
    }
}