import { catchError } from 'rxjs/operators';
import { UserService } from '../_services/user.service';
import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { AlertifyService } from '../_services/alertify.service';
import { of, Observable } from 'rxjs';

@Injectable()
export class MemberDetailResolver implements Resolve<User>{
  constructor(
    private userService: UserService,
    private router: Router,
    private alertify: AlertifyService
  ){}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this.userService.getUser(route.params['id']).pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/members']);
        return of(null);
      })
    );
  }
}
