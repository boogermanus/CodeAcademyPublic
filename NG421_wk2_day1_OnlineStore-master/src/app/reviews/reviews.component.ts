import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.css']
})
export class ReviewsComponent implements OnInit {

  @Input()
  rating: number;

  stars: number[] = [];
  noStars: number[] = [];
  readonly MAX_RATING: number = 5;
  constructor() { }

  ngOnInit() {
    for (let i = 0; i < this.MAX_RATING ; i++) {
      i < this.rating ? this.stars.push(i) : this.noStars.push(i);
    }
  }
}
