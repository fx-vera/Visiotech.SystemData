# Visiotech.SystemData

## Description
This application register periodically some system data of the local machine and store in a json file to load the data each time that the user opens the app.

## Author
Francisco Vera

## Requirements
.NET Framework v4.8.1
Newtonsoft.Json.13.0.3 for parsing files.
MSTest.TestAdapter.2.2.10 for unit testing

## Patterns applied
MVVM to build the WPF application.
Command patter (Relay command recommended by Microsoft)
Singleton for the main service

## Unit testing
This project uses MSTest to check the services functionality.

## External dependencies
The library Visiotech.HardwareInfo to obtain some system data.

## Notes
To implement some functionality like retrieve the system data I visited some technical webs.

## Solution Structure
The solution contains three projects
1. * Visiotech.SystemData.MVVM * that cover all the MVVM development. It was not necessary separate in other projects because the functionality required was minimal.
2. * Visiotech.SystemData.Launcher * this project references the MVVM project and do nothing more.
3. * Visiotech.SystemData.MVVM.Test * this project inclused the unit test implemented.


## functionality



