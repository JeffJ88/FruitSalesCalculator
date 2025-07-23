1 & 2. Design Decisions and Design Patterns:

I used the following design patterns because:

Observer pattern to allow for dynamic updates to the pricing when fruit prices change. Not completely implemented.

Strategy pattern to allow for different pricing strategies for fruit.

Factory pattern to create instances of different pricing strategies.

My suggestion is to add singleton pattern for MarketPriceProvider to ensure a single instance is setting fruit prices.

How would you extend it to support new fruit, discounts or pricing models?
New fruits can be added by creating new fruit objects. MarketPriceProvider updates the price per kg/unit using the fruit name as a key. Pricing strategies can use new fruit objects to calculate prices.

Discounts can be added by creating a new pricing strategy including the discount. Decorator pattern can be used to add variations on top of existing pricing strategies.

New pricing strategies can be created and registered with the PricingStrategyFactory.
