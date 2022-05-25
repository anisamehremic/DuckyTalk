import { Article } from "./articles.model";

export interface INews {
  status: string;
  totalResults: number;
  articles: Article[];
}

export class News implements INews {
  status: string;
  totalResults: number;
  articles: Article[];

  constructor(news: INews) {
    if (!news) return this;

    this.status = news.status;
    this.totalResults = news.totalResults;
    this.articles = news.articles;
  }
}
