export default {
    id: 1,
    title: 'Super Tough Quiz',
    description: 'Some markdown content that describes the quiz.',
    instructions:
      'Some more markdown content that can provide instructions, tips, etc.',
    questions: [
      {
        id: 1,
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
          id: 2,
          prompt:
            'Where do you configure services for dependency injection in an ASP.NET Core project?',
          answers: [
            {
              id: 1,
              content: 'Startup.Configure()',
              isCorrect: true,
            },
            {
              id: 1,
              content: 'DependencyInjection.Configure()',
              isCorrect: false,
            },
            {
              id: 1,
              content: 'Startup.ConfigureServices()',
              isCorrect: false,
            },
          ],
        },
      ],
  };




