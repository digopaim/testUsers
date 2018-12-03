import { Subscriber } from 'rxjs';

import { Component, OnInit, Input, ViewChild, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { UserModel } from 'src/content/Models/Users.model';
import { UsersService } from '@core/services/Users.service';
import { EditUserComponent } from '../actions/edit-user/edit-user-action.component';
import { BsModalService } from 'ngx-bootstrap';




@Component({
  // tslint:disable-next-line:component-selector
  selector: 'users-available',
  templateUrl: './users-available.component.html',
  styleUrls: ['./users-available.component.scss']
})
export class UsersAvailableComponent implements OnInit {
  UserModel: UserModel;

  // tslint:disable-next-line:no-shadowed-variable
  constructor(private modalService: BsModalService,
     private location: Location, private router: Router, private UserService: UsersService) { }
  @ViewChild('UsersTable') UsersTable: any;
  @Input()
  atHome: boolean;
  show: boolean = false;
  @ViewChild('EditUserModalComponent') EditUserModal: EditUserComponent;

  // @Input()
  // dataSet: any;
  public tab: number;
  @Input()
  set grid(list: any) {
    if (list) {
      this.dataSet = list;
      this.fullDataSet = list;
    }
  }


  @Input()
  total: number;

  @Output()
  UpdateGrid = new EventEmitter();

  public fullDataSet: any;
  public dataSet: any;

  public columns = [
    { prop: 'name', sortable: false },
    { prop: 'documentNumber', sortable: false },
    { prop: 'age', sortable: false },
  ];

  ny;

  ngOnInit() {
  }

  onDetailToggle(e: Event) {
    return;
  }

  toggleExpandRow(row) {
    this.UsersTable.rowDetail.toggleExpandRow(row);
  }
  Reload() {
    location.reload();
  }
  EditUser(id, name, documentNumber, age) {
    this.show = true;
    this.EditUserModal.id = id;
    this.EditUserModal.age = age;
    this.EditUserModal.documentNumber = documentNumber;
    this.EditUserModal.name = name;
  }
  confirmEditUser(user) {
    this.UserService.EditUser(user).subscribe(data => {
      this.Reload();
    });
  }
  DeleteUser(id) {
    this.UserService.DeleteUser(id).subscribe(data => {
      this.Reload();
    });
  }
  updateFilter(event) {

    const textFilter    = event.target.value.toLowerCase();
    let dataSetFilter = new Array<UserModel>();
    this.dataSet        = this.fullDataSet;

    if (textFilter === '') {
      return;
    } else if (!textFilter) {
      return;
    }

    dataSetFilter = this.dataSet.filter(x =>

      (x.age || '').toLowerCase().indexOf(textFilter) >= 0 ||
      (x.name || '').toLowerCase().indexOf(textFilter) >= 0 ||
      (x.documentNumber || '').toLowerCase().indexOf(textFilter) >= 0);

       this.dataSet = dataSetFilter;
    }
}
