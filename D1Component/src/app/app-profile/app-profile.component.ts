import { Component, OnInit } from '@angular/core';
import { user } from './user';
import { User } from 'src/models/User';

@Component({
  selector: 'app-profile',
  templateUrl: './app-profile.component.html',
  styleUrls: ['./app-profile.component.css']
})
export class AppProfileComponent {

  // basic way; creates a generic object with properties
  public user: any = {
    profileImage: 'https://images.pexels.com/photos/45201/kitty-cat-kitten-pet-45201.jpeg',
    name: 'Jordan Woodruff',
    location: 'Lubbock, TX',
    reviews: 33
  };

  // this will display the same information above, but it is a typed object.
  // public user: User = new User();
  // another way
  // public user: User = new User('Jordan Woodruff',
  //   'Lubbock, TX',
  //   'https://images.pexels.com/photos/45201/kitty-cat-kitten-pet-45201.jpeg',
  //   33);

  // import const from a file
  // public user: any = user;

  constructor() {

    // this would set the properties just like the short 'basic way' above.
    // it has to be in the constructor because you cannot initialize
    // user.profileImage = 'https://images.pexels.com/photos/45201/kitty-cat-kitten-pet-45201.jpeg';
    // user.name = 'Jordan Woodruff';
    // user.location = 'Lubbock, TX';
    // user.reviews = 33;
   }
}
