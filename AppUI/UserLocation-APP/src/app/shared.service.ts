import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIURL = "https://localhost:7293";

  constructor(private http:HttpClient) { }

  getUserLocation():Observable<any[]>{
    return this.http.get<any>(this.APIURL + '/UserLocations');
  }

  addUserLocation(val:any){
    return this.http.post(this.APIURL+'/UserLocations',val);
  }
}
