export class SchoolDto {
  id: number;
  name: string;
  type: SchoolType;
  settlement: string;
}

export enum SchoolType {
  State = 1,
  Municipal = 2,
  Private = 3,
}

export const SchoolTypeEnumLocalization = {
  [SchoolType.State]: "Държавно",
  [SchoolType.Municipal]: "Общинско",
  [SchoolType.Private]: "Частно",
};
