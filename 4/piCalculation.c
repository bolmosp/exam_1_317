#include <stdio.h>

void iterative_pi_calculation(int *n, double *result) {
    double pi = 0.0;
    int sign = 1;
    for (int i = 0; i < *n; i++) {
        pi += sign * (4.0 / (2 * i + 1));
        sign = -sign;
    }
    *result = pi;
}

void recursive_pi_calculation(int *n, int i, double *result, int sign) {
    if (i >= *n) {
        return;
    }
    *result += sign * (4.0 / (2 * i + 1));
    
    recursive_pi_calculation(n, i + 1, result, -sign);
}

int main() {
    int iterations;
	int option;
    double pi;
	
	printf("\nElegir modo:\n");
    printf("1. Iterativo\n");
    printf("2. Recursivo\n");
    printf("Ingresar opcion (1-2): ");
    scanf("%d", &option);
	
    printf("Número de iteraciones: ");
    scanf("%d", &iterations);
	
	switch (option) {
        case 1:
            iterative_pi_calculation(&iterations, &pi);
            printf("Resultado (iterativo): %.15f\n", pi);
            break;
        case 2:
            recursive_pi_calculation(&iterations, 0, &pi, 1);
            printf("Resultado (recursivo): %.15f\n", pi);
            break;
        default:
            printf("El valor aproximado de pi (recursivo) es: %.15f\n", pi);
            break;
    }

    return 0;
}