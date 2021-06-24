import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BeerPlusComponent } from './beer-plus.component';

describe('BeerPlusComponent', () => {
  let component: BeerPlusComponent;
  let fixture: ComponentFixture<BeerPlusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BeerPlusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BeerPlusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
