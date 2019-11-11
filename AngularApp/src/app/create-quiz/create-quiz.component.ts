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

interface AnswerInfo {
  answersSubmitted: boolean;
  answersUpdating: boolean;
  numberOfAnswers: number;
  answerForm: FormGroup;
  questionString: string;
}

class AnswerInfoClass implements AnswerInfo {
  answersSubmitted: boolean;
  answersUpdating: boolean;
  numberOfAnswers: number;
  answerForm: FormGroup;
  questionString: string;

  get answers() {
    return this.answerForm.get('answers') as FormArray;
  }
}


@Component({
  selector: 'app-create-quiz',
  templateUrl: './create-quiz.component.html',
  styleUrls: ['./create-quiz.component.css']
})
export class CreateQuizComponent implements OnInit {

  quiz = {
    titleModel: null,
    categoryModels: null,
    questionModels: null,
    answerModels: null
  }


  /////////////////////////////////////Title Methods//////////////////////////////////
  titleForm = this.formBuilder.group({
    titleString: ['', Validators.required],
    creatorId: ['', Validators.required],
  });

  titleSubmitted: boolean = false;
  titleUpdating: boolean = false;

  onTitleSubmit() {
    let titleString = this.titleForm.get('titleString').value as string;
    let creatorId = this.titleForm.get('creatorId').value as number;
    let titleModel: TitleModel = { titleString: titleString, creatorId: creatorId };
    this.quiz.titleModel = titleModel;
    this.titleSubmitted = true;
    this.titleUpdating = false;
  };

  onTitleUpdate() {
    this.titleUpdating = true;
  }



  /////////////////////////////////////Category Methods//////////////////////////////////

  categoryForm = this.formBuilder.group({
    categories: this.formBuilder.array([
      this.formBuilder.group({
        categoryString: ['', Validators.required],
        categoryDescription: ['', Validators.required]
      })
    ])
  });

  numberOfCategories: number = 0;
  maxNumberOfCategories: number = 5;

  categoriesSubmitted: boolean = false;
  categoriesUpdating: boolean = false;

  get categories() {
    return this.categoryForm.get('categories') as FormArray;
  }

  addCategory() {
    if (this.numberOfCategories < this.maxNumberOfCategories) {
      this.categories.push(
        this.formBuilder.group({
          categoryString: ['', Validators.required],
          categoryDescription: ['', Validators.required]
        }));
      this.numberOfCategories++;
    }
  }

  removeCategory() {
    if (this.numberOfCategories > 0) {
      this.categories.removeAt(this.categories.length - 1);
      this.numberOfCategories--;
    }
  }

  onCategorySubmit() {
    let categoryValues = this.categories.value;
    let quizCategories: CategoryModel[] = [];
    for (let index in categoryValues) {
      let categoryModel: CategoryModel = {
        categoryString: categoryValues[index].categoryString,
        categoryDescription: categoryValues[index].categoryDescription,
        categoryId: 0,
        rank: quizCategories.length + 1,
        titleId: 0
      };
      quizCategories.push(categoryModel);
    }
    this.quiz.categoryModels = quizCategories;

    this.categoriesSubmitted = true;
    this.categoriesUpdating = false;
    this.totalNumberOfAnswers = quizCategories.length;

    //INTENTIONALLY TWICE
    this.ALLAutoAddRemoveAnswers();

  }

  onCategoriesUpdate() {
    this.categoriesUpdating = true;
  }


  /////////////////////////////////////Question Methods//////////////////////////////////
  questionForm = this.formBuilder.group({
    questions: this.formBuilder.array([
      this.formBuilder.group({
        questionString: ['', Validators.required]
      })
    ])
  });

  numberOfQuestions: number = 0;
  maxNumberOfQuestions: number = 10;



  questionsSubmitted: boolean = false;
  questionsUpdating: boolean = false;

  get questions() {
    return this.questionForm.get('questions') as FormArray;
  }


  get answers() {
    return this.answerInfos[0].answerForm.get('answers') as FormArray;
  }

