import { Component, Input, OnInit } from '@angular/core';
import { CityWeather } from '../_models/cityWeather';
import { concat, mergeMap, switchMap, zipAll } from 'rxjs';

import { City } from '../_models/city';
import { WeatherService } from '../_services/weather.service';
import { CityService } from '../_services/city.service';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  cities: City[] = [];
  weathers: CityWeather[] = [];
  
  constructor(private cityService: CityService, private weatherService: WeatherService,
            private selectedCityHeaderService: SelectedCityHeaderService) {

  }
  ngOnInit(): void {
    this.loadCities();
    this.selectedCityHeaderService.setWeatherTitle(new SelectedCityHeaderDetail());
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
