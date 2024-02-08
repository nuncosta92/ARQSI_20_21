import { Document, Model } from "mongoose";
import { Post } from "../domain/Post";
import { IPostDTO } from "../DTO/IPostDTO";

export class PostMapper {
    //Convert domain object to DTO
    public static toDTO(post: Post): IPostDTO {
        return {
            id : post.props.id,
            userId: post.props.userId,
            text: post.props.text,
            likes: post.props.likes,
            dislikes: post.props.dislikes,
            tag: post.props.tag
        } as IPostDTO;
    }

    //Convert Post in Domain object
    public static toDomain(post: any | Model<IPostDTO & Document>) {
        return Post.create({
            id : post._id,
            userId: post.userId,
            text: post.text,
            likes: post.likes,
            dislikes: post.dislikes,
            tag: post.tag
        }).getValue();
    }

    //Convert Post in Persistence object
    public static toPersistence(post: Post): any {
        return {
            id: post.props.id,
            userId: post.props.userId,
            text: post.props.text,
            likes: post.props.likes,
            dislikes: post.props.dislikes,
            tag: post.props.tag
        };

    }
}