  addQuestion() {
    if (this.numberOfQuestions < this.maxNumberOfQuestions) {
      this.questions.push(
        this.formBuilder.group({
          questionString: ['', Validators.required]
        }));
      this.numberOfQuestions++;
      this.addAnswerInfo();
      this.ALLAutoAddRemoveAnswers();
    }
  }

  removeQuestion() {
    if (this.numberOfQuestions > 0) {
      this.questions.removeAt(this.questions.length - 1);
      this.numberOfQuestions--;
      this.removeAnswerInfo();
      this.ALLAutoAddRemoveAnswers();
    }
  }


  onQuestionSubmit() {
    console.log(this.questionForm.value)

    let questionValues = this.questions.value;
    let quizQuestions: QuestionModel[] = [];
    for (let index in questionValues) {
      let questionModel: QuestionModel = {
        questionString: questionValues[index].questionString,
        titleId: 0
      };

      quizQuestions.push(questionModel);
    }
    this.quiz.questionModels = quizQuestions;
    this.questionsSubmitted = true;
    this.questionsUpdating = false;
  }

  onQuestionsUpdate() {
    this.questionsUpdating = true;
  }

  getQuestionString(index: number): string {
    return this.questions[index].value;
    console.log(this.questions[index].value);
  }

  /////////////////////////////////////Answer Methods//////////////////////////////////

  public answerInfos: AnswerInfoClass[] = [];

  //set by OnCategorySubmit
  totalNumberOfAnswers: number = 0;

  private initializeNewAnswer() {
    let newAnswer: AnswerInfoClass = {
      questionString: 'Enter Question',
      answersSubmitted: false,
      answersUpdating: false,
      numberOfAnswers: 0,
      answerForm: this.formBuilder.group({
        answers: this.formBuilder.array([
          this.formBuilder.group({
            answerString: ['', Validators.required],
            categoryRank: ['', Validators.required],
          })
        ])
      }) as FormGroup,

      get answers() {
        return this.answerForm.get('answers') as FormArray;
      }
    };
    this.answerInfos.push(newAnswer);
    this.ALLAutoAddRemoveAnswers();
  }

  addAnswerInfo() {
    this.initializeNewAnswer();
  }

  removeAnswerInfo() {
    this.answerInfos.pop();
  }

  getAnswers(index: number): FormArray {
    return this.answerInfos[index].answerForm.get('answers') as FormArray;
  }

  ALLAutoAddRemoveAnswers() {
    for (let i = 0; i < this.answerInfos.length - 1; i++) {
      this.autoAddRemoveAnswers(i);
    }
  }

  private autoAddRemoveAnswers(index: number) {
    let numberOfAnswers: number = this.getAnswers(index).value.length;
    while (numberOfAnswers < this.totalNumberOfAnswers) {
      (this.answerInfos[index].answerForm.get('answers') as FormArray).push(
        this.formBuilder.group({
          answerString: ['', Validators.required],
          categoryRank: ['', Validators.required],
        }))
      numberOfAnswers++;
    }
    while (numberOfAnswers > this.totalNumberOfAnswers) {
      (this.answerInfos[index].answerForm.get('answers') as FormArray).removeAt(numberOfAnswers - 1);
      numberOfAnswers--;
    }
  }

  onAnswerSubmit(index: number) {
    this.answerInfos[index].answersSubmitted = true;
    this.answerInfos[index].answersUpdating = false;
  }

  onAnswerUpdate(index: number) {
    this.answerInfos[index].answersUpdating = true;
  }

  private finalAnswerSubmit() {
    for (let answer of this.answerInfos) {
      let questionIndex: number = 0;
      let answerValues = answer.answerForm.value;
      let quizAnswers: AnswerModel[] = [];
      for (let index in answerValues) {
        let answerModel: AnswerModel = {
          answerString: answerValues[index].answerString,
          questionId: questionIndex,
          categoryRank: -1
        };

        quizAnswers.push(answerModel);
      }
      this.quiz.answerModels = quizAnswers;
      answer.answersSubmitted = true;
      answer.answersUpdating = false;
    }
  }

  constructor(private createQuizService: CreateQuizService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.addAnswerInfo();
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