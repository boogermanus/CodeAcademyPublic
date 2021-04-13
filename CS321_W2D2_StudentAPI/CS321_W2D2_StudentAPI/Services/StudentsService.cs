using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W2D2_StudentAPI.Models;

namespace CS321_W2D2_StudentAPI.Services
{
    public class StudentsService : IStudentsService
    {
        // seed some initial Student data
        private List<Student> _students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2010, 1, 1),
                Email = "john.doe@test.com",
                Phone = "555.555.5555"
            },
            new Student
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                BirthDate = new DateTime(2012, 1, 1),
                Email = "jane.smith@test.com",
                Phone = "555.555.5555"
            }
        };
        // keep track of next id number
        private int _nextId = 3;

        public Student Add(Student student)
        {
            ValidateBirthDate(student);
            // assign an id (and then increment _nextId for next time)
            student.Id = _nextId++;
            // store in the list of students
            _students.Add(student);
            // return the new Student with Id filled in
            return student;
        }

        private void ValidateBirthDate(Student student)
        {
            if (student.BirthDate > DateTime.Now)
            {
                throw new ApplicationException("BirthDate cannot be in the future.");
            }
            if (DateTime.Today.Year - student.BirthDate.Year > 18)
            {
                throw new ApplicationException("You're too old to be a student!");
            }
        }

        public Student Get(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student Update(Student updatedStudent)
        {
            // get the Student object in the current list with this id 
            var currentStudent = _students.FirstOrDefault(s => s.Id == updatedStudent.Id);

            // return null if item to update isn't found
            if (currentStudent == null)
                return null;

            // copy the property values from the updated student into the current student object
            currentStudent.Email = updatedStudent.Email;
            currentStudent.Phone = updatedStudent.Phone;
            currentStudent.BirthDate = updatedStudent.BirthDate;
            currentStudent.FirstName = updatedStudent.FirstName;
            currentStudent.LastName = updatedStudent.LastName;

            return currentStudent;
        }

        public void Remove(Student student)
        {
            _students.Remove(student);
        }
    }
}
