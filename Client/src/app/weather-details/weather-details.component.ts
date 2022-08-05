import { Component, Input, OnInit } from '@angular/core';
import { CityWeather } from '../_models/cityWeather';

@Component({
  selector: 'app-weather-details',
  templateUrl: './weather-details.component.html',
  styleUrls: ['./weather-details.component.css']
})
export class WeatherDetailsComponent implements OnInit {
  @Input() weather: CityWeather;

  constructor() { }

  ngOnInit(): void {
  }

}
