import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cat-form',
  templateUrl: './cat-form.component.html',
  styleUrls: ['./cat-form.component.css']
})
export class CatFormComponent implements OnInit {

  constructor() { }

  newCat: any = {
    name: '',
    age: 0,
    breed: '',
    gender: '',
  };

  formMessage = '';

  ngOnInit() {

  }

  save() {
    console.log(this.newCat);
    this.formMessage = JSON.stringify(this.newCat);
  }

  nameChanged(event) {
    this.newCat.name = event.target.value;
  }

  ageChanged(event) {
    this.newCat.age = event.target.value;
  }

  breedChanged(event) {
    this.newCat.breed = event.target.value;
  }

  genderChanged(event) {
    this.newCat.gender = event.target.value;
  }

}
