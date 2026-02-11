
import { Routes } from '@angular/router';
import { AppLayoutComponent } from './layout/app-layout.component';
import { CategoriesComponent } from './pages/categories/categories.component';
import { AssetsComponent } from './pages/assets/assets.component';
import { UsersComponent } from './pages/users/users.component';

export const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      { path: 'categories', component: CategoriesComponent, data: { title: 'Categories' } },
      { path: 'assets', component: AssetsComponent, data: { title: 'Assets' } },
      { path: 'users', component: UsersComponent, data: { title: 'users' } },
      { path: '', redirectTo: 'assets', pathMatch: 'full' }
    ]
  }
];
