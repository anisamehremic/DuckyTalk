import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BlankPageComponent } from './blank-page/blank-page.component';
import { Routes, RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MainComponent } from './main/main.component';
import { FormsModule } from '@angular/forms';
import { NewsFeedComponent } from './news-feed/news-feed.component';
import { SharedModule } from '../shared/shared.module';

const routes : Routes = [
  { path: 'blank-page', component: BlankPageComponent },
  { path: 'main', component: MainComponent },
  { path: 'news-feed', component: NewsFeedComponent }

]

@NgModule({
  declarations: [BlankPageComponent, MainComponent, NewsFeedComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
    NgbModule,
    SharedModule
  ]
})
export class GeneralPagesModule { }
