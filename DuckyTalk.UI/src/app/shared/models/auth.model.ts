export interface IAuth {
    username: string;
    password: string;
  }
  
  export class Auth implements IAuth {
    username: string;
    password: string;
  
    constructor(user?: IAuth) {
      if (!user) return this;
  
      this.username = user.username;
      this.password = user.password;
    }
  }
  