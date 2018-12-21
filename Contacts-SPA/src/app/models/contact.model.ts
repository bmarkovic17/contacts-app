interface Contact {
  contactId: number;
  addressId: number;
  name: string;
  surname: string;
  dateOfBirth: string;
  address: Address;
  contactData: ContactData[];
  contactTag: ContactTag[];
}
