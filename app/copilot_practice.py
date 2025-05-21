"""
This file contains some sample code that you can use to practice with 
GitHub Copilot Extensions, Edits, and Agent mode in Python
"""

# Sample weather data structure
weather_data = {
    "current": {
        "temperature": 22,
        "condition": "Sunny",
        "humidity": 60,
        "wind_speed": 5,
        "wind_direction": "NW",
        "precipitation": 0
    },
    "forecast": [
        {"day": "Today", "high": 23, "low": 18, "condition": "Sunny"},
        {"day": "Tomorrow", "high": 25, "low": 19, "condition": "Partly Cloudy"},
        {"day": "Day 3", "high": 21, "low": 17, "condition": "Rain"},
        {"day": "Day 4", "high": 20, "low": 15, "condition": "Rain"},
        {"day": "Day 5", "high": 22, "low": 16, "condition": "Cloudy"}
    ],
    "location": {
        "city": "Sample City",
        "country": "Sample Country",
        "coordinates": {
            "latitude": 40.7128,
            "longitude": -74.0060
        }
    }
}

def display_current_weather():
    """Display the current weather information."""
    current = weather_data["current"]
    city = weather_data["location"]["city"]
    print(f"Current weather in {city}:")
    print(f"Temperature: {current['temperature']}°C")
    print(f"Condition: {current['condition']}")
    print(f"Humidity: {current['humidity']}%")
    print(f"Wind: {current['wind_speed']} km/h {current['wind_direction']}")

def display_forecast():
    """Display the weather forecast for the next few days."""
    city = weather_data["location"]["city"]
    print(f"Weather forecast for {city}:")
    for day in weather_data["forecast"]:
        print(f"{day['day']}: {day['condition']}, High: {day['high']}°C, Low: {day['low']}°C")

# TODO: Create a function to fetch real weather data from an API
# Hint: You can ask GitHub Copilot to help you implement this!

# TODO: Create a function to convert temperature between Celsius and Fahrenheit
# Hint: Try using GitHub Copilot Edits for this task

# TODO: Create a UI component to display the weather information
# Hint: This is a great task for GitHub Copilot Agent mode!

# Display sample data
if __name__ == "__main__":
    display_current_weather()
    display_forecast()

"""
Extension Practice Tasks:
1. Use /doc to generate documentation for the display_current_weather function
2. Use /analyze to review this file for improvements
3. Use /tests to generate tests for the temperature conversion function once you create it

Edits Practice Tasks:
1. Select the display_forecast function and use Copilot Edits to add color-coding using ANSI escape codes
2. Ask Copilot to refactor the code to use more Pythonic features
3. Use Copilot Edits to add error handling to the functions

Agent Practice Tasks:
1. Ask the agent to help you implement the function that fetches real weather data from an API
2. Have the agent create a simple console-based UI for displaying the weather information
3. Ask the agent to add a feature that shows weather alerts based on conditions
"""