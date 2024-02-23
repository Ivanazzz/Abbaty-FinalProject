import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { SchoolDto } from "../dtos/school-dto";
import { SchoolFilterDto } from "../dtos/school-filter-dto";

@Injectable({
  providedIn: "root",
})
export class SchoolService {
  private baseUrl = "http://localhost:22333";

  constructor(private http: HttpClient) {}

  getAll(): Observable<SchoolDto[]> {
    return this.http.get<SchoolDto[]>(`${this.baseUrl}/api/Schools`);
  }

  getFiltered(schoolDto: SchoolFilterDto): Observable<SchoolDto[]> {
    return this.http.get<SchoolDto[]>(
      `${this.baseUrl}/api/Schools/Filter?${this.composeQueryString(schoolDto)}`
    );
  }

  composeQueryString(schoolDto: SchoolFilterDto): string {
    return Object.entries(schoolDto)
      .filter(([_, value]) => value !== null) // [ [ 'pageNum', 3 ], [ 'perPageNum', 10 ], [ 'category', 'food' ] ]
      .map(([key, value]) => `${key}=${value}`) // [ 'pageNum=3', 'perPageNum=10', 'category=food' ]
      .join("&"); // 'pageNum=3&perPageNum=10&category=food'
  }
}
