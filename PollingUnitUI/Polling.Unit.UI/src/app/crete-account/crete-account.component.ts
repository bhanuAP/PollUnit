import { Component, OnInit } from '@angular/core';
import { User } from '../models/User';
import { UserService } from '../user.service';

@Component({
  selector: 'app-crete-account',
  templateUrl: './crete-account.component.html',
  styleUrls: ['./crete-account.component.css']
})
export class CreateAccountComponent {

  user: User = new User();

  constructor(private userService : UserService) { }

  CreateAccount() {
    this.userService.createAccount(this.user)
    .subscribe((data:object) => {
      var object = JSON.stringify(data);
      alert(object);
    });
  }

}
