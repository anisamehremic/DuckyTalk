export interface IMessage {
  author: string;
  message: string;
}

export class Message implements IMessage {
  constructor(public author: string, public message: string) {}
}
