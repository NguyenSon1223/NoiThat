import { Routes } from '@angular/router';

import { MainPageComponent } from './layouts/layouts/main-page/main-page';
import { CategoryList } from './component/category/category-list/category-list';
import { Mainlayout } from './layouts/layouts/mainlayout/mainlayout';
import { CategoryCreate } from './component/category/category-create/category-create';

export const routes: Routes = [
  {
    path: '',
    component: Mainlayout,
    children: [
      { path: '', component: MainPageComponent },
      { path: 'category', component: CategoryList },
      {
        path: 'category/create',
        component: CategoryCreate,
      },
    ],
  },
];
