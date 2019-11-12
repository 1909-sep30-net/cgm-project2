import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TakeYourQuizComponent } from './take-your-quiz.component';

describe('TakeYourQuizComponent', () => {
  let component: TakeYourQuizComponent;
  let fixture: ComponentFixture<TakeYourQuizComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TakeYourQuizComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TakeYourQuizComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
