import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Article } from "../shared/models/articles.model";
import { News } from "../shared/models/news.model";
import { UserService } from "./user.service";

@Injectable({
  providedIn: "root",
})
export class NewsFeedService {
  constructor(protected http: HttpClient, protected userService: UserService) {}

  async getAllNews(search = '') {
    let user = await this.userService
      .getUsers()
      .then((c) =>
        c.find(
          (x) => x.username === JSON.parse(localStorage.getItem("username")!)
        )
      );
    console.log("user:", user);
    debugger
    const url = `${environment.apiURL}/NewsApi?userId=${user.userId}&Q=${search}`;
    try {
      return this.http
        .get<News>(url)
        .pipe(
          map((response: News) => {
            console.log("News for user: ", new News(response));
            return new News(response);
          })
        )
        .toPromise();
    } catch (e) {
      console.log("Method is falling with: ", e.message);
    }
  }
}
