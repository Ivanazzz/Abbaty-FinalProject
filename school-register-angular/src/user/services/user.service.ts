import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserRegistrationDto } from "../dtos/user-registration-dto";
import { UserLoginDto } from "../dtos/user-login-dto";
import { UserDto } from "../dtos/user-dto";
import { Router } from "@angular/router";
import { UserFilterDto } from "../dtos/user-filter-dto";

@Injectable({
  providedIn: "root",
})
export class UserService {
  private baseUrl = "http://localhost:22333";
  public currentUser: UserDto = new UserDto();

  constructor(private http: HttpClient, private router: Router) {}

  initializeUser(): Promise<{}> {
    return new Promise((resolve) => {
      return this.http
        .get<UserDto>("http://localhost:22333/api/Users/CurrentUser")
        .subscribe((userData) => {
          this.currentUser = userData;
          resolve(true);
        });
    });
  }

  register(userDto: UserRegistrationDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/api/Users/SignUp`, userDto);
  }

  login(userDto: UserLoginDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/api/Users/Login`, userDto);
  }

  logout(): Observable<void> {
    this.currentUser = null;
    localStorage.clear();
    this.router.navigate(["/"]);
    return;
  }

  getAll(): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(`${this.baseUrl}/api/Users`);
  }

  getFiltered(userDto: UserFilterDto): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(
      `${this.baseUrl}/api/Users/Filter?${this.composeQueryString(userDto)}`
    );
  }

  composeQueryString(userDto: UserFilterDto): string {
    return Object.entries(userDto)
      .filter(([_, value]) => value !== null) // [ [ 'pageNum', 3 ], [ 'perPageNum', 10 ], [ 'category', 'food' ] ]
      .map(([key, value]) => `${key}=${value}`) // [ 'pageNum=3', 'perPageNum=10', 'category=food' ]
      .join("&"); // 'pageNum=3&perPageNum=10&category=food'
  }
}
