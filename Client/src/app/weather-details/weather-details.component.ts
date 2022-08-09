import { Component, Input, OnInit } from '@angular/core';
import { CityWeather } from '../_models/cityWeather';

import { getBsVer, IBsVersion } from 'ngx-bootstrap/utils';

@Component({
  selector: 'app-weather-details',
  templateUrl: './weather-details.component.html',
  styleUrls: ['./weather-details.component.css']
})
export class WeatherDetailsComponent implements OnInit {
  @Input() weather: CityWeather;

  ngOnInit(): void {

  }
  get _getBsVer(): IBsVersion {
    return getBsVer();
  }

}
