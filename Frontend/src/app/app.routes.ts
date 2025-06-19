import { Routes } from '@angular/router';
import { CategoryListComponent } from './components/category-list/category-list';
import { AppComponent } from './app';
import { MainPageComponent } from './layouts/layouts/main-page/main-page';

export const routes: Routes = [
    { path: 'Category', component: CategoryListComponent },
    {path: '' , component: MainPageComponent}
];
