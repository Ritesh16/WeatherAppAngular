export class City {
    id: number;
    name: string;
    state: string;
    country: string;
    zipCode: string;
    latitude: number;
    longitude: number;
    isActive: boolean;
    dateCreated: Date;
    dateUpdated: Date;

    constructor() {
        this.id =  0;
        this.name = '';
        this.state = '';
        this.country = '';
        this.zipCode = 'N/A';
        this.isActive = true;
        this.latitude = 0;
        this.longitude = 0;
        this.dateCreated = new Date();
        this.dateUpdated = new Date();
    }
}