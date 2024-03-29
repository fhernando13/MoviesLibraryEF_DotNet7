import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Components
import { UserListComponent } from './component/Users/user-list/user-list.component';
import { UserFormComponent } from './component/Users/user-form/user-form.component';
import { UserDetailComponent } from './component/Users/user-detail/user-detail.component';
import { UserUpdateComponent } from './component/Users/user-update/user-update.component';
import { LoginComponent } from './component/login/login.component';
import { ActorsComponent } from './component/Actors/actors/actors.component';
import { GendersComponent } from './component/Genders/genders/genders.component';
import { MoviesComponent } from './component/Movies/movies/movies.component';

// Guards
import { authGuard } from './guards/auth.guard';


const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'usersForm', canActivate:[authGuard], component: UserFormComponent },
  { path: 'usersList', canActivate:[authGuard], component: UserListComponent },
  { path: 'usersDetails/:iduser', canActivate:[authGuard], component: UserDetailComponent },
  { path: 'usersUpdate/:iduser', canActivate:[authGuard], component: UserUpdateComponent },
  { path: 'movies', canActivate:[authGuard], component: MoviesComponent },
  { path: 'genders', canActivate:[authGuard], component: GendersComponent },
  { path: 'actors', canActivate:[authGuard], component: ActorsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
