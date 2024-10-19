const connect = require('connect');
const url = require('url');

function calculate(req, res) {
    const query = url.parse(req.url, true).query;
    const method = query.method;
    const x = parseFloat(query.x);
    const y = parseFloat(query.y);

    let result;
    let operation;

    if (isNaN(x) || isNaN(y)) {
        res.end("Error: x and y must be numbers.");
        return;
    }

    switch (method) {
        case 'add':
            result = x + y;
            operation = '+';
            break;
        case 'subtract':
            result = x - y;
            operation = '-';
            break;
        case 'multiply':
            result = x * y;
            operation = '*';
            break;
        case 'divide':
            if (y === 0) {
                res.end("Error: Division by zero is not allowed.");
                return;
            }
            result = x / y;
            operation = '/';
            break;
        default:
            res.end("Error: Invalid method. Use 'add', 'subtract', 'multiply', or 'divide'.");
            return;
    }

    res.end(`${x} ${operation} ${y} = ${result}`);
}

const app = connect();

app.use('/lab2', calculate);

app.listen(3000, () => {
    console.log('Server running on http://localhost:3000');
});
