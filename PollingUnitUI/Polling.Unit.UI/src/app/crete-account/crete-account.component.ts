import { Component, OnInit } from '@angular/core';
import { User } from '../models/User';
import { UserService } from '../user.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crete-account',
  templateUrl: './crete-account.component.html',
  styleUrls: ['./crete-account.component.css']
})
export class CreateAccountComponent implements OnInit {
  
  invalidCredentials: boolean = false;
  createAccountForm: FormGroup;
  user: User = new User();
  message: string;

  constructor(
    private router: Router, 
    private userService : UserService
  ) { }

  createAccount() {
    this.user.UserId = this.createAccountForm.controls.userId.value;
    this.user.Password = this.createAccountForm.controls.password.value;
    this.userService.createAccount(this.user, this.callback.bind(this));
  }

  callback(response: object) {
    if(response["statusCode"] == 302 && response["url"] == "/createAccount") {
      this.message = response["message"];
      this.invalidCredentials = true;
    }
    if(response["statusCode"] == 302 && response["url"] == "/login") {
      this.router.navigate(['/login']);
    }
  }

  ngOnInit() {
    this.createAccountForm = new FormGroup({
      userId: new FormControl(),
      password: new FormControl()
    });
  }
  
}
