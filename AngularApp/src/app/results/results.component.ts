import { Component, OnInit } from '@angular/core';
import TitleModel from '../models/title-model';
import CategoryModel from '../models/category-model';
import QuestionModel from '../models/question-model';
import AnswerModel from '../models/answer-model';
import { ResultsServiceService } from '../results-service.service';
import ResultModel from '../models/result-model';
import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';

import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';

import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private serv: ResultsServiceService,
  ) { }

  result: ResultModel[] = null;

  getResults() : void {
    this.serv.getResult2()
      .then(result => this.result = result);
  }


  get results() {
    return this.serv.getResults(1); //hard coded result id, how to get i
  }

  getResult(resultId: number): string { 
    return "colton";
  }

 
  ngOnInit() {
  }

}
