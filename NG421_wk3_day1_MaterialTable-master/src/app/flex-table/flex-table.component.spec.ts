import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlexTableComponent } from './flex-table.component';

describe('FlexTableComponent', () => {
  let component: FlexTableComponent;
  let fixture: ComponentFixture<FlexTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlexTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlexTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
