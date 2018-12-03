
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

import { UserModel } from '../Models/Users.model';
import { ApiService } from '@core/services/ApiService';
import { UsersService } from '@core/services/Users.service';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'Users',
  templateUrl: './Users.component.html',
  styleUrls: ['./Users.component.scss']
})
export class UsersComponent implements OnInit {

  public active: boolean;
  rows: UserModel[];

  public tab: any;

  filterOpened = false;

  @ViewChild('UsersTable') table: any;

  constructor(public service: ApiService,
    // tslint:disable-next-line:no-shadowed-variable
    private UsersService: UsersService) { }

  ngOnInit() {

    this.getdata();

  }
  getdata() {
    this.UsersService.getUsersList().subscribe(data => {
      this.rows = data;
    });

  }
  OnFilterUser(data) {
    this.rows = data.result;
  }

  toggleAdvancedFilter() {
    this.filterOpened = !this.filterOpened;
  }

}
