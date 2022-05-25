import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveyComponent } from './survey/survey.component';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const routes : Routes = [
  { path: 'main', component: SurveyComponent }
]

@NgModule({
  declarations: [SurveyComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    NgbModule
  ]
})
export class CareerModule { }
