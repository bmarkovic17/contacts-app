import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {
  constructor(private http: HttpClient) { }

  getContacts(filter: string) {
    return this.http.get<Contact>(environment.baseUrl + '/contacts' + (filter ? '?filter=' + filter : ''));
  }

  getContact(contactId: number) {
    return this.http.get<Contact>(environment.baseUrl + '/contacts/' + contactId);
  }

  addContact(contact: Contact) {
    return this.http.post(environment.baseUrl + '/contacts/contact/new', contact);
  }

  updateContact(contactId: number, contact: Contact) {
    return this.http.put(environment.baseUrl + '/contacts/' + contactId, contact);
  }

  deleteContact(contactId: number) {
    return this.http.delete(environment.baseUrl + '/contacts/' + contactId);
  }

  deleteContactData(contactDataId: number) {
    return this.http.delete(environment.baseUrl + '/contacts/contactData/' + contactDataId);
  }

  addContactTag(contactId: number, contactTagName: string) {
    return this.http.post(environment.baseUrl + '/contacts/contactTag/new', { contactId: contactId, contactTagName: contactTagName });
  }

  deleteContactTag(contactTagId: number) {
    return this.http.delete(environment.baseUrl + '/contacts/contactTag/' + contactTagId);
  }
}
