import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContactsComponent } from './contacts/contacts.component';
import { ContactCrudComponent } from './contact-crud/contact-crud.component';
import { ContactCrudResolver } from './contact-crud/contact-crud-resolver.service';

const routes: Routes = [
  { path: '', redirectTo: '/contacts', pathMatch: 'full' },
  { path: 'contacts', component: ContactsComponent },
  { path: 'contacts/new', component: ContactCrudComponent, data: { mode: 'new' }},
  { path: 'contacts/:contactId', component: ContactCrudComponent, resolve: { contact: ContactCrudResolver }, data: { mode: 'edit' }},
  { path: '**', redirectTo: '/contacts' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
