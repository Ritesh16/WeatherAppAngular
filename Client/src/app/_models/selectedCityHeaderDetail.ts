export class SelectedCityHeaderDetail { 
    cityName: string;
    dateTime: number;
    temp: number;
    icon: string;
    cityId: number;
   
    constructor() {
      this.cityName = '';
      this.dateTime = 0;
      this.temp = 0;
      this.icon = '';
      this.cityId = 0;
    }
  }