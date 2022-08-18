import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CityComponent } from './city/city.component';
import { HomeComponent } from './home/home.component';
import { WeatherDetailsComponent } from './weather-details/weather-details.component';
import { WeatherHistoryDetailsComponent } from './weather-history-details/weather-history-details.component';
import { WeatherHistoryComponent } from './weather-history/weather-history.component';
import { WeatherComponent } from './weather/weather.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'city', component: CityComponent },
  { path: 'city/:id/weather', component: WeatherComponent },
  { path: 'weather-history', component: WeatherHistoryComponent },
  { path: 'city/:id/weather-history/:date', component: WeatherHistoryDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
