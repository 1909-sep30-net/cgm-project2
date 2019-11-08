import { Component, OnInit } from '@angular/core';
import User from '../models/user';
import { UserServiceService } from '../user-service.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: User[] = null;

  getUsers() : void {
    this.userService.getUsers()
      .then(users => this.users = users);
  }


  constructor(private userService: UserServiceService) { }

  ngOnInit() {
    this.getUsers();
  }

}