export interface IColumn {
    columnDef: string;
    header: string;
    cell?: (element: any) => string;
}
