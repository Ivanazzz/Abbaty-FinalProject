export class PersonDto {
  id: number;
  firstName: string;
  middleName: string;
  lastName: string;
  uic: string;
  birthDate: string;
  gender: Gender;
  birthPlace: string;
}

export enum Gender {
  Male = 1,
  Female = 2,
}

export const GenderEnumLocalization = {
  [Gender.Male]: "Мъж",
  [Gender.Female]: "Жена",
};
