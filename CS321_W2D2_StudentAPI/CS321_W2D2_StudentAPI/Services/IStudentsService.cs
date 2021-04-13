using System;
using System.Collections.Generic;
using CS321_W2D2_StudentAPI.Models;

namespace CS321_W2D2_StudentAPI.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student student);
        Student Update(Student student);
        void Remove(Student student);
    }
}
