import { Component, OnInit } from '@angular/core';
import AnswerModel from '../models/answer-model';

import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';

import { Router, ActivatedRoute, ParamMap } from '@angular/router';

import { CreateQuizService } from '../create-quiz.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-answers',
  templateUrl: './add-answers.component.html',
  styleUrls: ['./add-answers.component.css']
})
export class AddAnswersComponent implements OnInit {
  titleId: number;
  answers: AnswerModel[];

  private routeSub: Subscription;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private serv: CreateQuizService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.routeSub = this.route.params.subscribe(params => {
      this.titleId = params['AddAnswersComponent'];

      this.serv.getAnswers(this.titleId)
        .then(answers => this.answers = answers)
        .catch(function (e) {
          console.log(e);
        })
    });


  }

}
