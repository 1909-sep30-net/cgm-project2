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

  quiz = {
    titleModel: null,
    categoryModels: null,
    questionModels: null
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

  addQuestion() {
    if (this.numberOfQuestions < this.maxNumberOfQuestions) {
      this.questions.push(
        this.formBuilder.group({
          questionString: ['', Validators.required]
        }));
      this.numberOfQuestions++;

    }
  }

  removeQuestion() {
    if (this.numberOfQuestions > 0) {
      this.questions.removeAt(this.questions.length - 1);
      this.numberOfQuestions--;

    }
  }


  onQuestionSubmit() {
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
  }

 /////////////////////////////////////Batch Submit Methods//////////////////////////////////
 OnBatchSubmit(){

 }


  constructor(private createQuizService: CreateQuizService, private formBuilder: FormBuilder) { }

  ngOnInit() {
  }

}