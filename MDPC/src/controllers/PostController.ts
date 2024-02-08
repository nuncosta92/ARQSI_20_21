import {Request, Response, NextFunction} from 'express';
import { Inject } from 'typedi';
import  config  from '../../config';
import { IPostDTO } from '../DTO/IPostDTO';
import { IPostService } from '../services/IServices/IPostService';
import { IPostController } from './IControllers/IPostController';

export default class PostController implements IPostController{
    constructor (
        @Inject(config.services.post.name) private PostServiceInstance: IPostService
    ) {}

    public async createPost(req: Request, res: Response, next: NextFunction) {

        try {
            const postDTO = await this.PostServiceInstance.createPost(req.body as IPostDTO);
    
            return res.status(201).json(postDTO.getValue());

        } catch (error) {
            return res.status(401).json({'Error': error.message });
        };
    }

    public async findPostByUserId(req: Request, res: Response, next: NextFunction) {
        try {
            const postDTO = await this.PostServiceInstance.findPostByUserId(req);
            return res.status(200).json(postDTO);
        } catch (err) {
            return res.status(401).json({'Error': err.message });
        }
    }
}