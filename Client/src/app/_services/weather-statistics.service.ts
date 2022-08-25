import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Statistics } from '../_models/statistics';

@Injectable({
  providedIn: 'root'
})
export class WeatherStatisticsService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { 
  }

  getTotalCloudyDays(cityId: number, month: number, year: number) {
    return this.http.get<number>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/TotalCloudyDays/Month/' + month +  '/Year/' + year);
  }

  getTotalRainyDays(cityId: number, month: number, year: number) {
    return this.http.get<number>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/TotalRainyDays/Month/' + month +  '/Year/' + year);
  }
  
  getCloudyDays(cityId: number, month: number, year: number) {
    return this.http.get<Statistics[]>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/CloudyDays/Month/' + month +  '/Year/' + year);
  }

  getRainyDays(cityId: number, month: number, year: number) {
    return this.http.get<Statistics[]>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/RainyDays/Month/' + month +  '/Year/' + year);
  }

  getColdestDay(cityId: number, month: number, year: number) {
    return this.http.get<Statistics>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/ColdestDay/Month/' + month +  '/Year/' + year);
  }

  getTopColdDays(cityId: number, month: number, year: number, top: number) {
    return this.http.get<Statistics[]>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/ColdestDay/Month/' + month +  '/Year/' + year + '/Top/' + top);
  }

  getHottestDay(cityId: number, month: number, year: number) {
    return this.http.get<Statistics>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/HottestDay/Month/' + month +  '/Year/' + year);
  }

  getTopHotDays(cityId: number, month: number, year: number, top: number) {
    return this.http.get<Statistics[]>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/HottestDay/Month/' + month +  '/Year/' + year + '/Top/' + top);
  }

}
