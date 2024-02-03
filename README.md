# ExpandedJsonAttributes #

<br>

## Overview ##

<br>

**ExpandedJsonAttributes** is a library that is written for .Net 7 and .Net 8.<br>
It provides modifiers for validating attributes that inherit [ValidationAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute).

<br>

### How to apply ###

The modifiers should be added to a [System.Text.Json.JsonSerializerOptions](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions) for use with [System.Text.Json.JsonSerializer](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer).<br><br>
The modifers should be added to a [System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.metadata.ijsontypeinforesolver).<br><br>
The [System.Text.Json.Serialization.Metadata.IJsonTypeInfoResolver](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.metadata.ijsontypeinforesolver) should be added to either [System.Text.Json.JsonSerializerOptions.TypeInfoResolver](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.typeinforesolver) or [System.Text.Json.JsonserializerOptions.TypeInfoResolverChain](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.typeinforesolverchain).