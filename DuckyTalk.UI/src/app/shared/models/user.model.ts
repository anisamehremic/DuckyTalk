export interface IUser {
  firstName: string;
  lastName: string;
  username: string;
  birthDate: Date;
  email: string;
  password: string;
  passwordConfirmation: string;
}

export class User implements IUser {
  firstName: string;
  lastName: string;
  username: string;
  birthDate: Date;
  email: string;
  password: string;
  passwordConfirmation: string;

  constructor(user?: IUser) {
    if (!user) return this;

    this.username = user.username;
    this.firstName = user.firstName;
    this.lastName = user.lastName;
    this.birthDate = user.birthDate;
    this.email = user.email;
    this.password = user.password;
    this.passwordConfirmation = user.passwordConfirmation;
  }
}
