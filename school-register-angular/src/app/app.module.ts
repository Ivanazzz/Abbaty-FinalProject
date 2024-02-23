import { APP_INITIALIZER, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { CommonModule } from "@angular/common";
import { ToastrModule } from "ngx-toastr";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NavComponent } from "./root/nav/nav.component";
import { LoginComponent } from "../user/components/login/login.component";
import { RegistrationComponent } from "../user/components/registration/registration.component";
import { AuthInterceptor } from "./interceptors/auth.interceptor";
import { UserService } from "../user/services/user.service";
import { BlankPageComponent } from "./root/blank-page/blank-page.component";
import { AllUsersComponent } from "../user/components/all-users/all-users.component";
import { FormsModule } from "@angular/forms";
import { AllSchoolsComponent } from "../school/components/all-schools/all-schools.component";
import { ErrorInterceptor } from "./interceptors/error.interceptor";
import { AllPeopleComponent } from "../person/components/all-people/all-people.component";

export function appInitializer(userService: UserService) {
  return () => userService.initializeUser();
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    RegistrationComponent,
    BlankPageComponent,
    AllUsersComponent,
    AllSchoolsComponent,
    AllPeopleComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    FormsModule,
    CommonModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    UserService,
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializer,
      multi: true,
      deps: [UserService],
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
