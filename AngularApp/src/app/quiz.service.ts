import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { QuizM } from './models/quiz-m';
import { TitleM } from './models/title-m';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import CategoryModel from './models/category-model';

@Injectable({
  providedIn: 'root'
})
export class QuizService {
  getQuizByLastQuizTitleId(arg0: number): Promise<CategoryModel> /*Observable<CategoryModel>*/ {
    let url = `${environment.restApiBaseUrl}/api/TakeAQuiz/getresult/${arg0}`;
    return this.httpClient.get<CategoryModel>(url).toPromise();
  }
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

  postQuizResultsToDb(quizResults: number[]): Promise<HttpResponse<number[]>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    let url = `${environment.restApiBaseUrl}/api/TakeAQuiz/`;
    return this.httpClient.post<number[]>(url, quizResults, { headers: headers, observe: 'response'}).toPromise();
  };

};