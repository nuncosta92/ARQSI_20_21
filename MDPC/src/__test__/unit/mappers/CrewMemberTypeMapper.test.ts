import { UniqueEntityID } from '../../../core/UniqueEntityID';
import { CrewMemberType } from '../../../domain/CrewMemberType';
import * as chai from 'chai';
import { Result } from '../../../core/logic/Result';
import { ICrewMemberTypeDTO } from '../../../DTO/ICrewMemberTypeDTO';
import { CrewMemberTypeMapper } from '../../../mappers/CrewMemberTypeMapper';

describe('Crew Member Type Mapper', function () {

    const id = new UniqueEntityID("123");

    const dummyCrewMemberType = Result.ok<CrewMemberType>(new CrewMemberType({
        description: 'De prego a fundo'
    }, id)).getValue();

    it('toDTO(), returns ICrewMemberTypeDTO', async function () {

        const expectResult = {
            description: dummyCrewMemberType.description
        } as ICrewMemberTypeDTO;

        const result = CrewMemberTypeMapper.toDTO(dummyCrewMemberType);

        chai.assert.deepEqual(result, expectResult);
    });

    it('toPersistance(), returns Model<IVehicleTypePersistence & Document>', async function () {

        const expectResult = {
            domainId: '123',
            description: dummyCrewMemberType.description,
        }

        const result = CrewMemberTypeMapper.toPersistence(dummyCrewMemberType);

        chai.assert.deepEqual(result, expectResult);
    });
});
