namespace mpt_lab_7;

/// <summary>
/// Provides methods for parallel array processing, including filling and sorting.
/// </summary>
public class ParallelArrayProcessor
{
    private static readonly object LockObject = new object();

    /// <summary>
    /// Fills the array in parallel with random values within the specified range.
    /// </summary>
    /// <param name="array">The array to be filled.</param>
    /// <param name="minValue">The minimum random value (inclusive).</param>
    /// <param name="maxValue">The maximum random value (exclusive).</param>
    /// <param name="numThreads">The number of parallel threads.</param>
    public static void FillArrayInParallel(int[] array, int minValue, int maxValue, int numThreads)
    {
        Parallel.For(0, numThreads, i =>
        {
            int chunkSize = array.Length / numThreads;
            int start = i * chunkSize;
            int end = (i == numThreads - 1) ? array.Length : (i + 1) * chunkSize;

            Random random = new Random();
            for (int j = start; j < end; j++)
            {
                lock (LockObject)
                {
                    array[j] = random.Next(minValue, maxValue);
                }
            }
        });
    }

    /// <summary>
    /// Performs parallel sorting of the array.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    /// <param name="numThreads">The number of parallel threads.</param>
    public static void ParallelSort(int[] array, int numThreads)
    {
        ParallelSortHelper(array, 0, array.Length - 1, numThreads);
    }

    /// <summary>
    /// Helper method for parallel sorting of the array using quicksort algorithm.
    /// </summary>
    /// <param name="array">The array to be sorted.</param>
    /// <param name="low">The low index of the current partition.</param>
    /// <param name="high">The high index of the current partition.</param>
    /// <param name="numThreads">The number of parallel threads.</param>
    private static void ParallelSortHelper(int[] array, int low, int high, int numThreads)
    {
        if (low < high)
        {
            int partitionIndex = Partition(array, low, high);

            if (numThreads > 1)
            {
                Task[] tasks = new Task[2];
                tasks[0] = Task.Factory.StartNew(() =>
                {
                    ParallelSortHelper(array, low, partitionIndex - 1, numThreads / 2);
                });
                tasks[1] = Task.Factory.StartNew(() =>
                {
                    ParallelSortHelper(array, partitionIndex + 1, high, numThreads / 2);
                });

                Task.WaitAll(tasks);
            }
            else
            {
                ParallelSortHelper(array, low, partitionIndex - 1, numThreads);
                ParallelSortHelper(array, partitionIndex + 1, high, numThreads);
            }
        }
    }

    /// <summary>
    /// Partitions the array for quicksort.
    /// </summary>
    /// <param name="array">The array to be partitioned.</param>
    /// <param name="low">The low index of the partition.</param>
    /// <param name="high">The high index of the partition.</param>
    /// <returns>The partition index.</returns>
    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    /// <summary>
    /// Swaps two elements in the array.
    /// </summary>
    /// <param name="array">The array containing elements to be swapped.</param>
    /// <param name="i">The index of the first element.</param>
    /// <param name="j">The index of the second element.</param>
    private static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }
}