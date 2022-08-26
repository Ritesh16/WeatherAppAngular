import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';
import { WeatherStatisticsService } from '../_services/weather-statistics.service';
import { take } from 'rxjs/operators';
import { Statistics } from '../_models/statistics';

@Component({
  selector: 'app-hot-days',
  templateUrl: './hot-days.component.html',
  styleUrls: ['./hot-days.component.css']
})
export class HotDaysComponent implements OnInit {
  @Input() month: number;
  @Input() year: number;

  selectedCity: SelectedCityHeaderDetail;
  hottestDay: Statistics;
  topHotDays: Statistics[];

  constructor(private weatherStatisticsService: WeatherStatisticsService, 
      private selectedCityHeaderService: SelectedCityHeaderService) {
        this.selectedCityHeaderService.currentCity$.pipe(take(1)).subscribe(city => {
          this.selectedCity = city;
      });
  }

  ngOnInit(): void {
    this.getTop5HotDays();
    this.getHottestDay();
  }

  ngOnChanges() {
    this.getTop5HotDays();
    this.getHottestDay();
  }

  getHottestDay() {
    this.weatherStatisticsService
        .getHottestDay(this.selectedCity.cityId, this.month, this.year)
        .subscribe(response => {
        this.hottestDay = response;
    });
  }

  getTop5HotDays() {
    this.weatherStatisticsService
        .getTopHotDays(this.selectedCity.cityId, this.month, this.year, 5)
        .subscribe(response => {
        this.topHotDays = response;
    });
  }

}
