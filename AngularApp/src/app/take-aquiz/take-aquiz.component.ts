import { Component, OnInit } from '@angular/core';
import { QuizService } from '../quiz.service';
import { ActivatedRoute } from '@angular/router';
import { TitleM } from '../models/title-m';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-take-aquiz',
  templateUrl: './take-aquiz.component.html',
  styleUrls: ['./take-aquiz.component.css']
})
export class TakeAQuizComponent implements OnInit {

  titles: TitleM[];

//ASYNCHRONOUS getQuiz
  // getQuiz() : void {
  //   this.quizService.getQuiz()
  //   .then(titles => {
  //     this.titles = titles}
  //     );
  //     console.log(this.titles);
  // }

//SYNCHRONOUS getQuiz
  getQuiz(): void{
    this.quizService.getQuiz()
    .subscribe( titles1 => this.titles = titles1 as TitleM[] );
  }

  // getQuizToTake(titleId: number): void{
  //   //console.log("here in getQuizToTake().");

  // }

  constructor(private quizService: QuizService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit() { }




}
