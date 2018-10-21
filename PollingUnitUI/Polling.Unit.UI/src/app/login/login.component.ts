import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private userService : UserService) { }

  data: object;
  showError: string;
  password: string;
  user = {
    ID: "",
    password: ""
  }

  Login() {
    this.userService.login(this.user)
    .subscribe((data:object) => {
      this.data = data;
      alert(JSON.stringify(data));
    });
  }
  
}
