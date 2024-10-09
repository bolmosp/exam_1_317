#include <stdio.h>

void addition(float *a, float *b, float *result) {
    *result = *a + *b;
}

void substraction(float *a, float *b, float *result) {
    *result = *a - *b;
}

void multiplication(float *a, float *b, float *result) {
    *result = *a * *b;
}

void division(float *a, float *b, float *result) {
    if (*b != 0) {
        *result = *a / *b;
    } else {
        printf("Error: División por cero.\n");
        *result = 0;
    }
}

int main() {
    float num1, num2, result;
    int option;

    printf("Primer numero: ");
    scanf("%f", &num1);
    printf("Segundo numero: ");
    scanf("%f", &num2);

    printf("\nElegir operacion:\n");
    printf("1. Suma\n");
    printf("2. Resta\n");
    printf("3. Multiplicacion \n");
    printf("4. Division\n");
    printf("Ingresar opcion (1-4): ");
    scanf("%d", &option);

    switch (option) {
        case 1:
            addition(&num1, &num2, &result);
            printf("Resultado: %.2f\n", result);
            break;
        case 2:
            substraction(&num1, &num2, &result);
            printf("Resultado: %.2f\n", result);
            break;
        case 3:
            multiplication(&num1, &num2, &result);
            printf("Resultado: %.2f\n", result);
            break;
        case 4:
            division(&num1, &num2, &result);
            if (num2 != 0) {
                printf("Resultado: %.2f\n", result);
            }
            break;
        default:
            printf("Opcion no existe.\n");
            break;
    }

    return 0;
}
