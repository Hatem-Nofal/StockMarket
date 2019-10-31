import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { BsDropdownModule } from 'ngx-bootstrap';
import { routing } from './routes';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { MarketScreenComponent } from './Market-Screen/Market-Screen.component';
import { OrederScreenComponent } from './Oreder-Screen/Oreder-Screen.component';
import { MarketSignalRService } from './Services/SignalRMarket.service';
@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      MarketScreenComponent,
      OrederScreenComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      routing,
      NgbModule
   ],
   providers: [
      MarketSignalRService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
