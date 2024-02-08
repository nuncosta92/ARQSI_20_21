export interface IPostPersistence {
    id : {
        type : String,
        required : false
    },
    userId: Number, 
    text : String,
    likes : Number, 
    dislikes: Number, 
    tag: String
};