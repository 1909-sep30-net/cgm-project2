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

  postTitle(titleModel: TitleModel): Observable<HttpResponse<TitleModel>> {

    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');


    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/Title`;

    return this.httpClient.post<TitleModel>(url, JSON.parse(this.generatePostTitleJson(titleModel)), { headers: headers, observe: 'response'})


  };

  private generatePostTitleJson(titleModel: TitleModel): string {
    return `{"titleString":"${titleModel.titleString}","creatorId":${titleModel.creatorId}}`;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instea;

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  constructor(private httpClient: HttpClient) { }
}
