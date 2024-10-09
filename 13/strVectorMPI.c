#include <mpi.h>
#include <stdio.h>
#include <string.h>

#define N 6
#define MAX_STRING_LENGTH 100

int main(int argc, char** argv) {
    int rank, size, i;
    char vector[N][MAX_STRING_LENGTH];

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    if (rank == 0) {
        strcpy(vector[0], "INF");
        strcpy(vector[1], "317");
        strcpy(vector[2], "Primer");
        strcpy(vector[3], "Parcial");
        strcpy(vector[4], "Ejercicio");
        strcpy(vector[5], "13");

        MPI_Send(vector, N * MAX_STRING_LENGTH, MPI_CHAR, 1, 0, MPI_COMM_WORLD);
        MPI_Send(vector, N * MAX_STRING_LENGTH, MPI_CHAR, 2, 0, MPI_COMM_WORLD);
    }

    if (rank == 1) {
        MPI_Recv(vector, N * MAX_STRING_LENGTH, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        printf("Procesador 1 Par:\n");
        for (i = 0; i < N; i += 2) {
            printf("Posición %d: %s\n", i, vector[i]);
        }
    }

    if (rank == 2) {
        MPI_Recv(vector, N * MAX_STRING_LENGTH, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        printf("Procesador 2 Impar:\n");
        for (i = 1; i < N; i += 2) {
            printf("Posición %d: %s\n", i, vector[i]);
        }
    }

    MPI_Finalize();
    return 0;
}
