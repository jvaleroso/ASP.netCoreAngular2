import { NgModule } from '@angular/core';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TreatmentComponent } from './components/treatment/treatment.component';
import { TreatmentService } from './services/treatment/treatment.service';
import { StatutoryComponent } from './components/statutory/statutory.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        TreatmentComponent,
        StatutoryComponent,
        HomeComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        AppRoutingModule
    ],
    providers: [ TreatmentService ]
})
export class AppModule {
}
