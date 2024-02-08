import { ICommentDTO } from "../../DTO/ICommentDTO";
import { Result } from '../../core/logic/Result';
import { Request } from "express";

export interface ICommentService {
    createComment(postDTO: ICommentDTO) : Promise<Result<ICommentDTO>>
    findCommentByPostId(req: Request): Promise<ICommentDTO[]>
}