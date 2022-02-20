import { IPagedRequestDto } from "./IPagedRequestDto";

export class GetProductsInput implements IPagedRequestDto {
    skipCount: number;
    maxResult: number;
    categoryId: string | null;
    search: string;
}
