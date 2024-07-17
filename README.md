# CSC_295_hwWeek3

To adapt the sorting algorithms for sorting Student objects by GPA in descending order, I modified the comparison logic in each algorithm to compare the GPA properties of Student objects. The sorting algorithms were adjusted as follows: Bubble Sort was modified to compare and swap Student objects based on their GPA values. Selection Sort was changed to find the student with the highest GPA and place them in the correct position. Insertion Sort was updated to insert each student into the correct position based on their GPA. Merge Sort was adapted to handle Student objects by splitting the list into smaller lists, sorting them, and then merging them back together in order of GPA from highest to lowest.

A challenge encountered was ensuring the sorting algorithms worked with objects instead of primitive types. This required careful handling of the Student object properties, particularly their GPA values. I had to ensure that the comparison, swap, and merge operations were correctly adapted to work with Student objects.

Another challenge was making sure that the GPA was within the allowed range (0 to 4). This was handled in the Student class constructor by checking if the GPA was valid and throwing an error if it wasn't. This ensured that only valid GPA values were used in the sorting process.
