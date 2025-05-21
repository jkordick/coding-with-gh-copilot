// This file contains a simple API endpoint example
// Use it to practice with GitHub Copilot Extensions, Edits, and Agent mode

const express = require('express');
const router = express.Router();

/**
 * Sample user data - in a real application, this would come from a database
 */
const users = [
  { id: 1, name: 'Alice', email: 'alice@example.com', role: 'admin' },
  { id: 2, name: 'Bob', email: 'bob@example.com', role: 'user' },
  { id: 3, name: 'Charlie', email: 'charlie@example.com', role: 'user' },
  { id: 4, name: 'Diana', email: 'diana@example.com', role: 'manager' },
  { id: 5, name: 'Evan', email: 'evan@example.com', role: 'user' }
];

/**
 * Get all users
 * @route GET /api/users
 * @returns {Object[]} - An array of user objects
 */
router.get('/users', (req, res) => {
  res.json(users);
});

/**
 * Get a specific user by ID
 * @route GET /api/users/:id
 * @param {number} id - User ID
 * @returns {Object} - User object
 */
router.get('/users/:id', (req, res) => {
  const userId = parseInt(req.params.id);
  const user = users.find(u => u.id === userId);
  
  if (!user) {
    return res.status(404).json({ error: 'User not found' });
  }
  
  res.json(user);
});

// TODO: Implement a POST endpoint to create a new user
// Hint: Use GitHub Copilot to help you implement this endpoint

// TODO: Implement a PUT endpoint to update an existing user
// Hint: This is a good candidate for GitHub Copilot Edits

// TODO: Implement a DELETE endpoint to remove a user
// Hint: Try using GitHub Copilot Agent mode for this

module.exports = router;

/*
  Extension Practice Tasks:
  1. Use /doc to generate documentation for the POST endpoint once you create it
  2. Use /analyze to review this file and identify potential security issues
  3. Use /tests to generate tests for the API endpoints
  
  Edits Practice Tasks:
  1. Use Copilot Edits to add input validation to the endpoints
  2. Ask Copilot to add pagination to the GET /users endpoint
  3. Use Copilot Edits to add a search functionality to filter users
  
  Agent Practice Tasks:
  1. Ask the agent to help you implement authentication middleware
  2. Have the agent create a complete CRUD API for a new resource (e.g., products)
  3. Ask the agent to refactor the code to use async/await with proper error handling
*/