/*import * as sinon from 'sinon';

import { Request, Response, NextFunction } from "express";

import { Container } from "typedi";
import config from "../../../../config";

import { Result } from "../../../core/logic/Result";

import { IVehicleTypeService } from "../../../services/IServices/IVehicleTypeService";
import VehicleTypeController from "../../../controllers/VehicleTypeController";
import { IVehicleTypeDTO } from "../../../DTO/IVehicleTypeDTO";

describe('Vehicle Type Controller', function () {
    it('createVehicleType: returns json with domainId, description, fuelType, autonomy, averageConsumption, costByKm, averageSpeed, emissions', async function () {

        let body = {
            "domainId": "VehicleType:100",
            "description": "Autocarro de dois andares",
            "autonomy": 400000,
            "fuelType": "Gas",
            "averageSpeed": 30,
            "averageConsumption": 20.222,
            "costByKm": 10,
            "emissions": 70
        };
        let req: Partial<Request> = {};
        req.body = body;

        

        let next: Partial<NextFunction> = () => { };

        let vehicleTypeServiceClass = require("../../../services/VehicleTypeService").default;
        let vehicleTypeServiceClassInstance: IVehicleTypeService = Container.get(vehicleTypeServiceClass);
        Container.set("VehicleTypeService", vehicleTypeServiceClassInstance)

        let vehicleTypeServiceInstance = Container.get("VehicleTypeService");

        let res;

        sinon.stub(vehicleTypeServiceInstance, "createVehicleType").returns({
            "domainId": req.body.domainId,
            "description": req.body.description,
            "autonomy": req.body.autonomy,
            "fuelType": req.body.fuelType,
            "averageSpeed": req.body.averageSpeed,
            "averageConsumption": req.body.averageConsumption,
            "costByKm": req.body.costByKm,
            "emissions": req.body.emissions
        } as IVehicleTypeDTO);

        const controller = new VehicleTypeController(vehicleTypeServiceInstance as IVehicleTypeService);

        await controller.createVehicleType(<Request>req, <Response>res, <NextFunction>next);

        //sinon.assert.calledOnce(res.json as any)
        sinon.assert.calledWith(req.body , sinon.match({
            "domainId": req.body.domainId,
            "description": req.body.description,
            "autonomy": req.body.autonomy,
            "fuelType": req.body.fuelType,
            "averageSpeed": req.body.averageSpeed,
            "averageConsumption": req.body.averageConsumption,
            "costByKm": req.body.costByKm,
            "emissions": req.body.emissions
        }));
    })
})*/