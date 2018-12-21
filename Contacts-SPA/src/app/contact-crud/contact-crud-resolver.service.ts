import { Injectable } from '@angular/core';
import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';

import { ContactsService } from '../services/contacts.service';

@Injectable({
  providedIn: 'root'
})
export class ContactCrudResolver implements Resolve<Contact> {
  constructor(private contactsService: ContactsService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Contact> | Promise<Contact> | Contact {
    return this.contactsService.getContact(+route.params['contactId']);
  }
}
