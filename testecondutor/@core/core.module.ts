import { ApiService } from './services/ApiService';
import { UsersService } from './services/Users.service';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BsModalService } from 'ngx-bootstrap';

@NgModule({
    imports: [
        HttpClientModule
    ],
    exports: [
    ],
    providers: [
    ApiService,
    UsersService,
    BsModalService
    ],
    declarations: []
  })
  export class CoreModule { }
