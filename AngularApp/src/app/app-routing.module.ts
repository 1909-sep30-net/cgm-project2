import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { CreateQuizComponent } from './create-quiz/create-quiz.component';

const routes: Routes = [
  { path: 'creator',
    component: CreateQuizComponent,
    canActivate: [AuthGuard]  
  }
];

@NgModule({

  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]

  
})
export class AppRoutingModule { }
