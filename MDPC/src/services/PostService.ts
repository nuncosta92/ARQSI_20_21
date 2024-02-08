import { Post } from "../domain/Post";
import { IPostDTO } from "../DTO/IPostDTO";
import { IPostRepo } from "../repos/IRepo/IPostRepo";
import { IPostService } from "./IServices/IPostService";
import { Result } from '../core/logic/Result';
import { PostMapper } from "../mappers/PostMapper";
import { Request, Response } from "express";
import config from '../../config'
import { Service, Inject } from 'typedi';

@Service('PostService')
export default class PostService implements IPostService {

    constructor(
        @Inject(config.repos.post.name) private postRepo: IPostRepo
    ) { }

    async createPost(postDTO: IPostDTO) {
        try {
            const postOrError = await Post.create(postDTO);
            
            if (postOrError.isFailure) {
                return Result.fail<IPostDTO>(postOrError.errorValue());
            }

            const postResult = postOrError.getValue();
            const saved = await this.postRepo.save(postResult);
            if( saved == null) {
                throw new Error("Something went wrong saving post");
            }
            const postDTOResult = PostMapper.toDTO(saved) as IPostDTO;
            return Result.ok<IPostDTO>(postDTOResult);
        } catch (e) {
            throw (e);
        }
    }

    public async findPostByUserId(req: Request) {
        try {
            const postsObj = await this.postRepo.findByUserId(req);
            
            let postDTOs: IPostDTO[] = [];

            for (let i = 0; i < postsObj.length; i++) {
                postDTOs[i] = PostMapper.toDTO(postsObj[i]);
                }
            
            return postDTOs;

        } catch (err) {
            console.log(err.stack);
            throw (err);
        }
    }
}