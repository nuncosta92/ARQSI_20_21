
import { Container } from 'typedi'
import { Router } from 'express';
import { celebrate, Joi } from 'celebrate';
import cors from 'cors';
import CommentController from '../controllers/CommentController';

const router = Router();

export default (app: Router) => {

    app.use('/comment', router);

    app.use(cors());

    const controller = Container.get(CommentController);

    router.post('/create', celebrate({
        body: Joi.object({
            postID: Joi.string().required(),
            text: Joi.string().required(),
            likes: Joi.number().required(),
            dislikes: Joi.number().required(),
            playerId: Joi.number().required()
        })
    }),
        async (req, res, next) => await controller.createComment(req, res, next));

    router.get('/findComments', cors(), async (req, res, next) => {
        controller.findCommentByPostId(req, res, next);
    })
}