import { IPostDTO } from "../../DTO/IPostDTO";
import { Result } from '../../core/logic/Result';
import { Request } from "express";

export interface IPostService {
    createPost(postDTO: IPostDTO) : Promise<Result<IPostDTO>>
    findPostByUserId(req: Request): Promise<IPostDTO[]>
}