import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MarketScreenComponent } from './Market-Screen/Market-Screen.component';
import { OrederScreenComponent } from './Oreder-Screen/Oreder-Screen.component';


export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'market', component: MarketScreenComponent },
    { path: 'orders', component: OrederScreenComponent },
    { path: '**', redirectTo: '', pathMatch: 'full' }

];
export const routing = RouterModule.forRoot(appRoutes);
