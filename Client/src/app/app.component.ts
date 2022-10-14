import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpClientModule} from  '@angular/common/http';
import { IProduct } from './models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Client';
  products:any;
  constructor(private http: HttpClient) {
  }
  ngOnInit(): void {
    this.http.get('http://localhost:42998/api/products').subscribe((response: any)=>{
      console.log(response);
      this.products=response;
    })
  }
  
}
