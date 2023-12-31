﻿using System.Linq.Expressions;
using FinalAssignment_DataAccess.Data;
using FinalAssignment_DataAccess.Repository.IRepository;
using FinalAssignment_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAssignment_DataAccess.Repository
{
    public class CourseRepository : ICourseRepository<Course>
    {
        private readonly ApplicationDbContext _db;
       
        public CourseRepository(ApplicationDbContext db)
        {
            _db = db;
          
        }
        public void CreateCourse(Course entity)
        {
            _db.Courses.Add(entity);
            _db.SaveChanges();

        }

        public Course GetCourse(int Id)
        {


            return _db.Courses.FirstOrDefault(u => u.Id == Id);



        }

        //public List<Course> GetAllCourses()
        //{
        //    return _db.Courses.ToList();
        //}

        public void RemoveCourse(Course entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }


        public void UpdateCourse(Course entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }



        public List<Course> GetAllCourses()
        {
            return _db.Courses.Where(u => u.IsApproved == false && u.IsRejected == false).ToList();
        }

        public List<Course> GetAll()
        {
            return _db.Courses.ToList();
        }
    }
}
