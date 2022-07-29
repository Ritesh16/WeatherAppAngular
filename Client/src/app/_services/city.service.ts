import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { City } from '../_models/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {
 baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { 
  }

  getCities() {
    return this.http.get<City[]>(this.baseUrl + 'city/');
  }

  getCity(cityId: number) {
    return this.http.get<City>(this.baseUrl + 'city/' + cityId);
  }
}
