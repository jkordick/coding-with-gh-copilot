const request = require('supertest');
const express = require('express');
const app = express();

app.use(express.json());
app.use(express.urlencoded({ extended: false }));

app.post('/hello', (req, res) => {
    const names = req.body.names;
    const message = `HELLO WORLD, ${names.join(', ')}!`;
    res.send(message);
});

describe('POST /hello', () => {
    it('should return a greeting message with one name', async () => {
        const response = await request(app)
            .post('/hello')
            .send({ names: ['John'] });
        expect(response.text).toBe('HELLO WORLD, John!');
    });

    it('should return a greeting message with multiple names', async () => {
        const response = await request(app)
            .post('/hello')
            .send({ names: ['John', 'Jane'] });
        expect(response.text).toBe('HELLO WORLD, John, Jane!');
    });

    it('should return a greeting message with no names', async () => {
        const response = await request(app)
            .post('/hello')
            .send({ names: [] });
        expect(response.text).toBe('HELLO WORLD, !');
    });
});
