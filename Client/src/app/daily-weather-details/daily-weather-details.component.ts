import { Component, OnInit, Input } from '@angular/core';
import { Daily } from '../_models/cityWeather';

@Component({
  selector: 'app-daily-weather-details',
  templateUrl: './daily-weather-details.component.html',
  styleUrls: ['./daily-weather-details.component.css']
})
export class DailyWeatherDetailsComponent implements OnInit {
@Input() dailyWeatherDetails : Daily[];

  constructor() { }

  ngOnInit(): void {
  }

}
