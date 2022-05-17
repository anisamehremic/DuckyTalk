import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
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
  
  constructor(
    protected formBuilder: FormBuilder,
    protected route: ActivatedRoute,
    protected router: Router,
    protected userService: UserService
  ) { }

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      birthday: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(6)]]
  });
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
      this.router.navigate(['user-pages' , 'login'])
    } catch (e) {
      this.isLoading=false;
      console.log('Error registration user: ', e);
    }
  }

}
