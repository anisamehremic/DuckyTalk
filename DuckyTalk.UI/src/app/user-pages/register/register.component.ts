import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InterestService } from 'src/app/services/interest.service';
import { UserService } from 'src/app/services/user.service';
import { Interest } from 'src/app/shared/models/interest.model';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  formGroup: FormGroup;
  loading = false;
  submitted = false;
  isLoading = false;
  user: User;
  interests: Array<Interest> = [];
  userInterests: Array<any> = [];
  
  constructor(
    protected formBuilder: FormBuilder,
    protected route: ActivatedRoute,
    protected router: Router,
    protected userService: UserService,
    protected interestService: InterestService
  ) { }

  ngOnInit() {
    this.getInterests();

    this.formGroup = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      birthday: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      interest: ['']
  });
  }

  async getInterests(){
    try {
      this.interests = await this.interestService.getInterests();
      console.log('Interests are loaded: ', );
    } catch (e) {
      console.log('Error getting interests: ', e);
    }
  }

  checkInterest(event, interest) {
    if(event.target.checked) {
    this.userInterests.push(interest.interestId);
    } else {
      for(var i=0; i < this.interests.length; i++){
        if(this.userInterests[i] == interest.interestId){
          this.userInterests.splice(i,1);
        }
      }
    }
    console.log(this.userInterests);
  }


  get formValues() { return this.formGroup.controls; }

  async onFormSubmit(){
    this.submitted = true;
    if (!this.formGroup.valid) {
      return;
    }
    const formValue = this.formGroup.getRawValue();
    this.user = new User({
      firstName: formValue.firstName,
      lastName: formValue.lastName,
      birthDate: new Date(formValue.birthday),
      username: formValue.username,
      email: formValue.email,
      password: formValue.password,
      passwordConfirmation: formValue.confirmPassword
    });

    try {
      this.isLoading=true
      await this.userService.registration(this.user);
      console.log('User successfully created: ', this.user.username);
      // let newUser = await this.userService.getUsers().then(c => c.filter(x => x.username === this.user.username));
      // this.userInterests.forEach(async interest => {
      //   await this.interestService.saveUserInterests(newUser.userId, interest.interestId);
      // });
      this.router.navigate(['user-pages' , 'login'])
    } catch (e) {
      this.isLoading=false;
      console.log('Error registration user: ', e);
    }
  }

}
