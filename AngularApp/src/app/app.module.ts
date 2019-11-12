import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { UserComponent } from './user/user.component';
import { CreateQuizComponent } from './create-quiz/create-quiz.component';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { NavComponent } from './nav/nav.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AddAnswersComponent } from './add-answers/add-answers.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HomePageComponent } from './home-page/home-page.component';



import { TakeAQuizComponent } from './take-aquiz/take-aquiz.component';
import { RouterModule } from '@angular/router';
import { TakeYourQuizComponent } from './take-your-quiz/take-your-quiz.component';




@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    CreateQuizComponent,
    NavbarComponent,
    TakeYourQuizComponent,
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
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: UserComponent },
      {path:'app-take-aquiz', component:TakeAQuizComponent},
      {path: 'app-take-your-quiz/:titleId', component:TakeYourQuizComponent},
    ]),
    FontAwesomeModule
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
