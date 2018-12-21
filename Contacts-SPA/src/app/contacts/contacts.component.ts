import { Component, OnInit } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material';
import { ContactsService } from '../services/contacts.service';

import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { debounceTime, startWith, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  filter = new FormControl('Search...');
  previousFilter: string;
  contacts: Observable<Contact>;

  readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  setValue(action: string): void {
    switch (action) {
      case 'focus':
        this.previousFilter = this.filter.value;
        this.filter.setValue('', { emitEvent: false });
        break;
      case 'blur':
        this.filter.setValue(this.filter.value ? this.filter.value :
          this.previousFilter ? this.previousFilter : 'Search...', { emitEvent: false });
        break;
      case 'clear':
        this.filter.reset();
        break;
      default:
        console.error('unsupported action => ', action);
    }
  }

  add(event: MatChipInputEvent, contactId: number): void {
    const input = event.input;
    const contactTagName = event.value;

    this.contactsService.addContactTag(contactId, contactTagName).subscribe(
      () => {
        // TODO: add new tag to chip list
      },
      () => {
        console.log('error occured');
      });

    if (input) {
      input.value = '';
    }
  }

  remove(contactTagId: number): void {
    this.contactsService.deleteContactTag(contactTagId).subscribe(
      () => {
        // TODO: remove tag from chip list
      },
      () => {
        console.log('error occured');
      });
  }

  constructor(private contactsService: ContactsService) { }

  ngOnInit() {
    this.contacts = this.filter.valueChanges.pipe<Contact>(
      debounceTime(300),
      startWith(''),
      switchMap(filter => this.contactsService.getContacts(filter))
    );
  }
}
