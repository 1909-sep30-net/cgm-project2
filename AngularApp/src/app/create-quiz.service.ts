import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import TitleModel from './models/title-model';
import CategoryModel from './models/category-model';
import QuestionModel from './models/question-model';
import AnswerModel from './models/answer-model';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CreateQuizService {
  

  postTitle(titleModel: TitleModel): Promise<HttpResponse<TitleModel>> {

    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');


    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/Title`;

    return this.httpClient.post<TitleModel>(url, titleModel, { headers: headers, observe: 'response'}).toPromise();
  };

  // private generatePostTitleJson(titleModel: TitleModel): string {
  //   return `{"titleString":"${titleModel.titleString}","creatorId":${titleModel.creatorId}}`;
  // }

  getTitleId(titleModel: TitleModel) : Promise<number> {

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/LastTitleBy/`;
    return this.httpClient.get<number>(url+`${titleModel.creatorId}`).toPromise();

  }

  postQuestion(questionModel: QuestionModel): Observable<HttpResponse<QuestionModel>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/Question`;

    return this.httpClient.post<QuestionModel>(url, questionModel, { headers: headers, observe: 'response'});
  }

  // private generatePostQuestionJson(questionModel: QuestionModel): string {
  //   console.log(`{"titleId": ${questionModel.titleId},"questionstring": "${questionModel.questionString}"}`);
  //   return `{"titleId": ${questionModel.titleId},"questionstring": "${questionModel.questionString}"}`;
  // }

  constructor(private httpClient: HttpClient) { }
}
