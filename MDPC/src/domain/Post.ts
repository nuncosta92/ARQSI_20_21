import { AggregateRoot } from "../core/AggregateRoot";
import { Result } from "../core/logic/Result";
import { IPostDTO } from "../DTO/IPostDTO";

export interface PostProps {
    userId: Number, 
    text : String,
    likes : Number, 
    dislikes: Number, 
    tag: String
    id : {
        type : String,
        required : false
    }
}

export class Post extends AggregateRoot<PostProps>{
    

    constructor(props : PostProps)
    {
        super(props);
    }

    public static create(postDTO: IPostDTO) {
       
        const userId = postDTO.userId;
        const text = postDTO.text;
        const likes = postDTO.likes;
        const dislikes = postDTO.dislikes;
        const tag = postDTO.tag;
        const id = postDTO.id;

        const postObj = new Post({ userId : userId, text : text, likes : likes, dislikes : dislikes, tag : tag, id : id});
        return Result.ok<Post>(postObj);;
    }
}