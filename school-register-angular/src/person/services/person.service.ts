import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PersonDto } from "../dtos/person-dto";
import { PersonFilterDto } from "../dtos/person-filter-dto";

@Injectable({
  providedIn: "root",
})
export class PersonService {
  private baseUrl = "http://localhost:22333";

  constructor(private http: HttpClient) {}

  getAll(): Observable<PersonDto[]> {
    return this.http.get<PersonDto[]>(`${this.baseUrl}/api/People`);
  }

  getFiltered(personDto: PersonFilterDto): Observable<PersonDto[]> {
    return this.http.get<PersonDto[]>(
      `${this.baseUrl}/api/People/Filter?${this.composeQueryString(personDto)}`
    );
  }

  composeQueryString(personDto: PersonFilterDto): string {
    return Object.entries(personDto)
      .filter(([_, value]) => value !== null) // [ [ 'pageNum', 3 ], [ 'perPageNum', 10 ], [ 'category', 'food' ] ]
      .map(([key, value]) => `${key}=${value}`) // [ 'pageNum=3', 'perPageNum=10', 'category=food' ]
      .join("&"); // 'pageNum=3&perPageNum=10&category=food'
  }
}
