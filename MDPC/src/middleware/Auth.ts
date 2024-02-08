import { NextFunction, Request, Response } from 'express';
import jwt from 'jsonwebtoken';

export default class Auth {

    public static async authorizationUser(req: Request, res: Response, next: NextFunction) {
        try {
            const token = req.header("x-auth-token");

            if (!token) {
                return res.status(401).json({ msg: "No authentication token, authorization denied!" });
            }
            const verifiedToken = jwt.verify(token, process.env.TOKEN_SECRET);

            if (!verifiedToken) {
                return res.status(401).json({ msg: "Token verification failed, authorization denied!" });
            }

            console.log(verifiedToken);

            next();

        } catch (err) {
            res.status(500).json({ error: err.message });
        }
    }
}