import { NextFunction, Request, Response } from "express";

export interface ICommentController {
    createComment(req: Request, res: Response, next: NextFunction): Promise<Response<any>>;
    findCommentByPostId(req: Request, res: Response, next: NextFunction): Promise<Response<any>>;
}