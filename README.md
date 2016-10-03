# BGLTest

1. The structure of this project follows the Onion architecture where dependencies are inverted
  - The Core represents the business model
  - The Infrastructure represents the Data access layer, Utilies and what the application needs to carry out business units
  - The Dependency Resolution manages the Depency Injection/IoC Container
  - UI Represent the View the user interact with
  - Test contains unit tests
  
2. The UI should be made the startup project before running the application
