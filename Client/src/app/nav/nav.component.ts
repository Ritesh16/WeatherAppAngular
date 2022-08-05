import { Component, OnInit } from '@angular/core';
import { SelectedCityHeaderDetail } from '../_models/selectedCityHeaderDetail';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  selectedCityHeaderDetail: SelectedCityHeaderDetail;
  constructor(private selectedCityHeaderService: SelectedCityHeaderService) { }

  ngOnInit(): void {
    this.selectedCityHeaderService.selectedCityHeaderDetailEvent.subscribe((selectedCityHeaderDetail:SelectedCityHeaderDetail) => {
      this.selectedCityHeaderDetail = selectedCityHeaderDetail;
    });
  }

}
