import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CityWeather } from '../_models/cityWeather';
import { WeatherHistory } from '../_models/weatherHistory';

@Injectable({
  providedIn: 'root'
})
export class WeatherHistoryService {
baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getWeatherHistoryByCityId(cityId: number, month: number, year: number) {
    let url = this.baseUrl + 'city/' + cityId + '/weather/history';
    if(month > 0) {
      url = url + '/month/' + month;
    }

    if(year > 0) {
      url = url + '/year/' + year;
    }

    return this.http.get<WeatherHistory[]>(url)
    .pipe(map(response => {
      return response;
    }));
  }

  getWeatherHistoryByCityName(cityName: string, month: number, year: number) {
    let url = this.baseUrl + 'city/' + cityName + '/weather/history/';
    if(month > 0) {
      url = url + '/month/' + month;
    }

    if(year > 0) {
      url = url + '/year/' + year;
    }

    return this.http.get<WeatherHistory[]>(url)
    .pipe(map(response => {
      return response;
    }));
  }

  getWeatherHistoryOfDayByCityId(cityId: number, month: number, day: number, year: number) {
    let url = this.baseUrl + 'city/' + cityId + '/weather/history/';
    if(month > 0) {
      url = url + '/month/' + month;
    }

    if(day > 0) {
      url = url + '/day/' + day;
    }

    if(year > 0) {
      url = url + '/year/' + year;
    }

    return this.http.get<CityWeather>(url)
    .pipe(map(response => {
      return response;
    }));
  }

  getWeatherHistoryOfDayByCityName(cityName: string, month: number, day: number, year: number) {
    let url = this.baseUrl + 'city/' + cityName + '/weather/history/';
    if(month > 0) {
      url = url + '/month/' + month;
    }

    if(day > 0) {
      url = url + '/day/' + day;
    }

    if(year > 0) {
      url = url + '/year/' + year;
    }

    return this.http.get<CityWeather>(url)
    .pipe(map(response => {
      return response;
    }));
  }
}
