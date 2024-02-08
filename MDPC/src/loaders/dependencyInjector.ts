import { Container } from 'typedi';
import LoggerInstance from './logger';

export default ({ mongoConnection, schemas, controllers, repos, services }: {
    mongoConnection;
    schemas: { name: string; schema: any }[],
    controllers: { name: string; path: any }[],
    repos: { name: string; path: any }[],
    services: { name: string; path: any }[]
}) => {
    try {

        Container.set("logger", LoggerInstance);  
        schemas.forEach(m => {          
            let schema = require(m.schema).default;
            Container.set(m.name, schema);
        });

        repos.forEach(m => {
            let repoClass = require(m.path).default;
            let repoInstance = Container.get(repoClass);
            Container.set(m.name, repoInstance);
        });

        services.forEach(m => {
            let serviceClass = require(m.path).default;
            let serviceInstance = Container.get(serviceClass)
            Container.set(m.name, serviceInstance);
        });

        controllers.forEach(m => {
            // load the @Service() class by its path
            let controllerClass = require(m.path).default;
            // create/get the instance of the @Service() class
            let controllerInstance = Container.get(controllerClass);
            // rename the instance inside the container
            Container.set(m.name, controllerInstance);
        });
       

    } catch (err) {
        console.error('🔥 Error on dependency injector loader: %o', err);
        throw err;
    };
}