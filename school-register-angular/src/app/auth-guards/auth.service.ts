import { Injectable } from "@angular/core";
import { UserDto } from "../../user/dtos/user-dto";
import { UserService } from "../../user/services/user.service";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private currentUser: UserDto | null = null;

  constructor(private userService: UserService) {
    this.currentUser = this.userService.currentUser;
  }

  isLogged(): boolean {
    return this.currentUser !== null;
  }
}
