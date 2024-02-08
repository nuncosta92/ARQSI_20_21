import {Request, Response, NextFunction} from 'express';
import { Inject } from 'typedi';
import  config  from '../../config';
import { ICommentDTO } from '../DTO/ICommentDTO';
import { ICommentService } from '../services/IServices/ICommentService';
import { ICommentController } from './IControllers/ICommentController';

export default class CommentController implements ICommentController{
    constructor (
        @Inject(config.services.comment.name) private PostServiceInstance: ICommentService
    ) {}

    public async createComment(req: Request, res: Response, next: NextFunction) {

        try {
            const commentDTO = await this.PostServiceInstance.createComment(req.body as ICommentDTO);
    
            return res.status(201).json(commentDTO.getValue());

        } catch (error) {
            return res.status(401).json({'Error': error.message });
        };
    }

    public async findCommentByPostId(req: Request, res: Response, next: NextFunction) {
        try {
            const commentDTO = await this.PostServiceInstance.findCommentByPostId(req);
            return res.status(200).json(commentDTO);
        } catch (err) {
            return res.status(401).json({'Error': err.message });
        }
    }
}