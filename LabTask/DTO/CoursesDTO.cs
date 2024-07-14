using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTask.DTO
{
    public class CoursesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double CreditHr { get; set; }
        public string Type { get; set; }

    }
}