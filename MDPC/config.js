import dotenv from 'dotenv';

const envFound = dotenv.config();
if (!envFound) {
    // This error should crash whole process

    throw new Error("⚠️  Couldn't find .env file  ⚠️");
}

export default {
    /**
     * Your favorite port
     */
    port: parseInt(process.env.PORT || 5000),

    /**
     * That long string from mlab
     */
    databaseURL: process.env.DB_CONNECTION,

    /**
 * Used by winston logger
 */
    logs: {
        level: process.env.LOG_LEVEL || 'silly',
    },

    /**
     * API configs
     */
    api: {
        prefix: '/api',
    },

    //REPOSITORIES

    repos: {
        post: {
            name: "PostRepo",
            path: "../repos/PostRepo"
        }, 
        comment: {
            name: "CommentRepo",
            path: "../repos/CommentRepo"
        }
    },

    //SERVICES

    services: {
        post: {
            name: "PostService",
            path: "../services/PostService"
        }, 
        comment: {
            name: "CommentService",
            path: "../services/CommentService"
        }
    },


    //CONTROLLERS

    controller: {
        post: {
            name: "PostController",
            path: "../controllers/PostController"
        }, 
        comment: {
            name: "CommentController",
            path: "../controllers/CommentController"
        }
    }
};