import { Component, Input, OnInit } from '@angular/core';
import { CityWeather } from '../_models/cityWeather';

@Component({
  selector: 'app-weather-card',
  templateUrl: './weather-card.component.html',
  styleUrls: ['./weather-card.component.css']
})
export class WeatherCardComponent implements OnInit {
@Input() weather: CityWeather;

  constructor() { }

  ngOnInit(): void {
  }

}
