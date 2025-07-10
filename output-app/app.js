const express = require('express');
const { Client } = require('pg');
const app = express();
const client = new Client({
    host: 'db',
    user: 'postgres',
    password: 'postgres',
    database: 'votes'
});
client.connect();

app.get('/', async (req, res) => {
    const ironman = await client.query("SELECT COUNT(*) FROM votes WHERE vote='ironman'");
    const captain = await client.query("SELECT COUNT(*) FROM votes WHERE vote='captainamerica'");
    res.send(`
        <h1>Vote Results</h1>
        <p>Iron Man: ${ironman.rows[0].count}</p>
        <p>Captain America: ${captain.rows[0].count}</p>
    `);
});

app.listen(8081, () => console.log('Result app running on port 8081'));
