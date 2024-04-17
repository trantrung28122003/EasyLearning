﻿using EasyLearing.Infrastructure.Data.Entities;
using EasyLearning.Infrastructure.Data.Entities;

namespace EasyLearning.WebApp.Models
{
    public class CoursesByCategoryViewModel
    {
        public List<Course>? Courses { get; set; }
        public List<Category>? Categories { get; set; }
        public List<CourseDetail>? CourseDetails { get; set; }
    }
}
