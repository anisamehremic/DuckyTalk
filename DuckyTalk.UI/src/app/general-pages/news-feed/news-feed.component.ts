import { Component, OnInit } from '@angular/core';
import { NewsFeedService } from 'src/app/services/news-feed.service';
import { Article } from 'src/app/shared/models/articles.model';
import { News } from 'src/app/shared/models/news.model';

@Component({
  selector: 'app-news-feed',
  templateUrl: './news-feed.component.html',
  styleUrls: ['./news-feed.component.scss']
})
export class NewsFeedComponent implements OnInit {
  news: News;
  articles: Article[] = []

  constructor(protected newsFeedService: NewsFeedService) { }

  async ngOnInit() {
    this.news = await this.newsFeedService.getAllNews();
    this.articles = this.news.articles;
  }
}
