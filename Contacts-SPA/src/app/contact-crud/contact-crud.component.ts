import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Data, Router } from '@angular/router';
import { FormControl, FormGroup, FormArray, Validators } from '@angular/forms';
import { ContactsService } from '../services/contacts.service';
import { DateAdapter } from '@angular/material';
import { MAT_DATE_LOCALE } from '@angular/material';
import { MomentDateAdapter } from '@angular/material-moment-adapter';

import * as _moment from 'moment';

const moment = _moment;

@Component({
    selector: 'app-contact-crud',
    templateUrl: './contact-crud.component.html',
    styleUrls: ['./contact-crud.component.css'],
    providers: [
        {provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},
    ]
})
export class ContactCrudComponent implements OnInit {
    mode: string;
    contact: Contact;
    toggle = new FormControl(false);
    contactForm: FormGroup;

    constructor(
        private route: ActivatedRoute,
        private contactsService: ContactsService,
        private router: Router) { }

    ngOnInit() {
        this.route.data.subscribe(
            (data: Data) => {
                this.mode = data['mode'];

                if (this.mode === 'edit') {
                    this.contact = data['contact'];
                } else if (this.mode === 'new') {
                    this.contact = {
                        contactId: null,
                        addressId: null,
                        name: null,
                        surname: null,
                        dateOfBirth: null,
                        address: {
                            addressId: null,
                            street: null,
                            addressNumber: null,
                            postcode: null,
                            city: null,
                            country: null,
                            contacts: null
                        },
                        contactData: [{
                            contactDataId: null,
                            contactId: null,
                            contactDataType: null,
                            contactDataStatus: null,
                            contactDataValue: null,
                            contact: null
                        }],
                        contactTag: []
                    };

                    this.toggle.setValue(true);
                }
            });

        this.contactForm = new FormGroup({
            'fullName': new FormControl({
                value: this.mode === 'new' ? '' : (this.contact.name ? this.contact.name + ' ' : '') + this.contact.surname,
                disabled: this.mode === 'new' ? false : true
            },
                Validators.required),
            'dateOfBirth': new FormControl({
                value: this.mode === 'new' ? null : moment(this.contact.dateOfBirth),
                disabled: this.mode === 'new' ? false : true
            },
                Validators.required),
            'street': new FormControl({
                value: this.mode === 'new' ? '' : this.contact.address.street,
                disabled: this.mode === 'new' ? false : true
            },
                Validators.required),
            'addressNumber': new FormControl({
                value: this.mode === 'new' ? '' : this.contact.address.addressNumber,
                disabled: this.mode === 'new' ? false : true
            },
                Validators.required),
            'postcode': new FormControl({
                value: this.mode === 'new' ? '' : this.contact.address.postcode,
                disabled: this.mode === 'new' ? false : true
            },
                Validators.required),
            'city': new FormControl({
                value: this.mode === 'new' ? '' : this.contact.address.city,
                disabled: this.mode === 'new' ? false : true
            },
                Validators.required),
            'country': new FormControl({
                value: this.mode === 'new' ? '' : this.contact.address.country,
                disabled: this.mode === 'new' ? false : true
            },
                Validators.required),
            'contactDataPhone': new FormArray([]),
            'contactDataMail': new FormArray([])
        });

        if (this.mode === 'edit') {
            for (const contactData of this.contact.contactData) {
                if (contactData.contactDataType === 'PHONE' && contactData.contactDataStatus === 'Y') {
                    (<FormArray>this.contactForm.get('contactDataPhone')).push(
                        new FormControl({
                            value: contactData.contactDataValue,
                            disabled: true
                        },
                            Validators.required));
                } else if (contactData.contactDataType === 'MAIL' && contactData.contactDataStatus === 'Y') {
                    (<FormArray>this.contactForm.get('contactDataMail')).push(
                        new FormControl({
                            value: contactData.contactDataValue,
                            disabled: true
                        },
                            [Validators.required, Validators.email]));
                }
            }
        }

        this.toggle.valueChanges.subscribe(
            () => {
                this.toggle.value ? this.contactForm.enable() : this.contactForm.disable();
            }
        );
    }

    delete() {
        this.contactsService.deleteContact(this.contact.contactId).subscribe(
            () => {
                this.router.navigate(['/contacts']);
            }
        );
    }

    deleteContactData(contactDataType: string, index: number) {
        switch (contactDataType) {
            case 'phone':
                (<FormArray>this.contactForm.get('contactDataPhone')).removeAt(index);
                break;
            case 'mail':
                (<FormArray>this.contactForm.get('contactDataMail')).removeAt(index);
                break;
            default:
                break;
        }

        this.contactForm.markAsDirty();
    }

    addContactDataForm(type: string) {
        switch (type) {
            case 'phone':
                (<FormArray>this.contactForm.get('contactDataPhone')).push(new FormControl(null, Validators.required));
                break;
            case 'mail':
                (<FormArray>this.contactForm.get('contactDataMail')).push(new FormControl(null, [Validators.required, Validators.email]));
                break;
            default:
                break;
        }
    }

    save() {
        const fullNameArray = this.contactForm.value.fullName.split(' ');

        this.contact.name = fullNameArray.length > 1 ? fullNameArray[0] : null;
        this.contact.surname = fullNameArray.length > 1 ? fullNameArray.slice(1).join(' ') : this.contactForm.value.fullName;
console.log (this.contactForm.value.dateOfBirth);
        // means date has changed
        if (typeof this.contactForm.value.dateOfBirth._i === 'object') {
            this.contact.dateOfBirth = moment([
                this.contactForm.value.dateOfBirth._i.year,
                this.contactForm.value.dateOfBirth._i.month,
                this.contactForm.value.dateOfBirth._i.date]).format('YYYY-MM-DDTHH:mm:ss');
        }

        this.contact.address.street = this.contactForm.value.street;
        this.contact.address.addressNumber = this.contactForm.value.addressNumber;
        this.contact.address.postcode = this.contactForm.value.postcode;
        this.contact.address.city = this.contactForm.value.city;
        this.contact.address.country = this.contactForm.value.country;

        if (this.contact.contactData.length) {
            this.contact.contactData.splice(0, this.contact.contactData.length);
        }

        for (const contactData of (<FormArray>this.contactForm.get('contactDataPhone')).controls) {
            this.contact.contactData.push({
                contactDataId: null,
                contactId: this.contact.contactId,
                contactDataType: 'PHONE',
                contactDataStatus: 'Y',
                contactDataValue: contactData.value,
                contact: null
            });
        }

        for (const contactData of (<FormArray>this.contactForm.get('contactDataMail')).controls) {
            this.contact.contactData.push({
                contactDataId: null,
                contactId: this.contact.contactId,
                contactDataType: 'MAIL',
                contactDataStatus: 'Y',
                contactDataValue: contactData.value,
                contact: null
            });
        }

        if (this.mode === 'new') {
            this.contactsService.addContact(this.contact).subscribe(
                () => {
                    this.router.navigate(['/contacts']);
                }
            );
        } else if (this.mode === 'edit') {
            this.contactsService.updateContact(this.contact.contactId, this.contact).subscribe(
                () => {
                    this.contactsService.getContact(this.contact.contactId).subscribe(
                        (data) => {
                            this.contact = data;
                            this.toggle.setValue(!this.toggle.value);
                        }
                    );
                },
                () => {
                    // update without real change
                    this.toggle.setValue(!this.toggle.value);
                }
            );
        }
    }
}
