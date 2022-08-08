import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CityComponent } from './city/city.component';
import { WeatherComponent } from './weather/weather.component';
import { WeatherCardComponent } from './weather-card/weather-card.component';
import { NavComponent } from './nav/nav.component';
import { WeatherDetailsComponent } from './weather-details/weather-details.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { HomeComponent } from './home/home.component';
import { ConvertToDatePipe } from './_pipes/convert-to-date.pipe';
import { ConvertToTimePipe } from './_pipes/convert-to-time.pipe';
import { ConvertToHgPipe } from './_pipes/convert-to-hg.pipe';
import { ConvertToPercPipe } from './_pipes/convert-to-perc.pipe';
import { ConvertToMilesPipe } from './_pipes/convert-to-miles.pipe';

@NgModule({
  declarations: [
    AppComponent,
    CityComponent,
    WeatherComponent,
    WeatherCardComponent,
    NavComponent,
    WeatherDetailsComponent,
    HomeComponent,
    ConvertToDatePipe,
    ConvertToTimePipe,
    ConvertToHgPipe,
    ConvertToPercPipe,
    ConvertToMilesPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TabsModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
