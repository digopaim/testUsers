import { EventEmitter } from '@angular/core';
import { Component, OnInit, Input, Output, ViewChild } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { UserModel } from 'src/content/Models/Users.model';
import { UsersService } from '@core/services/Users.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'edit-user-action',
  templateUrl: './edit-user-action.component.html',
  styleUrls: ['./edit-user-action.component.scss'],
  providers: [UserModel]
})
export class EditUserComponent implements OnInit {

  disabledSave = true;
  disabledSaveMaxLengthSLA = true;
  public id: number;
  public age: number;
  public documentNumber: string;
  public name: string;
  @ViewChild('EditUserModalContent') modalContent: any;

  @Input()
  service: UserModel;


  // tslint:disable-next-line:no-output-on-prefix
  @Output()
  onCloseModal = new EventEmitter();

  private modalRef: BsModalRef;

  // tslint:disable-next-line:no-shadowed-variable
  constructor(private UserService: UsersService,
    private modalService: BsModalService) {

  }
  public User: any;

  ngOnInit() {

  }

  open(): void {
       this.modalRef = this.modalService.show(this.modalContent);
  }

  close(): void {
    this.modalRef.hide();
  }

  confirm(): void {
    this.User = new UserModel();
    this.User.id = this.id;
    this.User.age = this.age;
    this.User.name = this.name;
    this.User.documentNumber = this.documentNumber;
    this.onCloseModal.emit(this.User);
    this.modalRef.hide();
  }
}
