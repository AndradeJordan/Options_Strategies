
**Introduction:**
This project, named ***OptionsStrategies***, aims *to implement a pricer for various option trading strategies using **C#***. Initially, the project focuses on pricing *Bullish Strategies*, starting with the *Bull Call Spread*.
The Bull Call Spread strategy involves buying a call option at a lower strike price and selling another call option at a higher strike price, both with the same expiration date. 
The pricer employs ***Monte Carlo simulation*** and the ***Black-Scholes model*** to estimate the price of the Bull Call Spread.

**Development:**

1. **Project Overview:**
   - The project consists of **C#** classes implementing *mathematical tools, abstract parameters, specific option strategies, and a user interface*.
   - Mathematical tools include functions for calculating *mean, standard deviation, generating normal distributions, and matrix operations*.
   - Abstract parameters provide a framework for defining option parameters and simulations.
   - Specific option strategy classes, such as Bull Call Spread, implement the logic for pricing particular strategies.

2. **Implementation Details:**
   - The Bull Call Spread class accepts parameters such as interest rate, spot price, volatility, time to maturity, strike prices, premiums, and simulation numbers.
   - Monte Carlo simulation generates random paths for the underlying asset's price using normal distribution.
   - The Black-Scholes model is used to price individual call options within the Bull Call Spread.
   - The pricer computes the simulated price of the Bull Call Spread and adjusts it based on premiums to calculate the final price.
   - Confidence intervals are calculated to provide a measure of the price's uncertainty.

3. **User Interface:**
   - The user interface prompts the user to input parameters required for pricing the Bull Call Spread.
   - User input validation ensures that only valid parameters are accepted.

**Usage:**
1. Clone the repository to your local machine.
2. Open the project in your preferred C# development environment.
3. Compile and run the program.
4. Follow the prompts to input the required parameters for pricing the Bull Call Spread.
5. View the computed price of the Bull Call Spread along with confidence intervals.

**Conclusion:**
This project serves as the initial implementation for the OptionsStrategies pricer, focusing on the Bull Call Spread as a Bullish Strategy. Future iterations of the project will expand to include pricing for other strategies such as Bearish Spreads or Neutral strategies. 
By leveraging Monte Carlo simulation and the Black-Scholes model, the pricer provides accurate estimates for option prices, facilitating informed trading decisions. 
Users can expect further enhancements and additional strategy implementations in subsequent versions of the project, making it a versatile tool for pricing various option trading strategies.

**Note:** Ensure that you have a basic understanding of option pricing models and C# programming before using this pricer.
