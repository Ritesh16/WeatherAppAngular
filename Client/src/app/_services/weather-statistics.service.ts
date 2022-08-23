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
  
  getCloudyDays(cityId: number, month: number, year: number) {
    return this.http.get<Statistics[]>(this.baseUrl + 'city/' + cityId + '/Weather/Statistics/CloudyDays/Month/' + month +  '/Year/' + year);
  }
}
