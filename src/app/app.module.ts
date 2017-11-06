import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { PlayerComponent } from './player/player.component';
import { SearchFilter } from './player/SearchFilterPipe';
import { SortPipe } from './player/SortPipe';

@NgModule({
  declarations: [
    AppComponent,
    PlayerComponent,
    SearchFilter,
    SortPipe
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpModule,
    FormsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


