import { AlertifyService } from './../_services/alertify.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService){};
  canActivate(): boolean {
    if (this.authService.loggedIn()){
      return true;
    }else{
      this.alertify.error('You shoul be logged to pass!');
      this.router.navigate(['/home']);
    }
  }
}
