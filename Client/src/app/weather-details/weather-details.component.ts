import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CityWeather } from '../_models/cityWeather';
import { WeatherService } from '../_services/weather.service';

@Component({
  selector: 'app-weather-details',
  templateUrl: './weather-details.component.html',
  styleUrls: ['./weather-details.component.css']
})
export class WeatherDetailsComponent implements OnInit {
  cityWeather: CityWeather;

  constructor(private activatedRoute: ActivatedRoute, private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.loadWeather();
  }

  loadWeather() {
    const cityId = +this.activatedRoute.snapshot.params['id'];
    this.weatherService.getWeather(cityId).subscribe(weather => {
      this.cityWeather = weather;
      console.log(cityId, this.cityWeather);
    });
  }

}
