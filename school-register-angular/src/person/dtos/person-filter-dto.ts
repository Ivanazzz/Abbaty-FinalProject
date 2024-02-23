import { Gender } from "./person-dto";

export class PersonFilterDto {
  firstName: string;
  middleName: string;
  lastName: string;
  uic: string;
  birthDate: string;
  gender: Gender;
  birthPlace: string;
}
