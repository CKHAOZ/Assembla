var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var SerieTVSchema = new Schema({
    titulo: { type: String },
    temporadas: { type: Number },
    pais: { type: String },
    genero: { type: String, enum: ['Comedia', 'Fantasia', 'Drama', 'Terror', 'Sci-Fi'] }
});

module.exports = mongoose.model('SerieTV', SerieTVSchema);