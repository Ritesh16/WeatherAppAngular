import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';
import { WeatherStatisticsService } from '../_services/weather-statistics.service';
import { take } from 'rxjs/operators';
import { Statistics } from '../_models/statistics';

@Component({
  selector: 'app-cold-days',
  templateUrl: './cold-days.component.html',
  styleUrls: ['./cold-days.component.css']
})
export class ColdDaysComponent implements OnInit {

  @Input() month: number;
  @Input() year: number;

  selectedCity: SelectedCityHeaderDetail;
  coldestDay: Statistics;
  topColdDays: Statistics[];

  constructor(private weatherStatisticsService: WeatherStatisticsService, 
      private selectedCityHeaderService: SelectedCityHeaderService) {
        this.selectedCityHeaderService.currentCity$.pipe(take(1)).subscribe(city => {
          this.selectedCity = city;
      });
  }

  ngOnInit(): void {
    this.getTop5ColdDays();
    this.getColdestDay();
  }

  ngOnChanges() {
    this.getTop5ColdDays();
    this.getColdestDay();
  }

  getColdestDay() {
    this.weatherStatisticsService
        .getColdestDay(this.selectedCity.cityId, this.month, this.year)
        .subscribe(response => {
        this.coldestDay = response;
    });
  }

  getTop5ColdDays() {
    this.weatherStatisticsService
        .getTopColdDays(this.selectedCity.cityId, this.month, this.year, 5)
        .subscribe(response => {
        this.topColdDays = response;
    });
  }

}
