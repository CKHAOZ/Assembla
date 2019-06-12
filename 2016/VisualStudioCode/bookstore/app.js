var express = require('express');
var connect = require('connect');
var app = express();
var bodyParser = require('body-parser');
var mongoose = require('mongoose');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({"extended" : false}));

Genre = require('./models/genre');
Book = require('./models/book');

// Connect to mongoose
mongoose.connect('mongodb://localhost/bookstore');
var db = mongoose.connection;

app.get('/', function(req, res){
    res.send('Hola, por favor usa el API de Libros');
});

// Select
app.get('/api/genres', function(req, res){
    Genre.getGenres(function(err, generes){
        if(err){
            throw err;
        }
        res.json(generes);
    })
});

app.get('/api/books', function(req, res){
    Book.getBooks(function(err, books){
        if(err){
            throw err;
        }
        res.json(books);
    })
});

app.get('/api/books/:id', function(req, res){
    console.log('app node ' + req.params.id);
    Book.getBookById(req.params.id, function(err, book){
        if(err){
            throw err;
        }
        res.json(book);
    })
});

// Insert
app.post('/api/books', function(req, res){
    var bookFrom = req.body;
    Book.addBook(bookFrom, function(err, book){
        if(err){
            throw err;
        }
        res.json(book);
    })
});

app.post('/api/genres', function(req, res){
    var genre = req.body;
    Genre.addGenre(genre, function(err, genre){
        if(err){
            throw err;
        }
        res.json(genre);
    })
});

// Update
app.put('/api/books/:_id', function(req, res){
    var id = req.params._id;
    var bookFrom = req.body;
    Book.updateBook(id, bookFrom, {}, function(err, book){
        if(err){
            throw err;
        }
        res.json(book);
    })
});

app.put('/api/genres/:_id', function(req, res){
    var id = req.params._id;
    var genreFrom = req.body;
    Genre.updateGenre(id, genreFrom, {}, function(err, genre){
        if(err){
            throw err;
        }
        res.json(genre);
    })
});

// Delete
app.delete('/api/genres/:_id', function(req, res){
    var id = req.params._id;
    Genre.deleteGenre(id, function(err, genre){
        if(err){
            throw err;
        }
        res.json(genre);
    })
});

app.delete('/api/books/:_id', function(req, res){
    var id = req.params._id;
    Book.deleteBook(id, function(err, book){
        if(err){
            throw err;
        }
        res.json(book);
    })
});

app.listen(4000, function(){
    console.log('Runing on port 4000');
})