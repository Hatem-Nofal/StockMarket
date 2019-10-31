import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { StockModel } from '../StockModel';

@Injectable({
  providedIn: 'root'
})
export class MarketSignalRService {
  public data: StockModel[];
  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44342/Market')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addTransferStockDataListener = () => {
    this.hubConnection.on('transferstockdata', (data) => {
      this.data = data.result;
    });
  }

}
