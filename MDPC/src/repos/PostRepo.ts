import { Document, Model } from 'mongoose'
import { IPostPersistence } from "../dataschema/IPostPersistence";
import { Post } from "../domain/Post";
import { PostMapper } from "../mappers/PostMapper";
import { IPostRepo } from "./IRepo/IPostRepo";
import { Request, Response } from "express";
import { Inject, Service } from 'typedi';

@Service('PostRepo')
export default class PostRepo implements IPostRepo {

    constructor(
        @Inject('postSchema') private postSchema: Model<IPostPersistence & Document>,
    ) { }

    async findByUserId(req: Request): Promise<Post[]> {
        try {
            
            let postObj: Post[] = [];

            let postPersistenceObjs = await this.postSchema.find( {userId : req.query.userid as any});
               
            for (let i = 0; i < postPersistenceObjs.length; i++) {
                
                postObj[i] = PostMapper.toDomain(postPersistenceObjs[i]);
            }

            return postObj;
        } catch (err) {
            throw(err);
        }
    }

    async save(post: Post): Promise<Post> {
        try {
            
                const rawPost: any = PostMapper.toPersistence(post);

                const createdPost = await this.postSchema.create(rawPost);
                return PostMapper.toDomain(createdPost);
            } catch (e) {
            throw (e);
        }
    }

}