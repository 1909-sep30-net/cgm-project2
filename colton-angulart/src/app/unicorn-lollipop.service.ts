import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import TitleModel from './models/title-model';
import CategoryModel from './models/category-model';
import QuestionModel from './models/question-model';
import AnswerModel from './models/answer-model';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import User from './Models/user';

@Injectable({
  providedIn: 'root'
})
export class UnicornLollipopService {

  constructor(private httpClient: HttpClient) { }

printTotheConsole() {
  console.log("Unicorn Lollipop");
  
}


postUser(userModel: User): Promise<HttpResponse<User>> {

  let headers = new HttpHeaders();
  headers.append('Content-Type', 'application/json');


  let url = `${environment.restApiBaseUrl}/api/user/get`;

  return this.httpClient.post<User>(url, userModel, { headers: headers, observe: 'response'}).toPromise();
  
};


getUserId(userModel: User) : Promise<number> {

  let url = `${environment.restApiBaseUrl}/api/CreateQuiz/LastTitleBy/`;
  return this.httpClient.get<number>(url+`${userModel.userId}`).toPromise();

}


}
