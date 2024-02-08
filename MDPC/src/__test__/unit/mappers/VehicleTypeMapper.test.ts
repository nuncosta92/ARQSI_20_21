import { UniqueEntityID } from '../../../core/UniqueEntityID';
import { idVehicleType } from '../../../domain/valueobjects/idVehicleType';
import { VehicleType } from '../../../domain/VehicleType';
import * as chai from 'chai';
import { Result } from '../../../core/logic/Result';
import { IVehicleTypeDTO } from '../../../DTO/IVehicleTypeDTO';
import { VehicleTypeMapper } from '../../../mappers/VehicleTypeMapper';


describe('Vehicle Type Mapper', function () {

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

    it('toDTO(), returns IVehicleTypeDTO', async function () {

        const expectedResult = {
            domainId: dummyVehicleType.props.domainId.props.toString(),
            description: dummyVehicleType.props.description,
            fuelType: dummyVehicleType.props.fuelType,
            autonomy: dummyVehicleType.props.autonomy,
            averageConsumption: dummyVehicleType.props.averageConsumption,
            costByKm: dummyVehicleType.props.costByKm,
            averageSpeed: dummyVehicleType.props.averageSpeed,
            emissions: dummyVehicleType.props.emissions
        } as IVehicleTypeDTO;

        const result = VehicleTypeMapper.toDTO(dummyVehicleType);

        chai.assert.deepEqual(result, expectedResult);
    });

    /* 
    it('toDomain(), returns VehicleType', async function () {

        const expectedResult = dummyVehicleType;

        const result = VehicleTypeMapper.toDomain({
            domainId: domainID,
            description: "Test Vehicle Type",
            fuelType: "Diesel",
            autonomy: 10,
            averageConsumption: 10,
            costByKm: 10,
            averageSpeed: 20,
            emissions: 5
        });

        chai.assert.deepEqual(result, expectedResult);
    });
    */

    it('toPersistence(), returns Model<IVehicleTypePersistence & Document>', async function () {

        const expectedResult = {
            domainId: dummyVehicleType.props.domainId.props.toString(),
            description: dummyVehicleType.props.description,
            fuelType: dummyVehicleType.props.fuelType,
            autonomy: dummyVehicleType.props.autonomy,
            averageConsumption: dummyVehicleType.props.averageConsumption,
            costByKm: dummyVehicleType.props.costByKm,
            averageSpeed: dummyVehicleType.props.averageSpeed,
            emissions: dummyVehicleType.props.emissions
        }

        const result = VehicleTypeMapper.toPersistence(dummyVehicleType);

        chai.assert.deepEqual(result, expectedResult);
    });


    
})