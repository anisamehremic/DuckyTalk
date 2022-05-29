import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Auth } from "../shared/models/auth.model";
import { User } from "../shared/models/user.model";
import { map } from "rxjs/operators";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class UserService {
  httpOptions: { headers: HttpHeaders };
  private userSubject: BehaviorSubject<any>;
  public user: Observable<any>;

  constructor(private http: HttpClient, protected router: Router) {
    this.userSubject = new BehaviorSubject<any>(
      JSON.parse(localStorage.getItem("user"))
    );
    this.user = this.userSubject.asObservable();
  }

  public getAuthTokenValue(): User {
    return this.userSubject.value;
  }

  public registration(user: User): Promise<any> {
    try {
      return this.http
        .post<any>(`${environment.apiURL}/Registration`, user)
        .toPromise();
    } catch (e) {
      console.log("Method is falling with: ", e.message);
    }
  }

  public login(user: Auth): any {
    let authData = window.btoa(user.username + ":" + user.password);
    localStorage.setItem("user", JSON.stringify(authData));
    localStorage.setItem("username", JSON.stringify(user.username));
    this.userSubject.next(authData);
    this.getUsers();
  }

  public getUsers() {
    try {
      return this.http.get<any>(`${environment.apiURL}/User`).toPromise();
    } catch (e) {
      console.log("Method is falling with: ", e.message);
    }
  }

  logout() {
    localStorage.removeItem("user");
    localStorage.removeItem("username");
    this.userSubject.next(null);
    this.router.navigate(["user-pages/login"]);
  }

  getLoggedUser() {
    return this.getUsers().then((c) =>
      c.find(
        (x) => x.username === JSON.parse(localStorage.getItem("username")!)
      )
    );
  }

  updateUser(userId: number, editUser: object){
    try {
      return this.http
        .put<any>(`${environment.apiURL}/User/${userId}`, editUser)
        .toPromise();
    } catch (e) {
      console.log("Method is falling with: ", e.message);
    }
  }
}
