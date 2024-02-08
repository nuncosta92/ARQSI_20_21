/*import { Container } from 'typedi';
import config from '../../../../config';
import { ICrewMemberTypeService } from '../../../services/IServices/ICrewMemberTypeService';
import * as sinon from 'sinon';
import CrewMemberTypeController from '../../../controllers/CrewMemberTypeController';
import { Response, Request, NextFunction } from 'express';
import { ICrewMemberTypeDTO } from '../../../DTO/ICrewMemberTypeDTO';
import { Result } from '../../../core/logic/Result';



describe('Crew Member Type Controller', function () {

    it('createCrewMemberType: returns id + description', async function () {

        let body = { "description": 'O condutor e que conduz!' };
        let req: Partial<Request> = {};
        req.body = body;

        let res: Partial<Response> = {
            json: sinon.spy()
        };

        let next: Partial<NextFunction> = () => { };

        let crewMemberTypeServiceClass = require(config.services.crewMemberType.path).default;
        let crewMemberTypeServiceInstance = Container.get(crewMemberTypeServiceClass);
        Container.set(config.services.crewMemberType.name, crewMemberTypeServiceInstance)

        let crewMemberTypeService = Container.get(config.services.crewMemberType.name);

        sinon.stub(crewMemberTypeService, "createCrewMemberType").returns(Result.ok<ICrewMemberTypeDTO>({ "description": req.body.description }))

        const controller = new CrewMemberTypeController(crewMemberTypeService as ICrewMemberTypeService);

        await controller.createCrewMemberType(<Request>req, <Response>res, <NextFunction>next);

        sinon.assert.calledOnce(res.json)
        sinon.assert.calledWith(res.json, sinon.match({ "description": req.body.description }));
    })
})*/