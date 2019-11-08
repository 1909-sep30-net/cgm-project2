import { Component, OnInit } from '@angular/core';
import TitleModel from '../models/title-model';
import CategoryModel from '../models/category-model';
import QuestionModel from '../models/question-model';
import AnswerModel from '../models/answer-model';
import { CreateQuizService } from '../create-quiz.service';

import { FormGroup, FormControl } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-create-quiz',
  templateUrl: './create-quiz.component.html',
  styleUrls: ['./create-quiz.component.css']
})
export class CreateQuizComponent implements OnInit {

  quiz = new FormGroup({
    titleString: new FormControl(''),
    creatorId: new FormControl('')
  });

  submitted : boolean = false;
  


  onTitleSubmit() {
    let titleString = this.quiz.get('titleString').value as string;
    let creatorId = this.quiz.get('creatorId').value as number;
    let titleModel : TitleModel = {titleString: titleString, creatorId: creatorId};
    this.createQuizService.postTitle(titleModel).subscribe(
      response => {console.log(response)});
    this.submitted = true;
  }

  constructor(private createQuizService: CreateQuizService) { }

  ngOnInit() {
  }

}
