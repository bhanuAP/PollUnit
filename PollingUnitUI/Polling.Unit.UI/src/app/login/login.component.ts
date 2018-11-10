import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../models/User';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private router: Router, 
    private userService : UserService
    ) { }

  invalidCredentials: boolean = false;
  loginAccountForm: FormGroup;
  user: User = new User();
  message: string;

  Login() {
    this.user.UserId = this.loginAccountForm.controls.userId.value;
    this.user.Password = this.loginAccountForm.controls.password.value;
    this.userService.loginAccount(this.user, this.callback.bind(this));
  }

  callback(response: object) {
    if(response["statusCode"] == 302 && response["url"] == "/login") {
      this.message = response["message"];
      this.invalidCredentials = true;
    }
    if(response["statusCode"] == 302 && response["url"] == "/home") {
      this.router.navigate(['/home']);
    }
  }
  
  ngOnInit() {
    this.loginAccountForm = new FormGroup({
      userId: new FormControl(),
      password: new FormControl()
    });
  }

}
