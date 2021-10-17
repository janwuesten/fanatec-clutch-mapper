[![Code QL](https://github.com/janwuesten/fanatec-clutch-mapper/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/janwuesten/fanatec-clutch-mapper/actions/workflows/codeql-analysis.yml)
[![Create release](https://github.com/janwuesten/fanatec-clutch-mapper/actions/workflows/create_release.yml/badge.svg)](https://github.com/janwuesten/fanatec-clutch-mapper/actions/workflows/create_release.yml)

# Fanatec analog clutch to digital

## Introduction
### Disclaimer
This is an unofficial software that comes with absolutely no warranty!

### What does this program do?
This program maps your analog clutch of your Fanatec Wheel with the advanced pedal module (APM) with configurable keyboard keys to use in you games where you don't need to clutch function. This enables you to use advanced functions like enable / disable your car lights or your car wipers or any other functions that can't be mapped to the analog clutch.
It enables you to use your analog clutch pedals much more.

### Feature list
- Map you analog clutch of your APM to digital functions ingame
- You can map 2 actions per pedal - 1 short press action and 1 full press action
- A total of 4 mappable actions
- Configurable through XML files

## Tested products
### Tested games
- Assetto Corsa Competizione
- (any other game that can map keyboard keys to ingame actions and use a racing wheel at the same time)

### Tested Wheels
- Fanatec Formula V2.5 (2021 Limited Edition), APM, CSL DD

### Tested OS
- Windows 10
- Windows 11

## Installation

### Prebuild
You can download a prebuild .exe from the release tab. Please note that those prebuild .exe files are not code signed!

### Build from source code
Clone the source code and open a terminal in the project directory. Make sure dotnet is installed on your PC.

Run `dotnet restore` to download all dependencies.

Run `dotnet build --no-restore --configuration release --output bin/fanatec-clutch-mapper` to build the project.

Building can also be done with different params! This will create a .exe file inside the bin/fanatec-clutch-mapper directory.

## Configuration
After opening the program for the first time it will create a `config.xml` beside the .exe file as well as as `wheels` directory with wheel configuration files. Open the `config.xml` with any text editor of your choice.

Default config:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Configuration xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ConfigurationVersion>1</ConfigurationVersion>
  <WheelID>fanatec.formula.apm</WheelID>
  <FullPressThreshold>85</FullPressThreshold>
  <LeftShortKey>ä</LeftShortKey>
  <LeftPressKey>ö</LeftPressKey>
  <RightShortKey>ü</RightShortKey>
  <RightPressKey>#</RightPressKey>
</Configuration>
```

|Config key|Description|
|--|--|
|ConfigurationVersion|The version of the configuration file. Do not change this manually!|
|WheelID|The wheel configuration file you want to use. Possible values are: `fanatec.formula.apm`|
|FullPressThreshold|The percentage (0-100), at which the program registers a clutch press as a "full press"|
|LeftShortKey|The keyboard-key that will be triggerd when you press the left clutch pedal short|
|LeftPressKey|The keyboard-key that will be triggerd when you press the left clutch pedal completly (configured by the `FullPressThreshold` config)|
|RightShortKey|The keyboard-key that will be triggerd when you press the right clutch pedal short|
|RightPressKey|The keyboard-key that will be triggerd when you press the right clutch pedal completly (configured by the `FullPressThreshold` config)|
