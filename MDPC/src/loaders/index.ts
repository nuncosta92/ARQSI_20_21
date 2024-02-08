import config from '../../config';
import dependencyInjectorLoader from './dependencyInjector';
import mongooseLoader from './mongoose';
import expressLoader from './express';

export default async ({ expressApp }) => {

    const mongoConnection = await mongooseLoader();
    console.log('✌️ DB loaded and connected!');

    const postSchema = {
        name: 'postSchema',
        schema: '../persistence/schemas/PostSchema'
    }

    const commentSchema = {
        name: 'commentSchema',
        schema: '../persistence/schemas/CommentSchema'
    }

    //CONTROLLERS
    const postController = {
        name: config.controller.post.name,
        path: config.controller.post.path
    }
    const commentController = {
        name: config.controller.comment.name,
        path: config.controller.comment.path
    }


    //SERVICES
    const postService = {
        name: config.services.post.name,
        path: config.services.post.path
    }
    const commentService = {
        name: config.services.comment.name,
        path: config.services.comment.path
    }

    //REPOSITORY
    const postRepo = {
        name: config.repos.post.name,
        path: config.repos.post.path
    }
    const commentRepo = {
        name: config.repos.comment.name,
        path: config.repos.comment.path
    }

    await dependencyInjectorLoader({
        mongoConnection,
        schemas: [
            postSchema, 
            commentSchema
        ],
        controllers: [
            postController, 
            commentController
        ],
        services: [
            postService, 
            commentService
        ],
        repos: [
            postRepo, 
            commentRepo
        ]
    });
    console.log('✌️ Schemas, Controllers, Repositories, Services loaded');

    await expressLoader({ app: expressApp });
    console.log('✌️ Express loaded');
}