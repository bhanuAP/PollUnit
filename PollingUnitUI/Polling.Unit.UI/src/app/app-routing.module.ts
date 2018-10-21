import { RouterModule, Routes }  from '@angular/router';

import { LoginComponent } from './login/login.component';
import { CreateAccountComponent } from './crete-account/crete-account.component';

const routes: Routes = [
  { path: '', component: CreateAccountComponent },
  { path: 'createAccount', component: LoginComponent },
  { path: 'createAcc', component: LoginComponent },
  { path: 'login', component: LoginComponent },
];

export const AppRoutingModule = RouterModule.forRoot(routes);
