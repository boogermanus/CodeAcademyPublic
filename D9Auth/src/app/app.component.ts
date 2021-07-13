import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';
import { HeroService } from './hero.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'D9Auth';
  heroes: any[] = [];
  authClicked = false;

  constructor(
    private authService: AuthService,
    private heroService: HeroService) {}

  async authenticate() {
    await this.authService.login();

    // enable the add hero box
    this.authClicked = true;

    // take await out of this and watch the errors roll
    this.heroes = await this.heroService.getHeroes();
  }

  async addHero(event: any) {
    const value = event.target.value;

    await this.heroService.addHero(value);

    this.heroes = await this.heroService.getHeroes();
  }
}
