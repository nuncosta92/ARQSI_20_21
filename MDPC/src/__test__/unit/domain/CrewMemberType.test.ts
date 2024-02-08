import { UniqueEntityID } from '../../../core/UniqueEntityID';
import { CrewMemberType } from '../../../domain/CrewMemberType';
import * as chai from 'chai';
import { Result } from '../../../core/logic/Result';

const id = new UniqueEntityID("123");


describe('Crew Member Type Domain', function () {

    const dummyCrewMemberType = Result.ok<CrewMemberType>(new CrewMemberType({
        description: 'O condutor conduz'
    }, id)).getValue();

    it('get id(), return Crew Member Type id', async function () {

        const expectedResult = id;

        const result = dummyCrewMemberType.id;

        chai.assert.deepEqual(result, expectedResult);
    });

    it('get decription(), return Crew Member Type description', async function () {

        const expectedResult = 'O condutor conduz';

        const result = dummyCrewMemberType.description;

        chai.assert.deepEqual(result, expectedResult);
    });
});