using System;
using System.Collections.Generic;

#nullable disable

namespace aspnetcore5demo.Models
{
    public partial class VwDepartmentCourseCount
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? CourseCount { get; set; }
    }
}
