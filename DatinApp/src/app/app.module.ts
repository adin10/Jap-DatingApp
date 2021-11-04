import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http'
import{FormsModule} from '@angular/forms'; 
import{ReactiveFormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './user/user.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MembersComponent } from './members/members.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import{ToastrModule} from 'ngx-toastr';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberCardComponent } from './member-card/member-card.component';
import{TabsModule} from 'ngx-bootstrap/tabs';
import{NgxGalleryModule} from '@kolkov/ngx-gallery';
import { MemberEditComponent } from './member-edit/member-edit.component'
@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    NavMenuComponent,
    MembersComponent,
    ListsComponent,
    MessagesComponent,
    MemberDetailComponent,
    MemberCardComponent,
    MemberEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TabsModule,
    NgxGalleryModule,
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
