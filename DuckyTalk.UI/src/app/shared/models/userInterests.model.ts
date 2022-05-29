export interface IUserInterests {
    userInterestId: number,
    userId: number,
    interestId: number,
    isDeleted: boolean
  }
  
  export class UserInterests implements IUserInterests {
    userInterestId: number;
    userId: number;
    isDeleted: boolean;
    interestId: number;

    constructor(userInterest?: UserInterests) {
      if (!userInterest) return this;
  
      this.userInterestId = userInterest.userInterestId;
      this.userId = userInterest.userId;
      this.interestId = userInterest.interestId;
      this.isDeleted = userInterest.isDeleted;
    }
  }
  