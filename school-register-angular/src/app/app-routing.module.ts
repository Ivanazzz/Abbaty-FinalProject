import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "../user/components/login/login.component";
import { RegistrationComponent } from "../user/components/registration/registration.component";
import { BlankPageComponent } from "./root/blank-page/blank-page.component";
import { AllUsersComponent } from "../user/components/all-users/all-users.component";
import { AllSchoolsComponent } from "../school/components/all-schools/all-schools.component";
import { AuthGuard } from "./auth-guards/auth.guard";
import { AllPeopleComponent } from "../person/components/all-people/all-people.component";

const routes: Routes = [
  {
    path: "",
    component: LoginComponent,
  },
  {
    path: "registration",
    component: RegistrationComponent,
  },
  {
    path: "page",
    component: BlankPageComponent,
  },
  {
    path: "allUsers",
    component: AllUsersComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "allSchools",
    component: AllSchoolsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: "allPeople",
    component: AllPeopleComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
