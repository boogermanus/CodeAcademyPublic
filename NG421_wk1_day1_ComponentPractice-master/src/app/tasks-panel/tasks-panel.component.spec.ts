import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TasksPanelComponent } from './tasks-panel.component';

describe('TasksPanelComponent', () => {
  let component: TasksPanelComponent;
  let fixture: ComponentFixture<TasksPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TasksPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TasksPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
