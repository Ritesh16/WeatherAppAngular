export class SearchCity {
    name: string;
    lat: number;
    lon: number;
    country: string;
    state: string;

    /**
     *
     */
    constructor() {
        this.country = '';
        this.state = '';
        this.lat = 0;
        this.lon = 0;
        this.name = '';

        this.name = this.name + ', ' + this.state;    
    }
}