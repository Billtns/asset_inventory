
import { Routes } from '@angular/router';
import { AppLayoutComponent } from './layout/app-layout.component';
import { CategoriesComponent } from './pages/categories/categories.component';
import { AssetsComponent } from './pages/assets/assets.component';

export const routes: Routes = [
  {
    path: '',
    component: AppLayoutComponent,
    children: [
      { path: 'assets', component: AssetsComponent ,data: { title: 'Assets' }},
      { path: 'categories', component: CategoriesComponent ,data: { title: 'Categories' }},
      { path: '', redirectTo: 'assets', pathMatch: 'full' }
    ]
  }
];
