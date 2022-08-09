import { Component, OnInit, Input } from '@angular/core';
import { Hourly } from '../_models/cityWeather';

import { getBsVer, IBsVersion } from 'ngx-bootstrap/utils';

@Component({
  selector: 'app-hourly-weather-details',
  templateUrl: './hourly-weather-details.component.html',
  styleUrls: ['./hourly-weather-details.component.css']
})
export class HourlyWeatherDetailsComponent implements OnInit {
@Input() hourlyWeatherDetails: Hourly[]

  constructor() { }

  ngOnInit(): void {
  }
  get _getBsVer(): IBsVersion {
    return getBsVer();
  }
}
