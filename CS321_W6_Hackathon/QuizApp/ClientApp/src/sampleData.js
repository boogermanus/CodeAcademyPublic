const questions = [
  {
    id: 1,
    prompt: '_____ is used to permit loose coupling within an application.',
    answers: [
      {
        content: '>  REST',
        isCorrect: false,
      },
      {
        content: '>  Dependency injection',
        isCorrect: true,
      },
      {
        content: '>  The MVC pattern',
        isCorrect: false,
      },
    ],
  },
  {
    id: 2,
    prompt:
      'In an MVC app, business/domain logic and validation are typically contained in _____ . ',
    answers: [
      {
        content: '>  a service',
        isCorrect: true,
      },
      {
        content: '>  Startup.Configure()',
        isCorrect: false,
      },
      {
        content: '>  a controller',
        isCorrect: false,
      },
    ],
  },
  {
    id: 3,
    prompt:
      'In an MVC app, logic relating to data access is most appropriately placed in _____ .',
    answers: [
      {
        content: '>  a service layer',
        isCorrect: false,
      },
      {
        content: '>  a repository layer',
        isCorrect: true,
      },
      {
        content: '>  the domain models',
        isCorrect: false,
      },
    ],
  },
  {
    id: 4,
    prompt: 'In RESTful terms, information that can be named is _____ .',
    answers: [
      {
        content: '>  a table row',
        isCorrect: false,
      },
      {
        content: '>  an entity',
        isCorrect: false,
      },
      {
        content: '>  a resource',
        isCorrect: true,
      },
    ],
  },
  {
    id: 5,
    prompt: 'To check for validation errors, we can use the _____ object .',
    answers: [
      {
        content: '>  ModelState',
        isCorrect: true,
      },
      {
        content: '>  ModelError',
        isCorrect: false,
      },
      {
        content: '>  ModelValidate',
        isCorrect: false,
      },
    ],
  },
  {
    id: 6,
    prompt: 'Entity Framework is an example of an _____ .',
    answers: [
      {
        content: '>  API',
        isCorrect: false,
      },
      {
        content: '>  ORM',
        isCorrect: true,
      },
      {
        content: '>  CLI',
        isCorrect: false,
      },
    ],
  },
  {
    id: 7,
    prompt:
      'A method that gets called whenever an object is instantiated is _____ .',
    answers: [
      {
        content: '>  Startup.ConfigureServices()',
        isCorrect: false,
      },
      {
        content: '>  a constructor',
        isCorrect: true,
      },
      {
        content: '>  a service',
        isCorrect: false,
      },
    ],
  },
  {
    id: 8,
    prompt:
      'Inheriting from ______ enables Entity Framework to link our objects to database tables.',
    answers: [
      {
        content: '>  DBSet',
        isCorrect: false,
      },
      {
        content: '>  DBContext',
        isCorrect: true,
      },
      {
        content: '>  ModelBuilder',
        isCorrect: false,
      },
    ],
  },
  {
    id: 9,
    prompt:
      'Which of the three choices is NOT a category of problem addressed by dependency injection?',
    answers: [
      {
        content: '>  unit testing',
        isCorrect: false,
      },
      {
        content: '>  scalability',
        isCorrect: true,
      },
      {
        content: '>  maintainability',
        isCorrect: false,
      },
    ],
  },
  {
    id: 10,
    prompt: 'The core data in our application is defined in _____ .',
    answers: [
      {
        content: '>  Domain models',
        isCorrect: true,
      },
      {
        content: '>  ApiModels',
        isCorrect: false,
      },
      {
        content: '>  JSON',
        isCorrect: false,
      },
    ],
  },
  {
    id: 11,
    prompt:
      'Which is the correct syntax for this controller method to get a specific post?',
    answers: [
      {
        content:
          '```csharp\n    HttpGet("{id}")]\n       public IActionResult Get(int id)\n       {\n           // look up post by id\n           var post = _postService.Get(id);\n           // if not found, return 404 NotFound \n           if (post == null) return NotFound();\n           // otherwise return 200 OK and the Post\n           return Ok(id);\n       }\n    ```',
        isCorrect: false,
      },
      {
        content:
          '```csharp\n    HttpGet("{id}")]\n       public IActionResult Get(int id)\n       {\n           // look up post by id\n           var post = _postService.Get(id);\n           // if not found, return 404 NotFound \n           if (post == null) return NotFound();\n           // otherwise return 200 OK and the Post\n           return Ok(post);\n       }\n    ```',
        isCorrect: false,
      },
      {
        content:
          '```csharp\n    HttpGet("{id}")]\n       public IActionResult Get(int id)\n       {\n           // look up post by id\n           var post = _postService.Get(id);\n           // if not found, return 404 NotFound \n           if (post == null) return NotFound();\n           // otherwise return 200 OK and the Post\n           return Ok(post);\n       }\n    ```',
        isCorrect: false,
      },
    ],
  },
  {
    id: 12,
    prompt:
      'Which of the items below is a correct example of an Interface in C#?',
    answers: [
      {
        id: 1,
        content: 'public interface Foo { void bar(); }',
        isCorrect: true,
      },
      {
        id: 1,
        content: 'public int Foo { void bar(); }',
        isCorrect: false,
      },
      {
        id: 1,
        content: 'public interface Foo [ void bar(); ]',
        isCorrect: false,
      },
    ],
  },
  {
    id: 13,
    prompt:
      'Where do you configure services for dependency injection in an ASP.NET Core project?',
    answers: [
      {
        id: 1,
        content: 'Startup.Configure()',
        isCorrect: false,
      },
      {
        id: 1,
        content: 'DependencyInjection.Configure()',
        isCorrect: false,
      },
      {
        id: 1,
        content: 'Startup.ConfigureServices()',
        isCorrect: true,
      },
    ],
  },
];
const quizzes = [
  {
    id: 1,
    title: 'Super Tough Quiz',
    description: 'Some markdown content that describes the quiz.',
    instructions:
      'Some more markdown content that can provide instructions, tips, etc.',
    questions: [
      questions[0],
      questions[1],
      questions[2],
      questions[3],
      questions[4],
      questions[5],
      questions[6],
    ]
  },
  {
    id: 2,
    title: 'Another Quiz',
    description: 'Some markdown content that describes the quiz.',
    instructions:
      'Some more markdown content that can provide instructions, tips, etc.',
    questions: [
      questions[7],
      questions[8],
      questions[9],
      questions[10],
      questions[11],
      questions[12],
    ]
  }
];
export default {
  quizzes: quizzes,
  questions: questions,
};
