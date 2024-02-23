import { Component, OnInit } from "@angular/core";
import { UserDto } from "../../dtos/user-dto";
import { catchError, throwError } from "rxjs";
import { UserService } from "../../services/user.service";
import { UserFilterDto } from "../../dtos/user-filter-dto";

@Component({
  selector: "app-all-users",
  templateUrl: "./all-users.component.html",
  styleUrl: "./all-users.component.css",
})
export class AllUsersComponent implements OnInit {
  users: UserDto[];
  userDto: UserFilterDto = new UserFilterDto();

  constructor(public userService: UserService) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.userService
      .getAll()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.users = res;
      });
  }

  getFiltered(userDto: UserFilterDto) {
    this.userService
      .getFiltered(userDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.users = res;
      });
  }
}
