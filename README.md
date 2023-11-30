# Word Count Analyzer (Variant 10)

This program analyzes the frequency of words in a given text by counting the occurrences of each word and storing 
the results in a dictionary.

## Grading Criteria

### 1. Multithreaded Data Generation (2 points)

Implement a method that, using 4 threads, populates an array of 1 million objects with random data (pay attention 
to potential multithreading issues, such as access to shared resources, and try to solve them to ensure correct parallel
processing). The overall size of the array and the range of values for each thread should be configurable parameters 
(for the ability to control the correctness of filling).

### 2. Parallel Sorting Algorithm (3 points)

Implement parallel sorting of the array based on a selected field (use multithreading to divide the array into 
subarrays and sort them; ultimately, merge the sorted subarrays into one sorted array).

### 3. Simultaneous Sorting Threads (1 point)

Create several threads (for example, 4 or 8) and perform sorts in parallel.

### 4. Sorting Time Analysis (1 point)

Measure the execution time of sorting for different numbers of threads and compare the results obtained with sorting 
without parallelization (draw conclusions about the performance of parallel sorting).

### 5. Error-Free Execution (2 points)

Ensure correct exception handling and consider possible errors

### 6. Optimizing Parallel Sorting (1 point)

Find and apply additional ways: to improve performance (specify in comments and README what exactly was done).