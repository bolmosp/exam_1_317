#include <stdio.h>
#include <omp.h>

#define N 20

int main() {
    int fibonacci[N];
    int i;

    fibonacci[0] = 0;
    fibonacci[1] = 1;

    #pragma omp parallel shared(fibonacci) private(i)
    {
        #pragma omp for
        for (i = 2; i < N; i++) {
            fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
        }
    }

    printf("Serie Fibonacci:\n");
    for (i = 0; i < N; i++) {
        printf("%d ", fibonacci[i]);
    }
    printf("\n");

    return 0;
}
