import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CityWeather } from '../_models/cityWeather';
import { WeatherHistoryService } from '../_services/weather-history.service';

@Component({
  selector: 'app-weather-history-details',
  templateUrl: './weather-history-details.component.html',
  styleUrls: ['./weather-history-details.component.css']
})
export class WeatherHistoryDetailsComponent implements OnInit {
  weather: CityWeather;

  constructor(private route: ActivatedRoute, private weatherHistoryService: WeatherHistoryService) { }

  ngOnInit(): void {
    const cityParam = this.route.snapshot.paramMap.get('id');
    let dateParam = this.route.snapshot.paramMap.get('date');

    let cityId:number =0;
    if(cityParam) {
      cityId = +cityParam;
    }

    const date = new Date(dateParam==null? new Date() : dateParam);
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear();

    this.loadWeatherHistory(cityId, month, day, year);
  }

  loadWeatherHistory(cityId: number, month: number, day: number, year: number) {
      this.weatherHistoryService.getWeatherHistoryOfDayByCityId(cityId, month, day, year)
        .subscribe(response => {
          this.weather = response;
      });
        
  }

}
