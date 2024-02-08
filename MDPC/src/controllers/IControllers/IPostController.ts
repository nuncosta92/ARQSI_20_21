import { NextFunction, Request, Response } from "express";

export interface IPostController {
    createPost(req: Request, res: Response, next: NextFunction): Promise<Response<any>>;
    findPostByUserId(req: Request, res: Response, next: NextFunction): Promise<Response<any>>;
}