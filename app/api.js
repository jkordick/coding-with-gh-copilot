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

app.listen(port, () => {
    console.log(`Server listening on port ${port}`);
});

const request = require('supertest');
const app = require('./app');

describe('POST /hello', () => {
    it('should return "HELLO WORLD" with one name', async () => {
        const res = await request(app)
            .post('/hello')
            .send({ names: ['Alice'] });
        expect(res.statusCode).toEqual(200);
        expect(res.text).toEqual('HELLO WORLD, Alice!');
    });

    it('should return "HELLO WORLD" with multiple names', async () => {
        const res = await request(app)
            .post('/hello')
            .send({ names: ['Alice', 'Bob', 'Charlie'] });
        expect(res.statusCode).toEqual(200);
        expect(res.text).toEqual('HELLO WORLD, Alice, Bob, Charlie!');
    });

    it('should return an error with no names', async () => {
        const res = await request(app)
            .post('/hello')
            .send({});
        expect(res.statusCode).toEqual(400);
        expect(res.text).toEqual('Error: No names provided');
    });

    it('should return an error for invalid names input type', async () => {
        const res = await request(app)
            .post('/hello')
            .send({ names: "Alice" }); // Ungültiger Typ, sollte ein Array sein
        expect(res.statusCode).toEqual(400);
        expect(res.text).toEqual('Error: Invalid input type for names');
    });
});
