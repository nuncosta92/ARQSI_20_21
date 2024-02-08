import { UniqueEntityID } from '../../../core/UniqueEntityID';
import { idVehicleType } from '../../../domain/valueobjects/idVehicleType';
import { VehicleType } from '../../../domain/VehicleType';
import * as chai from 'chai';
import { Result } from '../../../core/logic/Result';


describe('Vehicle Type Domain', function () {

    const dbID = new UniqueEntityID("abc");

    const domainID = new idVehicleType(new UniqueEntityID("TestVehicleType:01"));

    const dummyVehicleType = Result.ok<VehicleType>(new VehicleType({
        domainId: domainID,
        description: "Test Vehicle Type",
        fuelType: "Diesel",
        autonomy: 10,
        averageConsumption: 10,
        costByKm: 10,
        averageSpeed: 20,
        emissions: 5
    }, dbID)).getValue();

    it('get domainId(), return domain id', async function () {

        const expectedResult = domainID;

        const result = dummyVehicleType.domainId;

        chai.assert.deepEqual(result, expectedResult);
    });

    it('get description(), return description', async function () {

        const expectedResult = "Test Vehicle Type";

        const result = dummyVehicleType.description;

        chai.assert.equal(result, expectedResult);
    });

    it('get fuelType(), return fuelType', async function () {

        const expectedResult = "Diesel";

        const result = dummyVehicleType.fuelType;

        chai.assert.equal(result, expectedResult);
    });

    it('get autonomy(), return autonomy', async function () {

        const expectedResult = 10;

        const result = dummyVehicleType.autonomy;

        chai.assert.equal(result, expectedResult);
    });

    it('get averageConsumption(), return averageConsumption', async function () {

        const expectedResult = 10;

        const result = dummyVehicleType.averageConsumption;

        chai.assert.equal(result, expectedResult);
    });

    it('get costByKm(), return costByKm', async function () {

        const expectedResult = 10;

        const result = dummyVehicleType.costByKm;

        chai.assert.equal(result, expectedResult);
    });

    it('get averageSpeed(), return averageSpeed', async function () {

        const expectedResult = 20;

        const result = dummyVehicleType.averageSpeed;

        chai.assert.equal(result, expectedResult);
    });

    it('get emissions(), return emissions', async function () {

        const expectedResult = 5;

        const result = dummyVehicleType.emissions;

        chai.assert.equal(result, expectedResult);
    });
    
})