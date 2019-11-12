import { Component, OnInit } from '@angular/core';
import { QuizM } from '../models/quiz-m';
import { ActivatedRoute } from '@angular/router';
import { QuizService } from '../quiz.service';
import { FormBuilder, FormArray } from '@angular/forms';
import { FormGroup } from '@angular/forms'
import CategoryModel from '../models/category-model';

@Component({
  selector: 'app-take-your-quiz',
  templateUrl: './take-your-quiz.component.html',
  styleUrls: ['./take-your-quiz.component.css']
})
export class TakeYourQuizComponent implements OnInit {
  //quizForm: FormGroup;
  //answers: FormArray;
  quizObject: QuizM;
  titleId: number;
  quizObjectStr: string;
  category: CategoryModel;
  // quizObject2: QuizM
  
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
      .subscribe( (data: QuizM) => 
        {
          console.log(data);
          this.quizObject = data;
          // var thing = JSON.stringify(data);
          // this.quizObject2 = JSON.parse(thing);
        });

    //construct the form object
    // this.quizForm = this.formBuilder.group({
    //   titleId: `${this.quizObject2.title.TitleId}`,
    //   takerId: 1,//this is a placeholder
    //   answers: this.formBuilder.array( [this.createItem()] )
    // })
  }

  onSubmit(form: HTMLFormElement) {
    const data = new FormData(form);
    //console.log(data);//this prints nothing. just testing it
    console.log(data.get('titleId'));//this gets the titleId
    
    var quizResults = new Array(1,+data.get('titleId'));    //let quizResults: number[];//make an array to hold the numbers.
    let e = 0;//to count the elements
    //quizResults.push(1);//userId
    //e++;
    //quizResults[e] = +data.get('titleId');//titleId
    //use this to get the weights into the array. 
    for (const question of this.quizObject.questions) {
      //console.log(data.get(question.questionId.toString()));
      //quizResults[e] = +data.get(question.questionId.toString());
      quizResults.push(+data.get(question.questionId.toString()));
      //console.log('in array');
    }

    //now send the array into the DB.
    // var quizJson = JSON.stringify(quizResults);
    // this.quizService.postQuizRresultsToDb(quizJson);
    this.quizService.postQuizResultsToDb(quizResults)
    .then( () => {
      this.quizService.getQuizByLastQuizTitleId(+data.get('titleId'))//make sure this function returns a promise.
      .then( category => this.category = category);
    });

    //console.log("here in onSubmit");
    //console.log(data.get('titleId'));

    //check what is given...
    // console.log(JSON.stringify(qu));
    // // Process checkout data here
    //console.warn('Your quiz has been submitted');  //this just prints to console  
    

  // }
  // addItem(): void {
  //   this.answers = this.quizForm.get('answers') as FormArray;
  //   this.answers.push(this.createItem());
  // }
  // createItem(): FormGroup {
  //   return this.formBuilder.group({
  //     weight:'0'
  //   });
  // }
  }
}
