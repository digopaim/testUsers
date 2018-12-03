import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from 'src/content/Users/Users.component';
import { CoreModule } from '@core/core.module';
import { UsersAvailableComponent } from 'src/content/Users/components/Users-Available/Users-Available.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import {TabsModule} from 'ngx-tabset';
import { AddUserComponent } from 'src/content/Users/components/add-user/add-user.component';
import { FormsModule } from '@angular/forms';
import { ModalModule, ButtonsModule } from 'ngx-bootstrap';
import { EditUserComponent } from 'src/content/Users/components/actions/edit-user/edit-user-action.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { CollapseModule } from 'ngx-bootstrap/collapse';
// import {BootstrapModule} from 'bootstrap';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent, UsersComponent, UsersAvailableComponent, AddUserComponent, EditUserComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    CoreModule,
    NgxDatatableModule,
    TabsModule.forRoot(),
    FormsModule,
    ModalModule.forRoot(),
    NgbModule,
    ButtonsModule.forRoot(),
    CollapseModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
