import { Document, Model } from "mongoose";
import { Comment } from "../domain/Comment";
import { ICommentDTO } from "../DTO/ICommentDTO";

export class CommentMapper {
    //Convert domain object to DTO
    public static toDTO(comment: Comment): ICommentDTO {
        return {
            postID: comment.props.postID,
            text: comment.props.text,
            likes: comment.props.likes,
            dislikes: comment.props.dislikes, 
            playerId: comment.props.playerId
        } as ICommentDTO;
    }

    //Convert Comment in Domain object
    public static toDomain(post: any | Model<ICommentDTO & Document>) {
            return Comment.create({
            postID: post.postID,
            text: post.text,
            likes: post.likes,
            dislikes: post.dislikes,
            playerId : post.playerId
        }).getValue();
    }

    //Convert Comment in Persistence object
    public static toPersistence(post: Comment): any {
        return {
            postID: post.props.postID,
            text: post.props.text,
            likes: post.props.likes,
            dislikes: post.props.dislikes, 
            playerId: post.props.playerId
        };

    }
}