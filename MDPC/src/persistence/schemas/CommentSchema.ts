
import mongoose from 'mongoose';
import { ICommentPersistence } from '../../dataschema/ICommentPersistence';


   
const postSchema = new mongoose.Schema({
    postID:{
        type : String,
        required : true
    }, 
    text:{
        type : String,
        required : true
    },
    likes:{
        type : Number,
        required : false
    },

    dislikes : {
        type : Number, 
        required: true
    }, 

    playerId : {
        type : Number, 
        required : true
    }
});
export default mongoose.model<ICommentPersistence & mongoose.Document>('ICommentPersistence', postSchema);
