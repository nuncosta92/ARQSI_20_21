
import mongoose from 'mongoose';
import { IPostPersistence } from '../../dataschema/IPostPersistence';


   
const postSchema = new mongoose.Schema({
    id : {
        type : String,
        required : false
    },
    userId:{
        type : Number,
        required : true
    }, 
    text:{
        type : String,
        required : true
    },
    likes:{
        type : Number,
        required : true
    },

    dislikes : {
        type : Number, 
        required: true
    },

    tag : {
        type : String, 
        required : true
    } 
});
export default mongoose.model<IPostPersistence & mongoose.Document>('IPostPersistence', postSchema);
