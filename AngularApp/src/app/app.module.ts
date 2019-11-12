import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { UserComponent } from './user/user.component';
import { CreateQuizComponent } from './create-quiz/create-quiz.component';

import { ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { TakeAQuizComponent } from './take-aquiz/take-aquiz.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    CreateQuizComponent,
    NavbarComponent,
    TakeAQuizComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: UserComponent },
      {path:'app-take-aquiz', component:TakeAQuizComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
