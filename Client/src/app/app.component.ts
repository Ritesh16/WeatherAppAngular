import { Component, OnInit } from '@angular/core';
import { concat, mergeMap, switchMap, zipAll } from 'rxjs';
import { City } from './_models/city';
import { CityWeather } from './_models/cityWeather';
import { CityService } from './_services/city.service';
import { WeatherService } from './_services/weather.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Weather Application';
  cities: City[] = [];
  weathers: CityWeather[] = [];
  
  constructor(private cityService: CityService, private weatherService: WeatherService) {

  }
  ngOnInit(): void {
    this.loadCities();
   
  }

  loadCities(){
    return this.cityService.getCities().pipe(
      switchMap((cities) => {
       const requests = cities.map((city) => 
       this.weatherService.getWeather(city.id));
      return concat(requests).pipe(zipAll());
      }
       )).subscribe(data => {
         this.weathers = data;
       }); 
  }
}
