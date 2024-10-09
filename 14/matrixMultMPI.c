#include <stdio.h>
#include <mpi.h>

#define M 4
#define N 4
#define P 4

int main(int argc, char** argv) {
    int rank, size, i, j, k;
    int A[M][N], B[N][P], C[M][P];

    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);
    MPI_Comm_size(MPI_COMM_WORLD, &size);

    if (rank == 0) {
        printf("Matriz A:\n");
        for (i = 0; i < M; i++) {
            for (j = 0; j < N; j++) {
                A[i][j] = i + j;
                printf("%d ", A[i][j]);
            }
            printf("\n");
        }

        printf("\nMatriz B:\n");
        for (i = 0; i < N; i++) {
            for (j = 0; j < P; j++) {
                B[i][j] = i * j;
                printf("%d ", B[i][j]);
            }
            printf("\n");
        }

        for (i = 1; i < size; i++) {
            MPI_Send(&B, N*P, MPI_INT, i, 0, MPI_COMM_WORLD);
        }

        int rows_per_proc = M / (size - 1);
        int start_row, end_row;

        for (i = 1; i < size; i++) {
            start_row = (i - 1) * rows_per_proc;
            end_row = (i == size - 1) ? M : start_row + rows_per_proc;

            MPI_Send(&A[start_row][0], (end_row - start_row) * N, MPI_INT, i, 1, MPI_COMM_WORLD);
        }
    } else {
        MPI_Recv(&B, N*P, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        int rows_per_proc = M / (size - 1);
        int start_row = (rank - 1) * rows_per_proc;
        int end_row = (rank == size - 1) ? M : start_row + rows_per_proc;
        int local_rows = end_row - start_row;

        int local_A[local_rows][N];
        int local_C[local_rows][P];

        MPI_Recv(&local_A, local_rows * N, MPI_INT, 0, 1, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        for (i = 0; i < local_rows; i++) {
            for (j = 0; j < P; j++) {
                local_C[i][j] = 0;
                for (k = 0; k < N; k++) {
                    local_C[i][j] += local_A[i][k] * B[k][j];
                }
            }
        }

        MPI_Send(&local_C, local_rows * P, MPI_INT, 0, 2, MPI_COMM_WORLD);
    }

    if (rank == 0) {
        int rows_per_proc = M / (size - 1);
        int start_row, end_row;
        
        for (i = 1; i < size; i++) {
            start_row = (i - 1) * rows_per_proc;
            end_row = (i == size - 1) ? M : start_row + rows_per_proc;

            MPI_Recv(&C[start_row][0], (end_row - start_row) * P, MPI_INT, i, 2, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        }

        printf("\nResultado:\n");
        for (i = 0; i < M; i++) {
            for (j = 0; j < P; j++) {
                printf("%d ", C[i][j]);
            }
            printf("\n");
        }
    }

    MPI_Finalize();
    return 0;
}
