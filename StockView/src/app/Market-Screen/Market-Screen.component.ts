import { Component, OnInit, AfterContentInit, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { MarketSignalRService } from '../Services/SignalRMarket.service';
import { HttpClient } from '@angular/common/http';
import { StockModel } from '../StockModel';

@Component({
  selector: 'app-Market-Screen',
  templateUrl: './Market-Screen.component.html',
  styleUrls: ['./Market-Screen.component.css']
})
export class MarketScreenComponent implements OnInit, AfterViewInit {

  constructor(public marketsignalRService: MarketSignalRService, private http: HttpClient) { }
  page = 1;
  pageSize = 7;
  collection = 0;
  isDataLoaded = false;

  ngOnInit() {
    this.marketsignalRService.startConnection();
    this.marketsignalRService.addTransferStockDataListener();
    this.startHttpRequest();
    this.isDataLoaded = false;
  }

  ngAfterViewInit(): void {
    this.collection = this.marketsignalRService.data.length;
    this.isDataLoaded = true;
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:44342/api/Market')
      .subscribe(res => { });
  }
  get Stocks(): StockModel[] {
    return this.marketsignalRService.data
      .map((stock, i) => ({ id: i + 1, ...stock }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

}
