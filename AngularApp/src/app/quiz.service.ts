import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { QuizM } from './models/quiz-m';
import { TitleM } from './models/title-m';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  //titles = [];
  constructor(private httpClient: HttpClient) { }

  // getQuiz(): Promise<TitleM[]> {
  //   //TitleM[];
  //   let url = `${environment.restApiBaseUrl}/api/TakeAQuiz`;
  //   var return1 = this.httpClient.get<TitleM[]>(url).toPromise();
  //   //console.log(return1);
  //   return return1;
  // }

  getQuiz(): Observable<TitleM[]> {
    let url = `${environment.restApiBaseUrl}/api/TakeAQuiz`;
    return this.httpClient.get<TitleM[]>(url);
    //return this.titles;
  }

  // getQuizToTake(titleId: number): Observable<QuizM> {
  //   let url = `${environment.restApiBaseUrl}/api/TakeAQuiz/${titleId}`;
  //   return this.httpClient.get<QuizM>(url);
  //   //return this.titles;
  // }

  //test this method of getting the quiz object
  getQuizToTake(titleId: number) {
    let url = `${environment.restApiBaseUrl}/api/TakeAQuiz/${titleId}`;
    return this.httpClient.get(url);
    //return this.titles;
  }


};