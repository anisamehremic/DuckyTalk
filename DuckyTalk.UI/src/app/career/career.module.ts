import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurveyComponent } from './survey/survey.component';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MainComponent } from './main/main.component';

const routes : Routes = [
  { path: 'main', component: MainComponent },
  { path: 'survey', component: SurveyComponent }
]

@NgModule({
  declarations: [SurveyComponent, MainComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    NgbModule
  ]
})
export class CareerModule { }
