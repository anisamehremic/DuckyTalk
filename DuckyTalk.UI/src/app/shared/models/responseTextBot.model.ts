export interface IresponseTextBot {
  recipient_id: string;
  text: string;
}

export class ResponseTextBot implements IresponseTextBot {
  recipient_id: string;
  text: string;

  constructor(res: IresponseTextBot) {
    if (!res) return this;

    this.recipient_id = res.recipient_id;
    this.text = res.text;
  }
}
