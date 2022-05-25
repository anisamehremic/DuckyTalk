export interface IArticle {
  source: Source;
  author: string;
  title: string;
  description: string;
  url: string;
  urlToImage: string;
  publishedAt: Date;
  content: string;
}

export class Article implements IArticle {
  source: Source;
  author: string;
  title: string;
  description: string;
  url: string;
  urlToImage: string;
  publishedAt: Date;
  content: string;

  constructor(article?: IArticle) {
    if (!article) return this;

    this.source = new Source(article.source);
    this.author = article.author;
    this.title = article.title;
    this.description = article.description
    this.url = article.url;
    this.urlToImage = article.urlToImage;
    this.publishedAt = new Date(article.publishedAt);
    this.content = article.content;
  }
}

export class Source {
  id: string;
  name: string;

  constructor(source?: Source) {
    if (!source) return this;

    this.id = source.id;
    this.name = source.name;
  }
}
