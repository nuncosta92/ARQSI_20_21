import { AggregateRoot } from "../core/AggregateRoot";
import { Result } from "../core/logic/Result";
import { ICommentDTO } from "../DTO/ICommentDTO";

export interface CommentProps {
    postID: String, 
    text : String,
    likes : Number, 
    dislikes: Number,
    playerId : Number
}

export class Comment extends AggregateRoot<CommentProps>{
    

    constructor(props : CommentProps)
    {
        super(props);
    }

    public static create(postDTO: ICommentDTO) {
       
        const postID = postDTO.postID;
        const text = postDTO.text;
        const likes = postDTO.likes;
        const dislikes = postDTO.dislikes;
        const playerId = postDTO.playerId;

        const commentObj = new Comment({ postID : postID, text : text, likes : likes, dislikes : dislikes, playerId : playerId});
        return Result.ok<Comment>(commentObj);;
    }
}