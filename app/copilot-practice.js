// This file contains some sample code that you can use to practice with 
// GitHub Copilot Extensions, Edits, and Agent mode

/**
 * A basic weather data fetcher
 * Use this as a starting point for practicing with GitHub Copilot features
 */

// Sample weather data structure
const weatherData = {
  current: {
    temperature: 22,
    condition: "Sunny",
    humidity: 60,
    windSpeed: 5,
    windDirection: "NW",
    precipitation: 0
  },
  forecast: [
    { day: "Today", high: 23, low: 18, condition: "Sunny" },
    { day: "Tomorrow", high: 25, low: 19, condition: "Partly Cloudy" },
    { day: "Day 3", high: 21, low: 17, condition: "Rain" },
    { day: "Day 4", high: 20, low: 15, condition: "Rain" },
    { day: "Day 5", high: 22, low: 16, condition: "Cloudy" }
  ],
  location: {
    city: "Sample City",
    country: "Sample Country",
    coordinates: {
      latitude: 40.7128,
      longitude: -74.0060
    }
  }
};

// Function to display current weather
function displayCurrentWeather() {
  const current = weatherData.current;
  console.log(`Current weather in ${weatherData.location.city}:`);
  console.log(`Temperature: ${current.temperature}°C`);
  console.log(`Condition: ${current.condition}`);
  console.log(`Humidity: ${current.humidity}%`);
  console.log(`Wind: ${current.windSpeed} km/h ${current.windDirection}`);
}

// Function to display weather forecast
function displayForecast() {
  console.log(`Weather forecast for ${weatherData.location.city}:`);
  weatherData.forecast.forEach(day => {
    console.log(`${day.day}: ${day.condition}, High: ${day.high}°C, Low: ${day.low}°C`);
  });
}

// TODO: Create a function to fetch real weather data from an API
// Hint: You can ask GitHub Copilot to help you implement this!

// TODO: Create a function to convert temperature between Celsius and Fahrenheit
// Hint: Try using GitHub Copilot Edits for this task

// TODO: Create a UI component to display the weather information
// Hint: This is a great task for GitHub Copilot Agent mode!

// Display sample data
displayCurrentWeather();
displayForecast();

/*
  Extension Practice Tasks:
  1. Use /doc to generate documentation for the displayCurrentWeather function
  2. Use /analyze to review this file for improvements
  3. Use /tests to generate tests for the temperature conversion function once you create it
  
  Edits Practice Tasks:
  1. Select the displayForecast function and use Copilot Edits to add color-coding based on weather condition
  2. Ask Copilot to refactor the code to use modern JavaScript features
  3. Use Copilot Edits to add error handling to the functions
  
  Agent Practice Tasks:
  1. Ask the agent to help you implement the function that fetches real weather data from an API
  2. Have the agent create a simple UI for displaying the weather information
  3. Ask the agent to add a feature that shows weather alerts based on conditions
*/