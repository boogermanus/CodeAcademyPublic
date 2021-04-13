using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using CS321_W2D2_StudentAPI.Controllers;
using CS321_W2D2_StudentAPI.Services;
using CS321_W2D2_StudentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W2D2_StudentAPI.Tests
{
    public class StudentsControllerTests
    {
        [Fact]
        public void Post_ShouldReturnBadRequestWhenBirthDateIsInTheFuture()
        {
            Assert.Throws<ApplicationException>(() => TryPost(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2999, 1, 1), // in the future
                Email = "test@test.com",
                Phone = "555-555-5555"
            }));
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenBirthDateIsTooEarly()
        {
            Assert.Throws<ApplicationException>(() => TryPost(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1899, 1, 1), // too old
                Email = "test@test.com",
                Phone = "555-555-5555"
            }));
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenEmailIsInvalid()
        {
            Assert.False(IsValid(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2020, 1, 1),
                Email = "a.bad.email", // bad email
                Phone = "555-555-5555"
            }));
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenPhoneIsInvalid()
        {
            Assert.False(IsValid(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2010, 1, 1),
                Email = "test@test.com",
                Phone = "abc" // bad phone
            }));
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenFirstNameIsMissing()
        {
            Assert.False(IsValid(new Student
            {
                // FirstName = "John", // missing
                LastName = "Doe", 
                BirthDate = new DateTime(2010, 1, 1),
                Email = "test@test.com",
                Phone = "555-555-5555"
            }));
        }

        [Fact]
        public void Post_ShouldReturnBadRequestWhenLastNameIsMissing()
        {
            Assert.False(IsValid(new Student
            {
                FirstName = "John",
                // LastName = "Doe", // missing
                BirthDate = new DateTime(2010, 1, 1),
                Email = "test@test.com",
                Phone = "555-555-5555"
            }));
        }

        [Fact]
        public void Post_ShouldReturnOkWhenStudentIsValid()
        {
            Assert.True(IsValid(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(2009, 1, 1),
                Email = "test@test.com",
                Phone = "555-555-5555"
            }));
        }

        private IActionResult TryPost(Student student)
        {
            // arrange - create a new controller
            var controller = new StudentsController(new StudentsService());

            // act - call Post() with given student 
            return controller.Post(student);
        }

        private bool IsValid(Student student)
        {
            var context = new ValidationContext(student, null, null);
            var results = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(student, context, results, true);
            return valid;
        }
    }
}
