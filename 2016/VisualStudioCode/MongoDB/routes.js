module.exports = function(app){

    // Moongosse model
    var SerieTV = require('./serietv');

    // Get all data from mongo
    findAllSeriesTV = function(req, res) {
        SerieTV.find(function(err, seriestv){
            if(!err) res.send(seriestv);
            else console.log('ERROR: ' + err);
        })

        //  var serietv = new SerieTV({
        //     titulo: 'Lost',
        //     temporadas: 6,
        //     pais: 'EU',
        //     genero: 'Drama'
        // });

        // res.send(serietv);
    };

    // Get specific item from mongo
    BuscarPorId = function(req, res){
        console.log(req.param.id);
        SerieTV.findById(req.param.id, function(err, serieTv){
            if (!err) res.send(serieTv);
            else console.log('ERROR: ' + err);
        })
    };

    // Post item in mongosse model
    addSerieTv = function(req, res){
        console.log('POST');
        console.log(req.body);

        // var nuevaSerie = new SerieTV({
        //     titulo: req.body.titulo,
        //     temporadas: req.body.temporadas,
        //     pais: req.body.pais,
        //     genero: req.body.genero
        // });

        // nuevaSerie.save(function(err){
        //     if(!err) console.log('SerieTV guardada');
        //     else console.log('ERROR: ' + err);
        // });

        res.send([]);
    }

    // Put, update item
    upateSerieTv = function(req, res){

        console.log('POST');
        console.log(req.body);

        SerieTV.findById(req.param.id, function(err, serieTv){
            serieTv.titulo = req.body.titulo;
            serieTv. temporadas = req.body.temporadas;
            serieTv.pais = req.body.pais;
            serieTv.genero = req.body.genero;
        });

        serieTv.save(function(err){
            if(!err) console.log('SerieTV actualizada');
            else console.log('ERROR: ' + err);
        });
    }

    // Remove item
    deleteSerieTv = function(req, res) {
        SerieTV.findById(req.param.id, function(err, serieTv){
            serieTv.remove(function(err){
                if(!err) console.log('SerieTV borrada');
                else console.log('ERROR: ' + err);
            });
        })
    };

    // Routes
    app.get('/seriestv', findAllSeriesTV);
    app.get('/seriestv/:id', BuscarPorId);
    //app.get('/add', findAllSeriesTV);
    app.post('/AddSerieTV', addSerieTv);
    app.put('/seriestv/:id', upateSerieTv);
    app.delete('/seriestv/:id', deleteSerieTv);

}