# CS321_W2D2_StudentAPI
Class project for CS321 Week 2, Day 2.


### Project Instructions
<!-- There should be clear step by step instruction so the material can be asynchronously consumed. This will significantly help our students learn, review and improve your teaching experience.  -->

1. Fork and clone the [CS321_W2D2_StudentAPI](https://github.com/AustinCodingAcademy/CS321_W2D2_StudentAPI) project.
1. Open the solution in Visual Studio.
1. Try building. It will fail. Use the errors as clues.
1. In the Student model, use validation attributes to enforce the following:
   1. FirstName, LastName, BirthDate, Email, and Phone are required.
   1. Email must be a valid email address format.
   1. Phone must be a valid phone number format.
1. You are given the IStudentsService interface and an incomplete implementation of it in StudentsService. The Add() method and a ValidateBirthDate() method are implemented for you. Complete the rest of the implementation.
   1. Make the Get() method return the student specified by the id parameter.
   1. Make the GetAll() method return all students.
   1. Make Update() method do the following:
      1. Find the student specified by the id parameter.
      1. Return null if the student is not found.
      1. Copy the property values of the incoming updatedStudent object to the student you found in the list in the earlier step.
      1. Return the updated student.
    1. Make the Remove() method remove the specified student.
1. You are given a partially implemented StudentsController. Complete the implementation.
   1. Make the necessary changes to the constructor to inject the StudentService.
   1. In the Post() method, add a try/catch block around the call to _studentsService.Add(). In the catch block, add the error message to ModelState.
1. In the Startup class, configure dependency injection for IStudentService.

If you've completed the previous steps correctly, the project should build successfully. Now let's see if you've got the logic right. Run the unit tests in the test project.

Do they all pass? If not, try looking at the failing tests to understand what they're trying to do. Try to deduce what might be wrong. Use the debugger if necessary.

Here are some manual testing ideas:

1. Run the solution.
1. Using Postman, try posting a variety of new Students to your API, covering the following cases:
   1. Post a new, valid student.
   1. Try posting with missing names. You should get a 400 Bad Request.
   1. Try posting a bad email address.
   1. Try posting a bad phone number.
   1. Try using a birth date prior to 2000.
   1. Try using a birth date after 2020.
