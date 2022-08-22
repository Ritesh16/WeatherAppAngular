import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map, Observable, take } from 'rxjs';
import { SelectedCityHeaderService } from '../_services/selected-city-header.service';

@Injectable({
  providedIn: 'root'
})
export class SelectedCityGuard implements CanActivate {
  constructor(private selectedCityService: SelectedCityHeaderService, 
              private router: Router) {
    
  }

  canActivate(): Observable<boolean> {
    const selectedCity = this.selectedCityService.currentCity$.pipe(take(1)).subscribe(c=>{
      return c;
    });

    if(!selectedCity.closed){ 
      this.router.navigateByUrl('/');
    }

    return this.selectedCityService.currentCity$.pipe(
      map(city => {
        if(city){
          return true;
        }
        else{
          return false;
        }
      })
    )
  }
  
}
