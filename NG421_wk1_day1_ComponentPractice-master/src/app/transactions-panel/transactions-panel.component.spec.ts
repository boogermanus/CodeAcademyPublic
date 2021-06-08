import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionsPanelComponent } from './transactions-panel.component';

describe('TransactionsPanelComponent', () => {
  let component: TransactionsPanelComponent;
  let fixture: ComponentFixture<TransactionsPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TransactionsPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TransactionsPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
