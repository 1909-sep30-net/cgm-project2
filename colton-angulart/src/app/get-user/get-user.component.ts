import { Component, OnInit, ElementRef } from '@angular/core';
import TitleModel from '../models/title-model';
import CategoryModel from '../models/category-model';
import QuestionModel from '../models/question-model';
import AnswerModel from '../models/answer-model';
import { UnicornLollipopService } from '../unicorn-lollipop.service';
import User from '../Models/user';

import { FormGroup, FormControl, FormArray } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';

import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { HttpResponse } from '@angular/common/http';
import { Capability } from 'protractor';
import { Statement } from '@angular/compiler';


@Component({
  selector: 'app-get-user',
  templateUrl: './get-user.component.html',
  styleUrls: ['./get-user.component.css']
})
export class GetUserComponent implements OnInit {
  
  colton : string = "colton";
  constructor(private greg: UnicornLollipopService, private formBuilder: FormBuilder, private elementRef: ElementRef ) { }

  userForm = this.formBuilder.group({
    userId: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    street: ['', Validators.required],
    city: ['', Validators.required],
    state: ['', Validators.required],
    zip: ['', Validators.required],
    admin: ['', Validators.required]
  });


  
  get userId() {
    return this.userForm.get('userId');
  }

  // addQuestion() {
  //   this.questions.push(this.formBuilder.control(''));
  // }

  onUserSubmit() {
    let userId = this.userForm.get('userId').value as number;
    let firstName = this.userForm.get('firstName').value as string;
    let lastName = this.userForm.get('lastName').value as string;
    let street = this.userForm.get('street').value as string;
    let city = this.userForm.get('city').value as string;
    let state = this.userForm.get('state').value as string;
    let zip = this.userForm.get('zip').value as string;
    let admin = this.userForm.get('admin').value as boolean;
    let userModel: User = { userId: userId, firstName: firstName, lastName: lastName, street: street, city: city, state: state, zip: zip, admin: admin };
    this.greg.postUser(userModel)
      .then(() => this.getUserId(userModel))
   
  }

  getUserId(userModel: User) : Promise<number>{
    return this.greg.getUserId(userModel);
  }

  // questionSubmit(questions: FormArray, titleId: number) : void{
  //   let questionValues = questions.value;
  //   for(let questionIndex in questionValues)
  //   {
  //     let questionModel: QuestionModel = { questionString: questionValues[questionIndex], titleId: titleId};
  //     this.greg.postUser(userModel).subscribe(
  //       response => { console.log(response) });
  //   }
  // }
  
  mark() {
    this.greg.printTotheConsole();
  }

  ngOnInit() {
    this.mark();
  }

  ngAfterViewInit(){
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = 'black';
 }

toggleSwitch = document.querySelector('.theme-switch input[type="checkbox"]');
switchTheme(e) {
    if (e.target.checked) {
        document.documentElement.setAttribute('data-theme', 'dark');
        localStorage.setItem('theme', 'dark');
    }
    else {
        document.documentElement.setAttribute('data-theme', 'light');
        localStorage.setItem('theme', 'light');
    }    
}
currentTheme = localStorage.getItem('theme') ? localStorage.getItem('theme') : null;

if (currentTheme) {
    document.documentElement.setAttribute('data-theme', currentTheme);

    if (currentTheme === 'dark') {
        let toggleSwitch = true;
    }
}

// toggleSwitch.addEventListener('change', switchTheme, false);

// const toggleSwitch = document.querySelector('.theme-switch input[type="checkbox"]');

// switchTheme(e) {
//     if (e.target.checked) {
//         document.documentElement.setAttribute('data-theme', 'dark');
//     }
//     else {
//         document.documentElement.setAttribute('data-theme', 'light');
//     }    
// }

  // toggleSwitch.addEventListener('change', switchTheme, false)}
}