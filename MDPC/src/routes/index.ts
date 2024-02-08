import { Router } from 'express';
import CommentRoutes from './CommentRoutes';
import PostRoutes from './PostRoutes';

export default () => {
    const app = Router();

    PostRoutes(app);
    CommentRoutes(app);
    return app;
}
