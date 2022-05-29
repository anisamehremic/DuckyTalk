import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InterestService } from 'src/app/services/interest.service';
import { UserService } from 'src/app/services/user.service';
import { Interest } from 'src/app/shared/models/interest.model';
import { UserInterests } from 'src/app/shared/models/userInterests.model';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  userInterests: Array<UserInterests> = [];
  userInterestsId: Array<number> = [];
  interests: Array<Interest> = [];
  user;
  formGroup: FormGroup;
  submitted = false

  constructor(protected userService: UserService, protected interestService: InterestService,
    protected formBuilder: FormBuilder,
    ) { }

  async ngOnInit() {
    this.user = await this.userService.getLoggedUser();
    this.userInterests = await (await this.interestService.getUserInterests(this.user.userId));
    this.userInterestsId = this.userInterests.map(a => a.interestId);
    console.log("ovo", this.userInterestsId )
    this.interests = await this.interestService.getInterests();

    this.formGroup = this.formBuilder.group({
      firstName: [this.user.firstName, Validators.required],
      lastName: [this.user.lastName, [Validators.required, Validators.minLength(4)]],
      birthday: [new Date(this.user.birthDate).toISOString().split('T')[0], Validators.required],
      username: [this.user.username, Validators.required],
      email: [this.user.email, [Validators.required, Validators.minLength(8)]],
  });

  }

  alreadyChecked(interestId: number): boolean{
   return !!this.userInterests.find(element => element.interestId === interestId);
  }

  checkInterest(event, interest) {
    if(event.target.checked) {
    this.userInterestsId.push(interest.interestId);
    } else {
      for(var i=0; i < this.interests.length; i++){
        if(this.userInterestsId[i] == interest.interestId){
          this.userInterestsId.splice(i,1);
        }
      }
    }
  }

  async onFormSubmit(){
    if (!this.formGroup.valid) {
      return;
    }
    if(this.userInterests.length == 0){
      alert('Please, check at least one interest!');
      return
    }

    const formValue = this.formGroup.getRawValue();
    let editedUser = {
      firstName: formValue.firstName,
      lastName: formValue.lastName,
      username: formValue.username,
      birthDate: new Date(formValue.birthday),
      email: formValue.email,
    };

    try {
      await this.userService.updateUser(this.user.userId, editedUser);
      console.log('User successfully updated: ', this.user.username);
      let newUser = await this.userService.getLoggedUser();
      this.userInterestsId.forEach(async interestId => {
        await this.interestService.saveUserInterests(newUser.userId, interestId);
      });
      this.submitted = true;
    } catch (e) {
      console.log('Error updating user: ', e);
    }
  }
}
