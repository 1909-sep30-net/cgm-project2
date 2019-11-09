import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import User from './models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getUsers(): Promise<User[]> {
    let url = `${environment.restApiBaseUrl}/api/User`;
    return this.httpClient.get<User[]>(url).toPromise();

  }
}