import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { LoginService } from '../service/login/login.service';
import { Router } from '@angular/router';

//Sweetalert
import Swal from 'sweetalert2'

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private loginService: LoginService,
              private router: Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const myToken = this.loginService.getToken();

    if(myToken){
      request =  request.clone({
        setHeaders: {Authorization: `Bearer ${myToken}`}
      })
    }

    return next.handle(request).pipe(
      catchError((err:any)=>{
        if(err instanceof HttpErrorResponse){
          if(err.status === 401){
            Swal.fire({
              icon: 'error',
              title: 'Token is expired',
              text: 'Please login again!'          
            });
            this.router.navigate(['/login']);
          }
        }
        return throwError(()=> new Error("Some another error ocurred"))
      })
    );
  }
}	
