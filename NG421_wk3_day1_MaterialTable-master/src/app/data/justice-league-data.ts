import { JusticeLeagueMember } from '../interfaces/justice-league-member';


const JUSTICE_LEAGUE_MEMBERS: JusticeLeagueMember[] = [
    {
        name: 'Superman',
        alias: 'Clark Kent',
        age: 41,
        currentMember: true,
        memberSince: new Date('10/25/1947'),
        powers: ['Flight', 'Invulnerability', 'Heat Vision']
    },
    {
        name: 'Batman',
        alias: 'Bruce Wayne',
        age: 39,
        currentMember: true,
        memberSince: new Date('10/25/1947'),
        powers: ['None']
    },
    {
        name: 'Wonder Women',
        alias: 'Diana Prince',
        age: 35,
        currentMember: true,
        memberSince: new Date('10/25/1947'),
        powers: ['Flight', 'Invulnerability', 'Lasso of Truth']
    },
    {
        name: 'Green Lantern',
        alias: 'Hal Jordan',
        age: 37,
        currentMember: false,
        memberSince: new Date('04/07/1955'),
        powers: ['Ring']
    },
    {
        name: 'Flash',
        alias: 'Barry Allen',
        age: 29,
        currentMember: false,
        memberSince: new Date('09/06/1962'),
        powers: ['Speed', 'Time Travel']
    },
    {
        name: 'Aquaman',
        alias: 'Arthur Curry',
        age: 31,
        currentMember: true,
        memberSince: new Date('12/06/1986'),
        powers: ['Fish-speak', 'Strength', 'Fast Swimmer']
    },
    {
        name: 'Green Arrow',
        alias: 'Oliver Queen',
        age: 35,
        currentMember: false,
        memberSince: new Date('01/01/1996'),
        powers: ['None']
    },
    {
        name: 'Plastic Man',
        alias: `Patrick O'Brien`,
        age: 40,
        currentMember: true,
        memberSince: new Date('02/16/1978'),
        powers: ['Shape Shifting', 'Regeneration']
    }
];

export {JUSTICE_LEAGUE_MEMBERS};
