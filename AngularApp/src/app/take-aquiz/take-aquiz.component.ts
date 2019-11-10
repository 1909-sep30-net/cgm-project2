import { Component, OnInit } from '@angular/core';
import { QuizService } from '../quiz.service';
import { QuizM } from '../models/quiz-m';
import { ActivatedRoute } from '@angular/router';
import { TitleM } from '../models/title-m';

@Component({
  selector: 'app-take-aquiz',
  templateUrl: './take-aquiz.component.html',
  styleUrls: ['./take-aquiz.component.css']
})
export class TakeAQuizComponent implements OnInit {

  quiz: QuizM[];
  titles: TitleM[];

  getQuiz() : void {
    this.quizService.getQuiz()
    .then(titles => this.titles = titles);
  }
  constructor(private quizService: QuizService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() { }




}
