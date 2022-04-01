import { conditionallyCreateMapObjectLiteral } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  submitted = false;
  form: FormGroup = new FormGroup({
    userName: new FormControl(''),
  });

  constructor(private service:SharedService, private formBuilder: FormBuilder) {
  }

  userName= "";
  userLatitude:any;
  userLongitude:any;

  ngOnInit(): void {
    this.form = this.formBuilder.group(
      {
        userName: ['', Validators.required]
      });

    if(!navigator.geolocation){
      console.log('Location is not supported');
    }
    navigator.geolocation.getCurrentPosition((position)=>{
      this.userLatitude = position.coords.latitude;
      this.userLongitude = position.coords.longitude;
      console.log(
        `lat: ${position.coords.latitude}, lon: ${position.coords.longitude}`
        );
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  addUserLocation(){
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    var val =
    {
      userName:this.userName,
      latitude:this.userLatitude.toString(),
      longitude:this.userLongitude.toString()
    };

    this.service.addUserLocation(val).subscribe(res=>{
      console.log(res);
      alert(res);
    });
  }

}
