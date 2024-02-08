import mongoose from 'mongoose';
require('dotenv/config');
import config from '../../config';

//Connect to DB
export default async () => {
    mongoose.connect(config.databaseURL, { useNewUrlParser: true, useUnifiedTopology: true })
    mongoose.set('useNewUrlParser', true);
    mongoose.set('useFindAndModify', false);
    mongoose.set('useCreateIndex', true);
};