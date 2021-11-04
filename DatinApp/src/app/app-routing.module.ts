import { componentFactoryName } from '@angular/compiler';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { MembersComponent } from './members/members.component';
import { MessagesComponent } from './messages/messages.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { UsersComponent } from './user/user.component';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [
  {path:'user',component:UsersComponent},
  {path:'nav',component:NavMenuComponent},
  {path:'messages',component:MessagesComponent},
  {path:'member/:username/edit',component:MemberEditComponent,canDeactivate:[PreventUnsavedChangesGuard]},
  {path:'lists',component:ListsComponent},
  {path:'members',component:MembersComponent},
  {path:'member/:username',component:MemberDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
