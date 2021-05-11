## IMPORTANT

Read this ENTIRE document before beginning work.

## Project Overview

You will work as a group to create a Quiz app. The user interface already exists. Together, 
you'll implement the backend API for the application.

When you first clone the project, you can run the app. It will use hard-coded sample data so you can get an idea of how it works, but it will show warning messages indicating that it is using sample data. When you have implemented the API, the app will show data from the database and the warning messages will go away.

Review the requirements and instructions given below. Create Trello tasks and divide the work among the class.  If you like, work in pairs. Keep in mind that some tasks must be performed before other can be done. For example, you can't build a Repository without a domain model, and you can't fully implement a Service without the required Repository.

## Collaboration

ONE person from the group will fork this repo from ACA. That person will give everyone else permissions as a "collaborator". From that point on, you will all clone THE ONE repo and your changes will be in the form of __pull requests__. For each change/ticket you will create a new branch and work from there. Remember to always pull the latest from the master branch before you begin a new task.

_Adding a collaborator_
<br />
https://stackoverflow.com/questions/7920320/adding-a-collaborator-to-my-free-github-account

_Creating a new branch_
<br />
`git checkout -b <BRANCH_NAME>`

_Pulling from master_
* Make sure you are on the master branch (`git checkout master`)
* Pull the latest changes (`git pull origin master` or `git pull` for short)


## API Requirements

In order for the UI to work, the following API routes must be implemented and should return the appropriate data. 

1. GET /api/quizzes
1. GET /api/quizzes/{id}

1. GET /api/questions
1. GET /api/questions/{id}
1. POST /api/questions
1. PUT /api/questions/{id}
1. DELETE /api/questions/{id}

1. (OPTIONAL) GET /api/quizzes/random

## Domain Model Design

The domain model should have the following entities with the properties shown. Be careful with spelling. The property names must match the field in the existing database.

#### Answer
Answer should have the following properties:
```
    int Id 
    string Content 
    bool IsCorrect 
    int QuestionId 
    Question Question 
```

#### Question
Question should have the following properties:
```
    int Id
    string QuestionType
    string Prompt
    ICollection<Answer> Answers
    ICollection<QuizQuestion> QuizQuestions
```
#### Quiz
Quiz should have the following properties:
```
    int Id 
    string Title 
    string Description 
    string Instructions 
    ICollection<QuizQuestion> QuizQuestions 
```
#### QuizQuestion
QuizQuestion should have the following properties:
```
    int QuizId
    Quiz Quiz
    int QuestionId
    Question Question
```

#### User
The User domain model is already implemented for you.

## API Model Design

You'll have to create the following ApiModels.

#### Login-related Models
LoginModel, RegistrationModel and UserModel are already implemented for you.

#### QuizModel
```
    int Id 
    string Title 
    string Description 
    string Instructions 
    IEnumerable<QuestionModel> Questions 
```
#### QuestionModel
```
    int Id
    string QuestionType
    string Prompt
    IEnumerable<AnswerModel> Answers
```

#### AnswerModel
```
    int Id 
    int QuestionId 
    string Content 
    bool IsCorrect 
```

Note that there is no equivalent to QuizQuestion in the ApiModels. In the ApiModel, a Quiz directly owns a collection of Questions. In the domain model, there is an intermediate class called QuizQuestion in between Quiz and Question. This allows questions to be "attached" to multiple quizzes. The instructor can elaborate on this pattern.

## Instructions

You are given an existing database with data, and user authentication is already implemented. 

The following tasks need to be completed. 

**Note:** Many of the tasks are intentionally vague, but nearly everything in this project is work you've done before. If
there is anything new, it will be called out in the instructions or in TODOs in the code.

1. Implement the domain model classes in the Core project. The classes already exist, but you must fill in the correct properties according to the design shown above. The names and types are important so the model will match up with the existing database.

1. In the Infrastructure project, implement a QuizRespository based on the given IQuizRepository interface.
   1. The Get() and GetAll() methods should Include() QuizQuestions AND ThenInclude() both Questions and Answers.

