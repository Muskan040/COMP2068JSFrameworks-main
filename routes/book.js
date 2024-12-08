const express = require('express');
const router = express.Router();
const Book = require('../models/book');
const { ensureAuthenticated } = require('../middleware/auth');

// Public - View all books
router.get('/', async (req, res) => {
    try {
        const books = await Book.find();
        res.render('books/list', { books, user: req.user });
    } catch (err) {
        res.status(500).send('Server Error');
    }
});

// Private - Add book (GET and POST)
router.get('/add', ensureAuthenticated, (req, res) => {
    res.render('books/add');
});

router.post('/add', ensureAuthenticated, async (req, res) => {
    const { title, author, genre, year, available } = req.body;
    const newBook = new Book({
        title,
        author,
        genre,
        year: parseInt(year),
        available: available === 'on'
    });
    try {
        await newBook.save();
        res.redirect('/books');
    } catch (err) {
        res.status(500).send('Server Error');
    }
});

// Private - Edit book (GET and POST)
router.get('/edit/:id', ensureAuthenticated, async (req, res) => {
    try {
        const book = await Book.findById(req.params.id);
        res.render('books/edit', { book });
    } catch (err) {
        res.status(500).send('Server Error');
    }
});

router.post('/edit/:id', ensureAuthenticated, async (req, res) => {
    const { title, author, genre, year, available } = req.body;
    try {
        await Book.findByIdAndUpdate(req.params.id, {
            title,
            author,
            genre,
            year: parseInt(year),
            available: available === 'on'
        });
        res.redirect('/books');
    } catch (err) {
        res.status(500).send('Server Error');
    }
});

// Private - Delete book
router.post('/delete/:id', ensureAuthenticated, async (req, res) => {
    try {
        await Book.findByIdAndDelete(req.params.id);
        res.redirect('/books');
    } catch (err) {
        res.status(500).send('Server Error');
    }
});

module.exports = router;
