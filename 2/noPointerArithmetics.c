#include <stdio.h>

float addition(float a, float b) {
    return a + b;
}

float substraction(float a, float b) {
    return a - b;
}

float multiplication(float a, float b) {
    return a * b;
}

float division(float a, float b) {
    if (b != 0) {
        return a / b;
    } else {
        printf("Error: Division por cero.\n");
        return 0;
    }
}

int main() {
    float num1, num2;
    int option;
    float result;

    printf("Primer numero: ");
    scanf("%f", &num1);
    printf("Segundo numero: ");
    scanf("%f", &num2);

    printf("\nOpciones operacion:\n");
    printf("1. Suma\n");
    printf("2. Resta\n");
    printf("3. Multiplicacion\n");
    printf("4. Division\n");
    printf("Elegir operacion (1-4): ");
    scanf("%d", &option);

    switch (option) {
        case 1:
            result = addition(num1, num2);
            printf("Resultado: %.2f\n", result);
            break;
        case 2:
            result = substraction(num1, num2);
            printf("Resultado: %.2f\n", result);
            break;
        case 3:
            result = multiplication(num1, num2);
            printf("Resultado: %.2f\n", result);
            break;
        case 4:
            result = division(num1, num2);
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
