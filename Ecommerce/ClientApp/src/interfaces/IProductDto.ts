import { ICategoryDto } from "./ICategoryDto";

export interface IProductDto {
    id: string;
    name: string;
    description: string;
    price: number;
    categoryId: string;
    category: ICategoryDto;
}
