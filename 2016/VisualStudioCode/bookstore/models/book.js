var mongoose = require('mongoose');

// Book Schema
var BookSchema = mongoose.Schema({
    title: {type: String, require: true},
    genre: {type: String, require: true},
    description: {type: String, require: true},
    author: {type: String, require: true}, 
    publisher: {type: String, require: true},
    pages:{type: Number, require: true},
    create_date: {type:Date, default: Date.now}
})

var Book = module.exports = mongoose.model('Book', BookSchema);

// Get Books
module.exports.getBooks = function(callback, limit){
    Book.find(callback).limit(limit);
}

// Get Book
module.exports.getBookById = function(id, callback){
    Book.findById(id, callback);
}

// Add book
module.exports.addBook = function(book, callback){
    Book.create(book, callback);
}

// Update book
module.exports.updateBook = function(id, book, options, callback){
    var query = { _id: id };
    var update = {
        title: book.title
    }
    Book.findOneAndUpdate(query, update, options, callback);
}

// delete book
module.exports.deleteBook = function(id, callback){
    var query = { _id: id };
    Book.remove(query, callback);
}