import { EventEmitter, Injectable } from '@angular/core';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';

@Injectable({
  providedIn: 'root'
})
export class SelectedCityHeaderService {
  selectedCityHeaderDetail: SelectedCityHeaderDetail;
  selectedCityHeaderDetailEvent = new EventEmitter<SelectedCityHeaderDetail>();

  constructor() { }

  setWeatherTitle(selectedCityHeaderDetail: SelectedCityHeaderDetail) {
    this.selectedCityHeaderDetailEvent.emit(selectedCityHeaderDetail);
  }
}
