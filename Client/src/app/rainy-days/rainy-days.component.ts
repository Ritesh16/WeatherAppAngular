import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';
import { WeatherStatisticsService } from '../_services/weather-statistics.service';
import { take } from 'rxjs/operators';
import { Statistics } from '../_models/statistics';

@Component({
  selector: 'app-rainy-days',
  templateUrl: './rainy-days.component.html',
  styleUrls: ['./rainy-days.component.css']
})
export class RainyDaysComponent implements OnInit {

  @Input() month: number;
  @Input() year: number;

  selectedCity: SelectedCityHeaderDetail;
  totalRainyDays: number;
  rainyDays: Statistics[];

  constructor(private weatherStatisticsService: WeatherStatisticsService, 
      private selectedCityHeaderService: SelectedCityHeaderService) {
        this.selectedCityHeaderService.currentCity$.pipe(take(1)).subscribe(city => {
          this.selectedCity = city;
      });
  }

  ngOnInit(): void {
    this.getTotalRainyDays();
    this.getRainyDays();
  }

  ngOnChanges() {
    this.getTotalRainyDays();
    this.getRainyDays();
  }

  getTotalRainyDays() {
    this.weatherStatisticsService
        .getTotalRainyDays(this.selectedCity.cityId, this.month, this.year)
        .subscribe(response => {
        this.totalRainyDays = response;
    });
  }

  getRainyDays() {
    this.weatherStatisticsService
        .getRainyDays(this.selectedCity.cityId, this.month, this.year)
        .subscribe(response => {
        this.rainyDays = response;
    });
  }

}
