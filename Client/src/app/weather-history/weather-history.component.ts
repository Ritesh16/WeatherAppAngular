import { Component, OnInit } from '@angular/core';
import { SearchParamns } from '../_models/searchParams';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';
import { take } from 'rxjs/operators';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';
import { WeatherHistoryService } from '../_services/weather-history.service';
import { WeatherHistory } from '../_models/weatherHistory';

@Component({
  selector: 'app-weather-history',
  templateUrl: './weather-history.component.html',
  styleUrls: ['./weather-history.component.css']
})
export class WeatherHistoryComponent implements OnInit {
selectedCity: SelectedCityHeaderDetail;
weatherHistoryList: WeatherHistory[];

  months =  [
    { Value: 0, Text: '--All--' },
    { Value: 1, Text: 'Jan' },
    { Value: 2, Text: 'Feb' },
    { Value: 3, Text: 'Mar' },
    { Value: 4, Text: 'Apr' },
    { Value: 5, Text: 'May' },
    { Value: 6, Text: 'June' },
    { Value: 7, Text: 'July' },
    { Value: 8, Text: 'Aug' },
    { Value: 9, Text: 'Sep' },
    { Value: 10, Text: 'Oct' },
    { Value: 11, Text: 'Nov' },
    { Value: 12, Text: 'Dec' }
  ];

  years =  [
    { Value: 0, Text: '--All--' },
    { Value: 2022, Text: 2022 },
    { Value: 2023, Text: 2023 },
    { Value: 2024, Text: 2024 },
    { Value: 2025, Text: 2025 },
    { Value: 2026, Text: 2026 }
  ];

  searchParams: SearchParamns;

  constructor(private selectedCityHeaderService: SelectedCityHeaderService,
            private weatherHistoryService: WeatherHistoryService) { 
    this.searchParams = new SearchParamns();
    this.selectedCityHeaderService.currentCity$.pipe(take(1)).subscribe(city => {
    this.selectedCity = city;
    });

    this.loadWeatherHistory();
  }

  ngOnInit(): void {
  }

  loadWeatherHistory() {
    const cityId = this.selectedCity.cityId == null ? 0 : this.selectedCity.cityId;
    this.weatherHistoryService.getWeatherHistoryByCityId(cityId, 
            this.searchParams.month, this.searchParams.year)
            .subscribe(response => {
              this.weatherHistoryList = response;
            });
  }
  resetFilters(){
    this.searchParams = new SearchParamns();
  }
}
