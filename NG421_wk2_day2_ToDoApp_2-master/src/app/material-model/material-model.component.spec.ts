import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialModelComponent } from './material-model.component';

describe('MaterialModelComponent', () => {
  let component: MaterialModelComponent;
  let fixture: ComponentFixture<MaterialModelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaterialModelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaterialModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
