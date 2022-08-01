import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { CityComponent } from './city/city.component';
import { WeatherDetailsComponent } from './weather-details/weather-details.component';
import { WeatherComponent } from './weather/weather.component';

const routes: Routes = [
  { path: '', component: WeatherComponent },
  { path: 'city', component: CityComponent },
  { path: 'city/:id/weather', component: WeatherDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
