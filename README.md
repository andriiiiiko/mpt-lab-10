# Word Count Analyzer (Variant 10)

This program analyzes the frequency of words in a given text by counting the occurrences of each word and storing the 
results in a dictionary.

## Overview

This C# project involves implementing data persistence using two different approaches: binary file storage and 
serialization/deserialization in JSON or XML format. Additionally, the implementation is further evaluated based on the 
use of a universal class dedicated to handling data saving and restoration.

## Grading Criteria

### 1. Binary File Storage (3 points)

Implementing data persistence through saving and restoring data in a binary file.

### 2. JSON/XML Serialization/Deserialization (2 points)

Implementing data persistence through serialization and deserialization in either JSON or XML format.

### 3. Universal Data Handling Class (3 points)

An additional evaluation criterion is the implementation of the above operations using a universal class dedicated to 
data saving and restoration. This class should accept the list to be saved as an object input, rather than just adding 
two extra methods to the main class that works with the list.