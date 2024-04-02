## Implementation of a small multi-page WPF application. 

Application gets data from CoinCapc API (https://docs.coincap.io) and shows data about cryptocurrencies.
All functional abilities are listed below:
  ### Main 
 - See basic information about cryptocurrentcies in list format
 - Search for a cryptocurrency or choose number of cryptocurrencies to show in list
 - Navigate throught application's windows
 - See more information about chosen cryptocurrency
  ### Additional
 - Change theme for dark or light mode

## For implementation I've chosen those nuget packages:
- MaterialDesignThemes provides huge variaty of ready-to-use components for UI creation;
- Newtonsoft.Json to parse json objects from API resonces
- MvvmLightLibs has implementations of RelayCommand generic class, which makes commands much easier to create
