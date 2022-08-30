import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { City } from '../_models/city';
import { noop, Observable, Observer, of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { SearchCity } from '../_models/searchCity';
import { Output } from '../_models/output';

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

  searchNewCity(search: string) {
    return this.http.get<SearchCity[]>(
      'https://api.openweathermap.org/geo/1.0/direct?appid=' + environment.key + '&limit=100', {
      params: { q: search }
    });
  }

  saveCity(city: City) {
    return this.http.post<Output<City>>(this.baseUrl + 'city/', city);
  }
}
