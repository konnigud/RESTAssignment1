using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    /// <summary>
    /// Represents a single course.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Name of the course.
        /// Example: "Web Services"
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id for the course, unique per semester.
        /// Example: "T-514-VEFT"
        /// </summary>
        public string TemplateID { get; set; }

        /// <summary>
        /// Unique Id for the course.
        /// Example: 1
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// StartDate of the course.
        /// Example: 2015-08-17
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Enddate for the course
        /// Example: 2015-11-08
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}