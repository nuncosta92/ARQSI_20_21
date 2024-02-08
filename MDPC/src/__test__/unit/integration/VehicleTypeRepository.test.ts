/*import * as sinon from 'sinon';
import Container from 'typedi';
import { UniqueEntityID } from '../../../core/UniqueEntityID';
import { idVehicleType } from '../../../domain/valueobjects/idVehicleType';
import { VehicleType } from '../../../domain/VehicleType';
import * as chai from 'chai';
import { Result } from '../../../core/logic/Result';
import VehicleTypeRepository from '../../../repos/VehicleTypeRepository';
import { IVehicleTypePersistence } from '../../../dataschema/IVehicleTypePersistence';
import { Document, Model } from 'mongoose';
import { VehicleTypeMapper } from '../../../mappers/VehicleTypeMapper';
import VehicleTypeSchema from '../../../persistence/schemas/VehicleTypeSchema';

describe('Vehicle Type Repository', function () {

    it('save(), returns VehicleType saved', async function () {

        let sandbox = sinon.sandbox.create();

        let vehicleTypeSchemaClass = require('../../../persistence/schemas/VehicleTypeSchema').default;
        let vehicleTypeSchemaInstance = Container.get(vehicleTypeSchemaClass);
        Container.set('VehicleTypeSchema', vehicleTypeSchemaInstance);

        vehicleTypeSchemaInstance = Container.get('VehicleTypeSchema');

        const databaseId = new UniqueEntityID("5fb165cf1b5d6c087094761e");
        const domainIdProps = new UniqueEntityID("TestVehicleType:011")

        const domainId = idVehicleType.create(domainIdProps);

        const dummyVehicleType = new VehicleType({
            domainId: domainId,
            description: 'Metro de duas áreas',
            fuelType: 'Diesel',
            autonomy: 400,
            averageConsumption: 10,
            costByKm: 10,
            averageSpeed: 10,
            emissions: 10,
        }, databaseId);

        sinon.stub(vehicleTypeSchemaInstance, "findOne").returns(null);

        sinon.stub(vehicleTypeSchemaInstance, "create").returns({
            _id: databaseId,
            domainId: 'VehicleType:105',
            description: 'Metro de duas áreas',
            fuelType: 'Diesel',
            autonomy: 400,
            averageConsumption: 10,
            costByKm: 10,
            averageSpeed: 10,
            emissions: 10,
            __v: 0
        });

        sinon.stub(VehicleTypeMapper, "toPersistence").returns({
            domainId: 'VehicleType:105',
            description: 'Metro de duas áreas',
            fuelType: 'Diesel',
            autonomy: 400,
            averageConsumption: 10,
            costByKm: 10,
            averageSpeed: 10,
            emissions: 10,
        });

        sinon.stub(VehicleTypeMapper, "toDomain").returns(dummyVehicleType);

        const repo = new VehicleTypeRepository(vehicleTypeSchemaInstance as Model<IVehicleTypePersistence & Document>);

        await repo.save(dummyVehicleType);


        sinon.assert.calledWith(dummyVehicleType, sinon.match(dummyVehicleType));

        sandbox.restore();
    });

})*/