/*import * as sinon from 'sinon';
import { Response, Request, NextFunction } from 'express';
import config from "../../../../config";
import Container from 'typedi';
import { Result } from '../../../core/logic/Result';
import { ICrewMemberTypePersistance } from '../../../dataschema/ICrewMemberTypePersistence';
import { ICrewMemberTypeDTO } from '../../../DTO/ICrewMemberTypeDTO'
import CrewMemberTypeService from '../../../services/CrewMemberTypeService';
import { ICrewMemberTypeRepository } from '../../../repos/IRepo/ICrewMemberTypeRepository';

it('createCrewMemberType: returns the description', async function () {

    let body = { "description": 'O condutor de carros!' };
    let req: Partial<Request> = {}
    req.body = body;

    let res: Partial<Response> = {
        json: sinon.spy()
    };
    let next: Partial<NextFunction> = () => { };

    let crewMemberTypeRepo = require(config.repos.crewMemberType.path).default;
    let crewMemberTypeRepoInstance = Container.get(crewMemberTypeRepo);
    Container.set(config.repos.crewMemberType.name, crewMemberTypeRepoInstance);

    crewMemberTypeRepoInstance = Container.get(config.repos.crewMemberType.name);
    sinon.stub(crewMemberTypeRepoInstance, 'createCrewMemberType').returns(Result.ok<ICrewMemberTypePersistance>({ "domainId": "123", "description": req.body.description }));

    const repo = new CrewMemberTypeService(crewMemberTypeRepoInstance as ICrewMemberTypeRepository);

    //await repo.createCrewMemberType(loladas as ICrewMemberTypeDTO);

    sinon.assert.calledOnce(res.json);
    sinon.assert.calledWith(res.json, sinon.match({ "id": "123", "name": "O condutor de carros!" }));
})*/