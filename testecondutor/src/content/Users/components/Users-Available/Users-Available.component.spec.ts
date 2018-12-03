import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersAvailableComponent } from './Users-Available.component';

describe('UsersAvailableComponent', () => {
  let component: UsersAvailableComponent;
  let fixture: ComponentFixture<UsersAvailableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsersAvailableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersAvailableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
