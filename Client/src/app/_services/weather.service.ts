import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CityWeather } from '../_models/cityWeather';
import { environment } from 'src/environments/environment';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  baseUrl = environment.apiUrl;
  weatherCache = new Map();

  constructor(private http: HttpClient) { 
  }

  getWeather(cityId: number) {
    var response = this.weatherCache.get(cityId);
    if(response) {
      return of(response);
    }

    return this.http.get<CityWeather>(this.baseUrl + 'city/' + cityId + '/Weather')
            .pipe(map(response => {
              this.weatherCache.set(cityId, response);
              return response;
            }));
  }
}
