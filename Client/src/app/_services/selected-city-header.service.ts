import { EventEmitter, Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';

@Injectable({
  providedIn: 'root'
})
export class SelectedCityHeaderService {
  selectedCityHeaderDetail: SelectedCityHeaderDetail;
  selectedCityHeaderDetailEvent = new EventEmitter<SelectedCityHeaderDetail>();
  private currentCitySource = new ReplaySubject<SelectedCityHeaderDetail>(1);
  currentCity$ = this.currentCitySource.asObservable();
  constructor() { }

  setWeatherTitle(selectedCityHeaderDetail: SelectedCityHeaderDetail) {
    this.selectedCityHeaderDetailEvent.emit(selectedCityHeaderDetail);
    this.currentCitySource.next(selectedCityHeaderDetail);
  }
}
