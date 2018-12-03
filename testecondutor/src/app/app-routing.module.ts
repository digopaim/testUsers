import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from 'src/content/Users/Users.component';
import { UsersAvailableComponent } from 'src/content/Users/components/Users-Available/Users-Available.component';
import { AddUserComponent } from 'src/content/Users/components/add-user/add-user.component';
import { EditUserComponent } from 'src/content/Users/components/actions/edit-user/edit-user-action.component';

const routes: Routes = [{path: 'user', component :  UsersComponent,
children : [{path: 'useravailable', component : UsersAvailableComponent},
            {path: 'edituser', component: EditUserComponent}
            ],
          },
            {path: 'addUser', component: AddUserComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
