var express = require('express');
var mongoose = require('mongoose');
var app = express();

mongoose.connect('mongodb://localhost/seriestv', function(err, res){
    if (err) console.log('ERROR: Conectando a la BD: ' + err);
    else console.log('Coneccion exitosa');
});

app.get(function(){
    app.use(express.bodyParser());
    app.use(express.methodOverrride());
    app.use(app.router);
});

app.get('/', function(req, res){
  res.send('hello world');
});

require('./routes')(app); // pass 'app'

app.listen(5000);
console.log('servidor express escuchando en el puerto 5000');