import { Comment } from "../../domain/Comment";
import { Request, Response } from "express";

export interface ICommentRepo {
    findByPostId(req: Request):  Promise<Comment[]>;
    save(post: Comment): Promise<Comment>;
}