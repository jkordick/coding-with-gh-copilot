const express = require('express');
const app = express();
const port = 3000;

app.use(express.json());
app.use(express.urlencoded({ extended: false }));

app.post('/hello', (req, res) => {
    const names = req.body.names;
    const message = `HELLO WORLD, ${names.join(', ')}!`;
    res.send(message);
});

app.get('/getUser', (req, res) => {
    const user = {
        id: 1,
        name: 'John Doe',
        email: 'john.doe@example.com'
    };
    res.json(user);
});

app.listen(port, () => {
    console.log(`Server listening on port ${port}`);
});
