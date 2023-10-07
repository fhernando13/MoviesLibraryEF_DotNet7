import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { LoginService } from '../service/login/login.service';

//Sweetalert
import Swal from 'sweetalert2'

export const authGuard: CanActivateFn = () => {
  const tokenService = inject(LoginService);
  const routerService = inject(Router);
  const token = tokenService.isLoggedIn();

  if(!token){
    Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: 'You must log in!'
    });
    routerService.navigate(['/login']);
    return false
  }
  return true;
};