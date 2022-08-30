import { Component, OnInit } from '@angular/core';
import { noop, Observable, Observer, of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { SearchCity } from '../_models/searchCity';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead';
import { CityService } from '../_services/city.service';
import { City } from '../_models/city';
 

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {
  search?: string;
  suggestions$?: Observable<SearchCity[]>;
  errorMessage?: string;
  successMessage?: string;
  newCity: SearchCity;
  cities: City[] = [];
 
  constructor(private cityService: CityService) {}
 
  ngOnInit(): void {
    this.searchCity();
    this.loadCities();
  }

  loadCities() {
    return this.cityService.getCities()
          .subscribe(cities => {
              this.cities = cities;
          }); 
  }
  
  searchCity() {
    this.suggestions$ = new Observable((observer: Observer<string | undefined>) => {
      observer.next(this.search);
    }).pipe(
      switchMap((query: string) => {
        if (query) {
          return this.cityService.searchNewCity(query).pipe(
            map((data: SearchCity[]) => data || []),
            tap(() => noop, err => {
              this.errorMessage = err && err.message || 'Something goes wrong';
            })
          );
        }
 
        return of([]);
      })
    );
  }

  typeaheadOnSelect(e: TypeaheadMatch): void {
    this.search = e.item.name + ',' + e.item.state;
    this.newCity = e.item;
  }

  saveCity() {
    if(this.newCity) {
      let city = new City();
      city.country = this.newCity.country;
      city.latitude = this.newCity.lat;
      city.longitude = this.newCity.lon;
      city.name = this.newCity.name;
      city.state = this.newCity.state;
      
      this.cityService.saveCity(city).subscribe(response => {
        this.search = '';[]
        if(response.output){
          this.successMessage = "City saved successfully.";
          this.errorMessage = "";
          this.newCity = {} as SearchCity;
        }
        else{
          this.successMessage = "";
          this.errorMessage = response.message;
          this.newCity = {} as SearchCity;
        }

        this.loadCities();
      });
    }
    else{
      this.errorMessage = 'City not selected!';
    }


  }

  reset() {
    this.errorMessage = '';
    this.search = '';
  }
}
