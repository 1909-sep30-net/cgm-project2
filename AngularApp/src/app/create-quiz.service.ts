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


  getTitleId(titleModel: TitleModel) : Promise<number> {

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/LastTitleBy/`;
    return this.httpClient.get<number>(url+`${titleModel.creatorId}`).toPromise();

  }

  postCategory(categoryModel: CategoryModel, titleId: number): Promise<HttpResponse<CategoryModel>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    categoryModel.titleId = titleId;

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/Category`;

    return this.httpClient.post<CategoryModel>(url, categoryModel, { headers: headers, observe: 'response'}).toPromise();
  }

  postQuestion(questionModel: QuestionModel, titleId: number): Promise<HttpResponse<QuestionModel>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    questionModel.titleId = titleId;

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/Question`;

    return this.httpClient.post<QuestionModel>(url, questionModel, { headers: headers, observe: 'response'}).toPromise();
  }

  postAnswer(answerModel: AnswerModel): Promise<HttpResponse<AnswerModel>> {
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/Question`;

    return this.httpClient.post<AnswerModel>(url, answerModel, { headers: headers, observe: 'response'}).toPromise();
  }

  getQuestionId(titleId: number) : Promise<number> {

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/LastQuestionByTitle/`;
    return this.httpClient.get<number>(url+`${titleId}`).toPromise();

  }

  getCategoryId(titleId: number) : Promise<number> {

    let url = `${environment.restApiBaseUrl}/api/CreateQuiz/LastCategoryByTitle/`;
    return this.httpClient.get<number>(url+`${titleId}`).toPromise();

  }


  constructor(private httpClient: HttpClient) { }
}
