import { Component, Input, OnInit } from '@angular/core';
import { CityWeather } from '../_models/cityWeather';

@Component({
  selector: 'app-hourly-rain-check',
  templateUrl: './hourly-rain-check.component.html',
  styleUrls: ['./hourly-rain-check.component.css']
})
export class HourlyRainCheckComponent implements OnInit {
 @Input() weather: CityWeather;
  
  constructor() { }

  ngOnInit(): void {
  }

}
