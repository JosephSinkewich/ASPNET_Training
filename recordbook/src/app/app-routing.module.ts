import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EventsComponent } from './events/events.component';
import { CategoriesComponent } from './categories/categories.component';
import { RecordsComponent } from './records/records.component';
import { RolesComponent } from './roles/roles.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  
  { path: 'categories', component: CategoriesComponent },
  { path: 'events', component: EventsComponent },
  { path: 'records', component: RecordsComponent },
  { path: 'roles', component: RolesComponent },
  { path: 'users', component: UsersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
