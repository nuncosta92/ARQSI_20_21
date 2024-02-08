import { Comment } from "../domain/Comment";
import { ICommentDTO } from "../DTO/ICommentDTO";
import { ICommentRepo } from "../repos/IRepo/ICommentRepo";
import { ICommentService } from "./IServices/ICommentService";
import { Result } from '../core/logic/Result';
import { CommentMapper } from "../mappers/CommentMapper";
import { Request, Response } from "express";
import config from '../../config'
import { Service, Inject } from 'typedi';
import { ParamsDictionary } from "express-serve-static-core";
import { ParsedQs } from "qs";

@Service('CommentService')
export default class CommentService implements ICommentService {

    constructor(
        @Inject(config.repos.comment.name) private commentRepo: ICommentRepo
    ) { }

    async createComment(commentDTO: ICommentDTO) {
        try {
            const commentOrError = await Comment.create(commentDTO);
            
            if (commentOrError.isFailure) {
                return Result.fail<ICommentDTO>(commentOrError.errorValue());
            }

            const commentResult = commentOrError.getValue();
            const saved = await this.commentRepo.save(commentResult);
            if( saved == null) {
                throw new Error("Something went wrong saving comment");
            }
            const commentDTOResult = CommentMapper.toDTO(saved) as ICommentDTO;
            return Result.ok<ICommentDTO>(commentDTOResult);
        } catch (e) {
            throw (e);
        }
    }

    public async findCommentByPostId(req: Request) {
        try {
            const commentsObj = await this.commentRepo.findByPostId(req);
            
            let commentDTOs: ICommentDTO[] = [];

            for (let i = 0; i < commentsObj.length; i++) {
                commentDTOs[i] = CommentMapper.toDTO(commentsObj[i]);
                }
            
            return commentDTOs;

        } catch (err) {
            console.log(err.stack);
            throw (err);
        }
    }
}