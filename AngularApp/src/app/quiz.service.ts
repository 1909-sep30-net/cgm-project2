import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { QuizM } from './models/quiz-m';
import { TitleM } from './models/title-m';

@Injectable({
  providedIn: 'root'
})
export class QuizService {

  constructor(private httpClient: HttpClient) { }

  getQuiz(): Promise<TitleM[]> {
    //TitleM[];
    let url = `${environment.restApiBaseUrl}/api/TakeAQuiz`;
    
    console.log("Alpha");
    var return1 = this.httpClient.get<TitleM[]>(url).toPromise();
    //console.log(return1);
    return return1;
  }
};

// getCurrentJobs(): Promise<customType[]> {
//   var jobs = this.http.get(this.ordersUrl)
//     .toPromise()
//     .then(response => {
//       this.orders = response.json() as customType[];
//       return this.orders;
//     })
//     .catch(this.handleError);
//   return jobs;
// }