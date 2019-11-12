import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth.guard';

import { CreateQuizComponent } from './create-quiz/create-quiz.component';
import { AddAnswersComponent } from './add-answers/add-answers.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HomePageComponent } from './home-page/home-page.component';

const appRoutes: Routes = [
  { path: 'create-quiz', component: CreateQuizComponent },
  { path: 'create-quiz/:id/add-answers', component: AddAnswersComponent },
  { path: 'home-page', component: HomePageComponent },
  { path: '', redirectTo: '/home-page', pathMatch: 'full'},
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({

  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]

  
})
export class AppRoutingModule { }
