import { Component, OnInit } from '@angular/core';
import { QuizM } from '../models/quiz-m';
import { ActivatedRoute } from '@angular/router';
import { QuizService } from '../quiz.service';
import { FormBuilder, FormArray } from '@angular/forms';
import { FormGroup } from '@angular/forms'

@Component({
  selector: 'app-take-your-quiz',
  templateUrl: './take-your-quiz.component.html',
  styleUrls: ['./take-your-quiz.component.css']
})
export class TakeYourQuizComponent implements OnInit {
  quizForm: FormGroup;
  answers: FormArray;
  quizObject = [];
  titleId: number;
  quizObjectStr: string;
  quizObject2: QuizM
  
  constructor(
    private formBuilder: FormBuilder,
    private quizService: QuizService,
    private route: ActivatedRoute
  ) { }
  
  ngOnInit() {
    //const queryParams = this.route.snapshot.queryParams
    const routeParams = this.route.snapshot.params;
    this.titleId = routeParams.titleId;
    console.log(`here in OnInit ${this.titleId}`);

    this.quizService.getQuizToTake(this.titleId)
      .subscribe( (data:any[]) => 
        {
          console.log(data);
          this.quizObject = data;
          var thing = JSON.stringify(data);
          this.quizObject2 = JSON.parse(thing);
        });

    //construct the form object
    // this.quizForm = this.formBuilder.group({
    //   titleId: `${this.quizObject2.title.TitleId}`,
    //   takerId: 1,//this is a placeholder
    //   answers: this.formBuilder.array( [this.createItem()] )
    // })
  }

  onSubmit(quizForm) {
    
    //check what is given...
    console.log(JSON.stringify(quizForm));
    // Process checkout data here
    console.warn('Your quiz has been submitted', quizForm);    

  }
  addItem(): void {
    this.answers = this.quizForm.get('answers') as FormArray;
    this.answers.push(this.createItem());
  }
  createItem(): FormGroup {
    return this.formBuilder.group({
      weight:'0'
    });
  }


}
