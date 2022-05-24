export interface IInterest {
    interestId: number,
    name: string,
    description: string
  }
  
  export class Interest implements IInterest {
    interestId: number;
    name: string;
    description: string;

    constructor(interest?: IInterest) {
      if (!interest) return this;
  
      this.interestId = interest.interestId;
      this.name = interest.name;
      this.description = interest.description;
    }
  }
  