import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Message } from '../shared/models/message.model';
import { ResponseTextBot } from '../shared/models/responseTextBot.model';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ChatbotService {
  conversation = new Subject<Message[]>();
  // messageMap = {
  //   "Hi": "Hello",
  //   "Who are you": "My name is Test Sat Bot",
  //   "What is your role": "Just guide for the user",
  //   "defaultmsg": "I can't understand your text. Can you please repeat"
  // }
  messageResponse: string;
  constructor(protected http: HttpClient,
    protected userService: UserService) { }
  
  async getBotAnswer(msg: string) {
    const userMessage = new Message('user', msg);
    this.conversation.next([userMessage]);
    let message = await this.getBotMessage(msg)
    const botMessage = new Message('bot', this.messageResponse );
    setTimeout(()=>{
      this.conversation.next([botMessage]);
    }, 1500);
  }

  // getBotMessage(question: string){
  //   let answer = this.messageMap[question];
  //   return answer || this.messageMap['defaultmsg'];
  // }
  async getBotMessage(msg: string){
    let user = await this.userService
      .getUsers()
      .then((c) =>
        c.find(
          (x) => x.username === JSON.parse(localStorage.getItem("username")!)
        )
      );
    console.log('userBot', user);

    let body = {
      sender: user.userId,
      message: msg
    }
    try {
      let response = this.http.post<ResponseTextBot>(`${environment.botURL}/webhooks/rest/webhook`, body).subscribe(data => {
        this.messageResponse = data.text;
        return data;
    });
      console.log(response);
      return this.messageResponse;
    } catch (e) {
      console.log("Method is falling with: ", e.message);
    }
  }
}
