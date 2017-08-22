# Bencode2Json

A .NET Core Library for converting Bencoded Dictionaries to Json Documents 

[![Build status](https://ci.appveyor.com/api/projects/status/fcije8tvireboq8d/branch/master?svg=true)](https://ci.appveyor.com/project/vijayshinva/bencode2json/branch/master)
[![CodeFactor](https://www.codefactor.io/repository/github/vijayshinva/bencode2json/badge)](https://www.codefactor.io/repository/github/vijayshinva/bencode2json)
[![NuGet version](https://badge.fury.io/nu/bencode2json.svg)](https://badge.fury.io/nu/bencode2json)

## Overview
Bencoded dictionaries like the one shown below can easily be coverted to JSON using this library.

##### Bencode
```bencode
d5:debug4:truee
```
##### JSON
```json
{
    "debug": "true"
}
```
- [Installation](#installation)
- [Usage](#usage)
- [Examples](#examples)
- [License](#license)

## Installation

Install the package **Bencode2Json** from [NuGet](https://www.nuget.org/packages/Bencode2Json/) 
or install it from the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```
PM> Install-Package Bencode2Json
```

## Usage

```C#
using Bencode2Json;
...
...
// BencodedData takes any Stream
var bencodedData = new BencodedData(dataStream);
var json = bencodedData.ConvertToJson();
```

## Examples
Demos in the Examples folder.

#### TorrentFileParser
This demo parses an torrent file (which is basically a bencoded dictionary) and converts it to JSON. This JSON is then passed to the popular JSON library JSON.NET for converting it into C# objects.

## Reference
- https://en.wikipedia.org/wiki/Bencode
- https://en.wikipedia.org/wiki/Torrent_file


## License
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/vijayshinva/Bencode2Json/blob/master/LICENSE)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bhttps%3A%2F%2Fgithub.com%2Fvijayshinva%2FBencode2Json.svg?type=shield)](https://app.fossa.io/projects/git%2Bhttps%3A%2F%2Fgithub.com%2Fvijayshinva%2FBencode2Json?ref=badge_shield)

[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bhttps%3A%2F%2Fgithub.com%2Fvijayshinva%2FBencode2Json.svg?type=large)](https://app.fossa.io/projects/git%2Bhttps%3A%2F%2Fgithub.com%2Fvijayshinva%2FBencode2Json?ref=badge_large)