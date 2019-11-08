import { Component, OnInit } from '@angular/core';
import TitleModel from '../models/title-model';
import CategoryModel from '../models/category-model';
import QuestionModel from '../models/question-model';
import AnswerModel from '../models/answer-model';
import { CreateQuizService } from '../create-quiz.service';

import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';

import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-create-quiz',
  templateUrl: './create-quiz.component.html',
  styleUrls: ['./create-quiz.component.css']
})
export class CreateQuizComponent implements OnInit {
  /////////////////////////////////////Title Methods//////////////////////////////////
  titleSubmitted: boolean = false;

  titleForm = this.formBuilder.group({
    titleString: ['', Validators.required],
    creatorId: ['', Validators.required],
    questions: this.formBuilder.array([
      this.formBuilder.control('')
    ])
  });

  get questions() {
    return this.titleForm.get('questions') as FormArray;
  }

  addQuestion() {
    this.questions.push(this.formBuilder.control(''));
  }

  onTitleSubmit() {
    let titleString = this.titleForm.get('titleString').value as string;
    let creatorId = this.titleForm.get('creatorId').value as number;
    let titleModel: TitleModel = { titleString: titleString, creatorId: creatorId };
    this.createQuizService.postTitle(titleModel)
      .then(() => this.getTitleId(titleModel))
      .then(titleId => this.questionSubmit(this.questions, titleId))
      .then(() => {this.titleSubmitted = true;});

    
  }

  getTitleId(titleModel: TitleModel) : Promise<number>{
    return this.createQuizService.getTitleId(titleModel);
  }

  questionSubmit(questions: FormArray, titleId: number) : void{
    for(let question in questions.value)
    {
      let questionModel: QuestionModel = { questionString: question, titleId: titleId};
      console.log(question);
      console.log(titleId);
      this.createQuizService.postQuestion(questionModel).subscribe(
        response => { console.log(response) });
    }
  }



  constructor(private createQuizService: CreateQuizService, private formBuilder: FormBuilder) { }

  ngOnInit() {
  }

}
// .then(
//       (result) => { return result}
//     );



// import { Component, OnInit } from '@angular/core';
// import TitleModel from '../models/title-model';
// import CategoryModel from '../models/category-model';
// import QuestionModel from '../models/question-model';
// import AnswerModel from '../models/answer-model';
// import { CreateQuizService } from '../create-quiz.service';

// import { FormGroup, FormControl, FormArray } from '@angular/forms';
// import { FormBuilder } from '@angular/forms';
// import { Validators } from '@angular/forms';

// import { Title } from '@angular/platform-browser';
// import { Observable } from 'rxjs';
// import { HttpResponse } from '@angular/common/http';

// @Component({
//   selector: 'app-create-quiz',
//   templateUrl: './create-quiz.component.html',
//   styleUrls: ['./create-quiz.component.css']
// })
// export class CreateQuizComponent implements OnInit {
//   /////////////////////////////////////Title Methods//////////////////////////////////
//   titleSubmitted: boolean = false;

//   titleForm = this.formBuilder.group({
//     titleString: ['', Validators.required],
//     creatorId: ['', Validators.required],
//     questions: this.formBuilder.array([
//       this.formBuilder.control('')
//     ])
//   });

//   get questions() {
//     return this.titleForm.get('questions') as FormArray;
//   }

//   addQuestion() {
//     this.questions.push(this.formBuilder.control(''));
//   }

//   onTitleSubmit() {
//     let titleString = this.titleForm.get('titleString').value as string;
//     let creatorId = this.titleForm.get('creatorId').value as number;
//     let titleModel: TitleModel = { titleString: titleString, creatorId: creatorId };
//     this.createQuizService.postTitle(titleModel).subscribe(
//       response => { console.log(response) });

//     let titleId : number;
//     this.createQuizService.getTitleId(titleModel).then(id => titleId = id);
//     let questions = this.questions;
//     for(let question in questions)
//     {
//       let questionModel: QuestionModel = { questionString: question.valueOf(), titleId: titleId};
//       console.log(question.valueOf());
//       console.log(titleId);
//       this.createQuizService.postQuestion(questionModel).subscribe(
//         response => { console.log(response) });
//     }

//     this.titleSubmitted = true;
//   }



//   constructor(private createQuizService: CreateQuizService, private formBuilder: FormBuilder) { }

//   ngOnInit() {
//   }

// }