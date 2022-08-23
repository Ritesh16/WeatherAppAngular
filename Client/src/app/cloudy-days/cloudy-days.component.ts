import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';
import { WeatherStatisticsService } from '../_services/weather-statistics.service';
import { take } from 'rxjs/operators';
import { Statistics } from '../_models/statistics';

@Component({
  selector: 'app-cloudy-days',
  templateUrl: './cloudy-days.component.html',
  styleUrls: ['./cloudy-days.component.css']
})
export class CloudyDaysComponent implements OnInit, OnChanges {
  @Input() month: number;
  @Input() year: number;

  selectedCity: SelectedCityHeaderDetail;
  totalCloudyDays: number;
  cloudyDays: Statistics[];

  constructor(private weatherStatisticsService: WeatherStatisticsService, 
      private selectedCityHeaderService: SelectedCityHeaderService) {
        this.selectedCityHeaderService.currentCity$.pipe(take(1)).subscribe(city => {
          this.selectedCity = city;
      });
  }

  ngOnInit(): void {
    this.getTotalCloudyDays();
    this.getCloudyDays();
  }

  ngOnChanges() {
    this.getTotalCloudyDays();
    this.getCloudyDays();
  }

  getTotalCloudyDays() {
    this.weatherStatisticsService
        .getTotalCloudyDays(this.selectedCity.cityId, this.month, this.year)
        .subscribe(response => {
        this.totalCloudyDays = response;
    });
  }

  getCloudyDays() {
    this.weatherStatisticsService
        .getCloudyDays(this.selectedCity.cityId, this.month, this.year)
        .subscribe(response => {
        this.cloudyDays = response;
    });
  }
}
