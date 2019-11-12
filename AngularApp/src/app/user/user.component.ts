import { Component, OnInit } from '@angular/core';
import User from '../models/user';
import { UserService } from '../user.service';
import {ThemeService} from '../theme.service';
import {
  faLightbulb as faSolidLightbulb,
  faDollarSign,
  IconDefinition
} from "@fortawesome/free-solid-svg-icons";
import { faLightbulb as faRegularLightbulb } from "@fortawesome/free-regular-svg-icons";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  users: User[] = null;
  faLightbulb: IconDefinition;
  faDollarSign = faDollarSign;
  getUsers() : void {
    this.userService.getUsers()
      .then(users => this.users = users);
  }

  constructor(private userService: UserService, private themeService: ThemeService) { }

  ngOnInit() {
    this.getUsers();
    this.setLightbulb();
  }

  setLightbulb() {
    if (this.themeService.isDarkTheme()) {
      this.faLightbulb = faRegularLightbulb;
    } else {
      this.faLightbulb = faSolidLightbulb;
    }
  }

  toggleTheme() {
    if (this.themeService.isDarkTheme()) {
      this.themeService.setLightTheme();
    } else {
      this.themeService.setDarkTheme();
    }

    this.setLightbulb();

    }
}

