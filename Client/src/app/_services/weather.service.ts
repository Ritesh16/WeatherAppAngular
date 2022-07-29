import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CityWeather } from '../_models/cityWeather';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { 
  }

  getWeather(cityId: number) {
    return this.http.get<CityWeather>(this.baseUrl + 'city/' + cityId + '/Weather');
  }
}
