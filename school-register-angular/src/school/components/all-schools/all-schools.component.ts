import { Component, OnInit } from "@angular/core";
import {
  SchoolDto,
  SchoolType,
  SchoolTypeEnumLocalization,
} from "../../dtos/school-dto";
import { SchoolService } from "../../services/school.service";
import { catchError, throwError } from "rxjs";
import { SchoolFilterDto } from "../../dtos/school-filter-dto";

@Component({
  selector: "app-all-schools",
  templateUrl: "./all-schools.component.html",
  styleUrl: "./all-schools.component.css",
})
export class AllSchoolsComponent implements OnInit {
  schools: SchoolDto[];
  schoolDto: SchoolFilterDto = new SchoolFilterDto();

  type: SchoolType;
  schoolTypeEnumLocalization = SchoolTypeEnumLocalization;

  constructor(public schoolService: SchoolService) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.schoolService
      .getAll()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.schools = res;
      });
  }

  getFiltered(schoolDto: SchoolFilterDto) {
    this.schoolService
      .getFiltered(schoolDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.schools = res;
      });
  }
}
