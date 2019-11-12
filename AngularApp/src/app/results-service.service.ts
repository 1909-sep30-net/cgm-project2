import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import TitleModel from './models/title-model';
import CategoryModel from './models/category-model';
import QuestionModel from './models/question-model';
import AnswerModel from './models/answer-model';
import ResultModel from './models/result-model';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ResultsServiceService {


  getResults(resultsId: number) : Promise<ResultModel>{
    let url = `${environment.restApiBaseUrl}/api/Result/${resultsId}`;
    return this.httpClient.get<ResultModel>(url+`${resultsId}`).toPromise();
  }

  getResult2(): Promise<ResultModel> { //to be used by results component
    let url = `${environment.restApiBaseUrl}/api/User`;
    return this.httpClient.get<ResultModel>(url).toPromise();

  }

  postResults(){

  }

  // Resultget(id: Number) {

  // }

  constructor(private httpClient: HttpClient) {  }
}
