import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Interest } from '../shared/models/interest.model';
import { User } from '../shared/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class InterestService {

  constructor(private http: HttpClient) { }

  public getInterests() {
    try {
      return this.http.get<Array<Interest>>(`${environment.apiURL}/Interest`).toPromise();
    } catch (e) {
      console.log("Method is falling with: ", e.message);
    }
  }

  public saveUserInterests(userId: number, interestId: number){
    let body = {
      userId: userId,
      interestId: interestId,
      isActive: true
    }

    try {
      return this.http.post<any>(`${environment.apiURL}/UserInterest`, body).toPromise();
    } catch (e) {
      console.log("Method is falling with: ", e.message);
    }
  }
}
