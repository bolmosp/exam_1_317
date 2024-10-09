#include <stdio.h>
#include <mpi.h>

#define N 10

int main(int argc, char** argv) {
    int rank, size, i;
    int vector1[N], vector2[N], resultado[N];

    MPI_Init(&argc, &argv); 
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    if (rank == 0) {
        for (i = 0; i < N; i++) {
            vector1[i] = i;
            vector2[i] = i * 2;
            resultado[i] = 0;
        }
    }

    MPI_Bcast(vector1, N, MPI_INT, 0, MPI_COMM_WORLD);
    MPI_Bcast(vector2, N, MPI_INT, 0, MPI_COMM_WORLD);

    if (rank == 1) {
        for (i = 1; i < N; i += 2) {
            resultado[i] = vector1[i] + vector2[i];
        }
        MPI_Send(resultado, N, MPI_INT, 0, 0, MPI_COMM_WORLD);
    }

    if (rank == 2) {
        for (i = 0; i < N; i += 2) {
            resultado[i] = vector1[i] + vector2[i];
        }
        MPI_Send(resultado, N, MPI_INT, 0, 0, MPI_COMM_WORLD);
    }

    if (rank == 0) {
        int resultado_parcial[N];
        
        MPI_Recv(resultado_parcial, N, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        for (i = 1; i < N; i += 2) {
            resultado[i] = resultado_parcial[i];
        }

        MPI_Recv(resultado_parcial, N, MPI_INT, 2, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        for (i = 0; i < N; i += 2) {
            resultado[i] = resultado_parcial[i];
        }

        printf("Resultado:\n");
        for (i = 0; i < N; i++) {
            printf("%d ", resultado[i]);
        }
        printf("\n");
    }

    MPI_Finalize();
    return 0;
}
