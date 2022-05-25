import { AfterViewChecked, Component, OnInit } from "@angular/core";
import { ChatbotService } from "src/app/services/chatbot.service";
import { Message } from "src/app/shared/models/message.model";

@Component({
  selector: "app-main",
  templateUrl: "./main.component.html",
  styleUrls: ["./main.component.scss"],
})
export class MainComponent implements OnInit, AfterViewChecked {
  messages: Message[] = [];
  value: string;
  time: Date;

  constructor(protected chatbotService: ChatbotService) {}

  ngOnInit() {
    this.chatbotService.conversation.subscribe((val) => {
      this.messages = this.messages.concat(val);
      this.time = new Date();
    });
  }

  ngAfterViewChecked() {
    this.scrollToBottom();
  }

  sendMessage() {
    this.chatbotService.getBotAnswer(this.value);
    this.value = "";
  }
  
  scrollToBottom() {
    const el = document.getElementById("scroll");
    if (el) el.scrollTop = el.scrollHeight;
  }
}
