import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Alerts } from '../_models/cityWeather';

@Component({
  selector: 'app-weather-alerts',
  templateUrl: './weather-alerts.component.html',
  styleUrls: ['./weather-alerts.component.css']
})
export class WeatherAlertsComponent implements OnInit {
 @Input() alerts: Alerts[];

 modalRef?: BsModalRef;
 constructor(private modalService: BsModalService) {}

 openModal(template: TemplateRef<any>) {
   this.modalRef = this.modalService.show(template);
 }

  ngOnInit(): void {
  }

}
