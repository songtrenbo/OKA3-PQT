'use strict';
const express = require("express");
const config = require('./config');
const cors = require('cors');
const bodyParser = require('body-parser');
const eventRouters = require('./routers/eventRouter');

const app = express();

app.use(function(req,res,next){
    res.header("Access-Control-Allow-Origin", "*")
    res.header("Access-Control-Allow-Headers", "Origin, X-Resquested-With, Content-Type, Accept");
    res.header('Access-Control-Allow-Methods', 'PUT, POST, GET, DELETE, OPTIONS');
    next();
  });
app.use(cors());
app.use(bodyParser.json());

app.use('/api',eventRouters.router);

app.listen(config.port,()=>console.log('Server is listening on http://localhost:'+config.port));


  module.exports = app;