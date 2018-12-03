import { Subscriber } from 'rxjs';

import { Component, OnInit, Input, ViewChild, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/content/Models/Users.model';
import { UsersService } from '@core/services/Users.service';



@Component({
  // tslint:disable-next-line:component-selector
  selector: 'add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss'],
  providers: [UserModel]

})
export class AddUserComponent implements OnInit {

  // tslint:disable-next-line:no-shadowed-variable
  constructor(private router: Router, public user: UserModel, private UserService: UsersService) { }
  @ViewChild('UsersTable') UsersTable: any;
  @Input()
  atHome: boolean;

    ngOnInit() {
    }
  Add() {
      this.UserService.AddUser(this.user).subscribe(data => {
      this.router.navigate(['./user']);
    });
  }

  limpar() {
    this.user = new UserModel();
  }
}
