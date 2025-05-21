# This file contains sample code for data analysis tasks
# Use it to practice with GitHub Copilot Extensions, Edits, and Agent mode

import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

# Sample sales data
data = {
    'date': pd.date_range(start='2023-01-01', periods=365, freq='D'),
    'sales': np.random.randint(100, 1000, size=365),
    'product_category': np.random.choice(['Electronics', 'Clothing', 'Food', 'Books', 'Home'], size=365),
    'store_location': np.random.choice(['North', 'South', 'East', 'West', 'Central'], size=365),
    'promotion_active': np.random.choice([True, False], size=365, p=[0.3, 0.7])
}

# Create a DataFrame
sales_df = pd.DataFrame(data)

def basic_statistics(df):
    """
    Calculate basic statistics for the sales data
    """
    print("Basic Sales Statistics:")
    print(f"Total sales: {df['sales'].sum()}")
    print(f"Average daily sales: {df['sales'].mean():.2f}")
    print(f"Minimum sales: {df['sales'].min()}")
    print(f"Maximum sales: {df['sales'].max()}")
    print(f"Sales standard deviation: {df['sales'].std():.2f}")

def plot_sales_trend(df):
    """
    Plot the sales trend over time
    """
    plt.figure(figsize=(12, 6))
    plt.plot(df['date'], df['sales'])
    plt.title('Daily Sales Trend')
    plt.xlabel('Date')
    plt.ylabel('Sales')
    plt.grid(True)
    plt.tight_layout()
    # Uncomment to save or display the plot
    # plt.savefig('sales_trend.png')
    # plt.show()

# TODO: Create a function to analyze sales by product category
# Hint: Use GitHub Copilot to help implement this function

# TODO: Create a function to compare sales with and without promotions
# Hint: Try using GitHub Copilot Edits for this task

# TODO: Create a function for time series forecasting of future sales
# Hint: This is a great task for GitHub Copilot Agent mode!

if __name__ == "__main__":
    print("Sample data:")
    print(sales_df.head())
    
    basic_statistics(sales_df)
    # Uncomment to generate the plot
    # plot_sales_trend(sales_df)

"""
Extension Practice Tasks:
1. Use /doc to generate comprehensive documentation for the sales analysis functions
2. Use /analyze to review this file for code improvements and best practices
3. Use /tests to generate test cases for the analysis functions

Edits Practice Tasks:
1. Select the basic_statistics function and use Copilot Edits to enhance it with percentiles and quartiles
2. Ask Copilot to add data visualization for sales by store location
3. Use Copilot Edits to add outlier detection to the sales data

Agent Practice Tasks:
1. Ask the agent to implement a complete sales dashboard with multiple visualizations
2. Have the agent help you implement a machine learning model to predict sales
3. Ask the agent to add a feature that identifies the factors most influencing sales
"""