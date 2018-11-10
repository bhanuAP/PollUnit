import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../models/User';

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
  user: User = new User();

  Login() {
    this.userService.login(this.user)
    .subscribe((data:object) => {
      this.data = data;
      alert(JSON.stringify(data));
    });
  }
  
}
