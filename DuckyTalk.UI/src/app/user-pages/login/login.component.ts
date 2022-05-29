import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { UserService } from "src/app/services/user.service";
import { Auth } from "src/app/shared/models/auth.model";
import { User } from "src/app/shared/models/user.model";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  user: Auth;
  isLoading = false;
  submitted = false;

  constructor(
    protected formBuilder: FormBuilder,
    protected userService: UserService,
    protected router: Router,
    protected activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ["", Validators.required],
      password: ["", Validators.required],
    });
  }

  get formValues() {
    return this.loginForm.controls;
  }

  async onFormSubmit() {
    this.submitted = true;
    if (!this.loginForm.valid) {
      return;
    }
    const formValue = this.loginForm.getRawValue();
    this.user = new Auth(formValue);
    this.isLoading = true;
    try {
      await this.userService.login(this.user);
      this.router.navigate(["general-pages/main"]);
    } catch (e) {
      this.isLoading = false;
      console.log("Error login user: ", e);
    }
  }
}
