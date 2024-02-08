import { Document, Model } from 'mongoose'
import { ICommentPersistence } from "../dataschema/ICommentPersistence";
import { Comment } from "../domain/Comment";
import { CommentMapper } from "../mappers/CommentMapper";
import { ICommentRepo } from "./IRepo/ICommentRepo";
import { Request, Response } from "express";
import { Inject, Service } from 'typedi';

@Service('CommentRepo')
export default class PostRepo implements  ICommentRepo{

    constructor(
        @Inject('commentSchema') private commentSchema: Model<ICommentPersistence & Document>,
    ) { }

    async findByPostId(req: Request): Promise<Comment[]> {
        try {
            
            let commentObj: Comment[] = [];

            let commentPersistenceObjs = await this.commentSchema.find( {postID : req.query.postid as any});
               
            for (let i = 0; i < commentPersistenceObjs.length; i++) {
                
                commentObj[i] = CommentMapper.toDomain(commentPersistenceObjs[i]);
            }

            return commentObj;
        } catch (err) {
            throw(err);
        }
    }

    async save(comment: Comment): Promise<Comment> {
        try {
            
                const rawComment: any = CommentMapper.toPersistence(comment);

                const createdComment = await this.commentSchema.create(rawComment);
                return CommentMapper.toDomain(createdComment);
            } catch (e) {
            throw (e);
        }
    }

}