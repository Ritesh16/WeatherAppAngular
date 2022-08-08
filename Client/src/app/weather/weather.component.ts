import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { CityWeather } from '../_models/cityWeather';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';
import { WeatherService } from '../_services/weather.service';


@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  weather: CityWeather;

  constructor(private activatedRoute: ActivatedRoute,
             private weatherService: WeatherService,
             private selectedCityHeaderService: SelectedCityHeaderService) { }

  ngOnInit(): void {
    this.loadWeather();
  }

  loadWeather() {
    const cityId = +this.activatedRoute.snapshot.params['id'];
    this.weatherService.getWeather(cityId).subscribe(weather => {
      this.weather = weather;

      const selectedCityHeaderDetail = new SelectedCityHeaderDetail();
      selectedCityHeaderDetail.cityName = weather.cityName;
      selectedCityHeaderDetail.dateTime = this.weather.weatherModel.current.dt;
      selectedCityHeaderDetail.temp = this.weather.weatherModel.current.temp;
      selectedCityHeaderDetail.icon = this.weather.weatherModel.current.weather[0].icon;
      this.selectedCityHeaderService.selectedCityHeaderDetailEvent.emit(selectedCityHeaderDetail);
    });
  }
}
