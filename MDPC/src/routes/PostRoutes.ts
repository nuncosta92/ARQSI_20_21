
import { Container } from 'typedi'
import { Router } from 'express';
import { celebrate, Joi } from 'celebrate';
import cors from 'cors';
import PostController from '../controllers/PostController';

const router = Router();

export default (app: Router) => {

    app.use('/post', router);

    app.use(cors());

    const controller = Container.get(PostController);

    router.post('/create', celebrate({
        body: Joi.object({
            userId: Joi.number().required(),
            text: Joi.string().required(),
            likes: Joi.number().required(),
            dislikes: Joi.number().required(),
            tag: Joi.string().required()
        })
    }),
        async (req, res, next) => await controller.createPost(req, res, next));

    router.get('/findPosts', cors(), async (req, res, next) => {
        controller.findPostByUserId(req, res, next);
    })
}