import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderModel } from '../OrderModel';

@Component({
  selector: 'app-Oreder-Screen',
  templateUrl: './Oreder-Screen.component.html',
  styleUrls: ['./Oreder-Screen.component.css']
})
export class OrederScreenComponent implements OnInit {

  constructor(private http: HttpClient) { }
  page = 1;
  pageSize = 30;
  collection = 0;
  data: any;


  ngOnInit() {
    this.startHttpRequest();
  }


  private startHttpRequest = () => {
    this.http.get('https://localhost:44342/api/Order')
      .subscribe((data) => {
        this.data = data['result'];
        this.collection = this.data.length;
      });
  }
  get orders(): any {
    return this.data
      .map((stock, i) => ({ id: i + 1, ...stock }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

}