1. Implement a QuestionRepository based on the given IQuestionRespository interface.
   1. The Get() and GetAll() methods should Include() the related Answers when returning a Question.
   1. Implement the Add() and Remove() methods as you have in previous projects.
   1. The Update() method needs some special logic that you have not seen before. It will update the Question AND also update all of the related Answers. Here is the implementation for Update:
      ```csharp
        public Question Update(Question updatedItem)
        {
            // retrieve the existing question
            var existingItem = this.Get(updatedItem.Id);
            if (existingItem == null) return null;

            // copy updated property values into the existing question
            _dbContext.Entry(existingItem)
               .CurrentValues
               .SetValues(updatedItem);

            // loop thru all of the answers in the updated question
            foreach(var updatedAnswer in updatedItem.Answers)
            {
                // find the existing answer that corresponds to the updated answer
                var existingAnswer = existingItem.Answers
                .Where(a => a.Id == updatedAnswer.Id)
                .SingleOrDefault();
                // update existing answer from updated answer
                _dbContext.Entry(existingAnswer)
                    .CurrentValues
                    .SetValues(updatedAnswer);
            }

            // save all the changes
            _dbSet.Update(existingItem);
            _dbContext.SaveChanges();
            return existingItem;
        }
      ```
1. Complete the implementation of AppDbContext.  Add DbSet properties for Quizzes and Questions.
1. In AppDbContext.OnModelCreating, add the following line to configure the primary key for the QuizQuestion entity.
   ```csharp
            modelBuilder.Entity<QuizQuestion>()
                .HasKey(qt => new { qt.QuizId, qt.QuestionId });
   ```
1. In the Core project, implement a QuizService based on the given IQuizService interface. 
   1. It should use IQuizRepository to access the database.
   1. Note that only Get() and GetAll() are required for this service. The app does not support adding or updating quizzes.

1. In the Core project, implement a QuestionService based on the given IQuestionService interface. It should use IQuestionRepository to access the database.
   1. This service should follow the same pattern that you've used in other projects. It has all of the standard CRUDL methods.
   1. The Add() and Update() methods should ensure that the Question and Answers are valid.
      1. Each question should have exactly one correct answer. If there are none, or more than one, throw a validation error.

1. In the ApiModels folder, complete the implementation of the ApiModel classes.

1. In the ApiModels folder of the main project, complete the implementation of mapping extensions. See the TODOs in each file.
   1. AnswerMappingExtensions
   1. QuestionMappingExtensions
   1. QuizMappingExtensions

1. In the main project, finish the implementation of QuizzesController. 
   1. Replace the Not Implemented validation errors with the proper implementation.
   1. Anyone should be able to retrieve Quizzes, even if they're not logged in.
   > NOTE: Only two GET actions are needed for this project. Adding/updating/deleting quizzes is not supported.

1. In the main project, finish the implementation of QuestionsController. Replace the Not Implemented validation errors with the proper implementation.
   1. Add() and Update() should catch exceptions and return ModelState errors if exceptions occur.
   1. The POST, PUT, and DELETE actions should only be accessible by authenticated users.
   1. The GET actions can be accessible to anyone, even if they're not logged in.

1. Remember to configure dependency injection of services, repositories, and DbContext in Startup.ConfigureServices.

## Push Yourself Further

1. Implement a GET /api/quizzes/random route that returns a new quiz with 5 randomly selected questions.
   1. You will need to retrieve all questions and then randomly select 5 of them. HINT: Research how to generate random numbers in C#.
   1. The Quiz does not need to be stored in the database. You can just create a new Quiz object and populate the Answers collection with random questions, and then return it.
1. Even further...
   1. Don't allow duplicate questions in a random quiz.

## QA

When all of the above tasks are completed, you should be able to do the following:

1. You should be able to register a new user and sign in.
1. The Quizzes page should list all quizzes in the database, without giving a warning.
1. The Quizzes page should show quizzes even if you are not logged in.
1. You should be able to take a quiz, even if you are not logged in.
1. The Questions page should list all questions in the database, without giving a warning.
1. If you are signed in, you should be able to add a new Question. If you are not, it should show a Forbidden error when attempting to save.
1. If you are signed in, you should be able to update a Question. If not, it should show a Forbidden warning.
1. If add or update a question, it should only be allowed to have one correct answer. You should get a BadRequest warning if there are none or more than one.

