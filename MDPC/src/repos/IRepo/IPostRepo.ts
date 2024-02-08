import { Post } from "../../domain/Post";
import { Request, Response } from "express";

export interface IPostRepo {
    findByUserId(req: Request):  Promise<Post[]>;
    save(post: Post): Promise<Post>;
}