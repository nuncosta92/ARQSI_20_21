import express from 'express';
import 'reflect-metadata';
const app = express();
require('dotenv/config');
import config from '../config';
import cors from 'cors';

//Connect to DB
async function startServer() {
  const app = express();

  await require('./loaders').default({ expressApp: app });

  app.listen(config.port, function () {

    console.info(`
        ################################################
        ✌️ Server listening on port: ${config.port} ✌️ 
        ################################################
      `);
  });
}

startServer();
