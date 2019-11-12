import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { UserComponent } from './user/user.component';
import { CreateQuizComponent } from './create-quiz/create-quiz.component';

import { ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { NavComponent } from './nav/nav.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AddAnswersComponent } from './add-answers/add-answers.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HomePageComponent } from './home-page/home-page.component';



import { TakeAQuizComponent } from './take-aquiz/take-aquiz.component';
import { RouterModule } from '@angular/router';




@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    CreateQuizComponent,
    NavbarComponent,
    NavComponent,
    AddAnswersComponent,
    PageNotFoundComponent,
    HomePageComponent,
    TakeAQuizComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    FontAwesomeModule
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
